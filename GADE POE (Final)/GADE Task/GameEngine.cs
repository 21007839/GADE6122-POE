using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    [Serializable]
    public class GameEngine
    {
        /// <summary>
        /// Local fields and their respective public accessors
        /// </summary>
        private Map gameMap;
        public Map GetGameMap { get { return gameMap; } set { gameMap = value; } }

        private Shop gameShop;
        public Shop GetGameShop { get { return gameShop; } set { gameShop = value; } }

        private bool[] availability;
        public bool[] GetAvailability { get { return availability; } set { availability = value; } }

        /// <summary>
        /// Static, read-only symbols
        /// </summary>
        private static readonly char heroSymbol = 'H';
        public static char GetHeroSymbol { get { return heroSymbol; } }

        private static readonly char emptySymbol = ' ';
        public static char GetEmptySymbol { get { return emptySymbol; } }

        private static readonly char goblinSymbol = 'G';
        public static char GetGoblinSymbol { get { return goblinSymbol; } }

        private static readonly char obstacleSymbol = '#';
        public static char GetObstacleSymbol { get { return obstacleSymbol; } }

        private static readonly char goldSymbol = '$';
        public static char GetGoldSymbol { get { return goldSymbol; } }

        private static readonly char mageSymbol = 'M';
        public static char GetMageSymbol { get { return mageSymbol; } }

        private static readonly char weaponSymbol = 'W';
        public static char GetWeaponSymbol { get { return weaponSymbol; } }

        private static readonly char leaderSymbol = 'L';
        public static char GetLeaderSymbol { get { return leaderSymbol; } }

        private static readonly string fileName = "SaveData.bin";
        public static string GetFileName { get { return fileName; } }

        /// <summary>
        /// GameEngine constructor
        /// </summary>
        /// <param name="minWidth"></param>
        /// <param name="maxWidth"></param>
        /// <param name="minHeight"></param>
        /// <param name="maxHeight"></param>
        /// <param name="numEnemies"></param>
        public GameEngine(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int numItemDrops)
        {
            gameMap = new Map(minWidth, maxWidth, minHeight, maxHeight, numEnemies, numItemDrops);
            gameShop = new Shop(gameMap.GetHero);

            availability = new bool[3];
        }

        /// <summary>
        /// Moves the player in a specified direction and all the enemies in random directions
        /// </summary>
        /// <param name="direction"></param>
        public void MovePlayer(Character.MovementEnum direction)
        {
            // Moves the player and all the enemies
            gameMap.GetHero.Move(gameMap.GetHero.ReturnMove(direction));

            // Executes the enemy attacks
            PlayerAttacks();
        }

        /// <summary>
        /// Makes all other enemies attack after the hero has had their turn. Each enemy has a specific attack pattern.
        /// </summary>
        public void PlayerAttacks()
        {
            // Loops through the enemy array
            for (int i = 0; i < gameMap.GetEnemies.Length; i++)
            {
                // Check which enemy type has been selected to execute a specific attack pattern
                if (("" + gameMap.GetEnemies[i].GetSymbol).Equals("G"))
                {
                    gameMap.GoblinAttack(gameMap.GetEnemies[i]);
                }
                else if (("" + gameMap.GetEnemies[i].GetSymbol).Equals("M"))
                {
                    gameMap.MageAttack(gameMap.GetEnemies[i]);
                }
                else
                {
                    gameMap.LeaderAttack(gameMap.GetEnemies[i]);
                }

                gameMap.UpdateVision();
            }
        }

        /// <summary>
        /// Saves a game's data to a binary file
        /// </summary>
        // Programmer's Note: Due to the nature of the BinaryFormatter, I was unable to implement the Save method fully.
        // By the looks of it, every class that is being referred to must have the [Serialized] attribute. The issue was
        // that the Random class was used numerous times to generate random numbers; the class, however, does not possess
        // the necessary attribute. As a test, I tried to remove all instances of random variables and temporarily hard-code
        // every value. I tested this on the map object and it worked -- I checked in the SaveData.bin file and everything was
        // there. Because the Random variables are a necessity, however, I could not use that solution. For now, the method
        // works theoretically (everything "can" save) but not practically (not everything "does" save).
        public void Save()
        {
            // Initialises the file stream and binary formatter
            FileStream fileWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            // Saves the map, hero, and enemies
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(fileWriter, gameMap);
            bFormatter.Serialize(fileWriter, gameMap.GetHero);
            bFormatter.Serialize(fileWriter, gameMap.GetEnemies);

            // Closes the file once the data has been saved
            fileWriter.Close();
        }

        /// <summary>
        /// Loads a previous game's save data from a binary file if said file exists
        /// </summary>
        // This method faced a similar issue; I was not able to test if it worked due to the inoperability of the save method.
        // Because of this, I am unsure as to how well/poorly this code block runs. When running the project and pressing the
        // load button, no runtime errors occur which means that it at least partially works.
        public void Load()
        {
            // Initialises the temporary holding variables
            Map readMap;
            Hero readHero;
            Enemy[] readEnemies;

            // Checks if there is an instance of a save file
            if (File.Exists(fileName))
            {
                // Initialises the file stream
                FileStream fileReader = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                // Loads the map, hero, and enemies
                BinaryFormatter bFormatter = new BinaryFormatter();
                while (fileReader.Position < fileReader.Length)
                {
                    // Populates the temporary variables
                    readMap = (Map)bFormatter.Deserialize(fileReader);
                    readHero = (Hero)bFormatter.Deserialize(fileReader);
                    readEnemies = (Enemy[])bFormatter.Deserialize(fileReader);

                    // Assigns the temporary variables to their correct positions
                    gameMap = readMap;
                    gameMap.GetHero = readHero;
                    gameMap.GetEnemies = readEnemies;
                }
                // Closes the file after the data has been read
                fileReader.Close();
            }
        }

        /// <summary>
        /// Returns the first item from the shop's stock
        /// </summary>
        /// <returns></returns>
        public string GetStock1()
        {
            return gameShop.DisplayWeapon(gameShop.GetWeapons[0], gameShop.GetWeapons[0].GetCost);
        }

        /// <summary>
        /// Returns the second item from the shop's stock
        /// </summary>
        /// <returns></returns>
        public string GetStock2()
        {
            return gameShop.DisplayWeapon(gameShop.GetWeapons[1], gameShop.GetWeapons[1].GetCost);
        }

        /// <summary>
        /// Returns the third item from the shop's stock
        /// </summary>
        /// <returns></returns>
        public string GetStock3()
        {
            return gameShop.DisplayWeapon(gameShop.GetWeapons[2], gameShop.GetWeapons[2].GetCost);
        }

        /// <summary>
        /// Returns the array of enemies
        /// </summary>
        /// <returns></returns>
        public Enemy[] GetEnemyArray()
        {
            return GetGameMap.GetEnemies;
        }

        /// <summary>
        /// Returns the hero
        /// </summary>
        /// <returns></returns>
        public Hero GetMapHero()
        {
            return GetGameMap.GetHero;
        }

        /// <summary>
        /// Returns the hero's total gold
        /// </summary>
        /// <returns></returns>
        public int GetHeroPurse()
        {
            return GetGameMap.GetHero.GetPurse;
        }

        /// <summary>
        /// Sets a new value to the hero's total wallet based on a parsed amount
        /// </summary>
        /// <param name="purchase"></param>
        public void SetHeroPurse(int purchase)
        {
            GetGameMap.GetHero.GetPurse -= purchase;
        }

        /// <summary>
        /// Checks if the hero can buy the weapon given as a parameter
        /// </summary>
        /// <param name="attemptPurchase"></param>
        /// <returns></returns>
        public bool CheckAvailability(Weapon attemptPurchase)
        {
            if (GetGameShop.CanBuy(attemptPurchase.GetCost))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the shop's stock
        /// </summary>
        /// <returns></returns>
        public Weapon[] GetShopStock()
        {
            return GetGameShop.GetWeapons;
        }

        /// <summary>
        /// Represents the map in a formatted string
        /// </summary>
        /// <returns></returns>
        override
        public string ToString()
        {
            string st = "";

            for (int i = 0; i < gameMap.GetHeight; i++)
            {
                for (int j = 0; j < gameMap.GetWidth; j++)
                {
                    st += gameMap.GetMap[i, j].GetSymbol + " ";
                }
                st += "\n";
            }
            return st;
        }
    }
}
