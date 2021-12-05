using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    [Serializable]
    public class Map
    {
        /// <summary>
        /// Local fields and their respective public accessors
        /// </summary>
        private Tile[,] map;
        public Tile[,] GetMap { get { return map; } set { map = value; } }

        private Hero hero;
        public Hero GetHero { get { return hero; } set { hero = value; } }

        private Enemy[] enemies;
        public Enemy[] GetEnemies { get { return enemies; } set { enemies = value; } }

        private int eCount = 0;

        private Item[] items;
        public Item[] GetItems { get { return items; } set { items = value; } }

        private int iCount = 0;

        private int width;
        public int GetWidth { get { return width; } set { width = value; } }

        private int height;
        public int GetHeight { get { return height; } set { height = value; } }

        private Random rnd;
        public Random GetRnd { get { return rnd; } set { rnd = value; } }

        /// <summary>
        /// Map constructor
        /// </summary>
        /// <param name="minWidth"></param>
        /// <param name="maxWidth"></param>
        /// <param name="minHeight"></param>
        /// <param name="maxHeight"></param>
        /// <param name="numEnemies"></param>
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int numItemDrops)
        {
            // Randomises the size of the map based on the given parameters
            rnd = new Random();

            width = rnd.Next(minWidth, maxWidth + 1);
            height = rnd.Next(minHeight, maxHeight + 1);

            map = new Tile[height, width];

            // Instantiates the enemy array
            enemies = new Enemy[numEnemies];

            // Instantiate the item array
            items = new Item[numItemDrops];

            // Fills the map with EmptyTile objects
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = new EmptyTile(i, j);
                }
            }

            // Borders the map with Obstacle objects
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height- 1)
                    {
                        map[i, j] = new Obstacle(i, j);
                    }
                    else
                    {
                        if (j == 0 || j == width - 1)
                        {
                            map[i, j] = new Obstacle(i, j);
                        }
                    }
                }
            }

            // Creates a Hero object
            Tile temp = Create(Tile.TileType.Hero);
            map[hero.GetY, hero.GetX] = temp;

            // Creates a specified number of Enemy objects
            for (int i = 0; i < numEnemies; i++)
            {
                temp = Create(Tile.TileType.Enemy);
                map[enemies[i].GetY, enemies[i].GetX] = temp;
            }

            for (int i = 0; i < items.Length; i++)
            {
                int rndItem = rnd.Next(1, 3);

                if (rndItem == 1)
                {
                    temp = Create(Tile.TileType.Gold);
                }
                else
                {
                    temp = Create(Tile.TileType.Weapon);
                }

                map[items[i].GetY, items[i].GetX] = temp;
            }


            // Updates the vision array for the player and all the enemies
            UpdateVision();
        }

        /// <summary>
        /// Updates the vision arrays of all the characters on the map
        /// </summary>
        public void UpdateVision()
        {
            // Updates the hero's vision array
            Tile[] currentHeroVision = new Tile[4];

            int currentHeroX = hero.GetX;
            int currentHeroY = hero.GetY;
            
            currentHeroVision[0] = map[currentHeroY - 1, currentHeroX];
            currentHeroVision[1] = map[currentHeroY + 1, currentHeroX];
            currentHeroVision[2] = map[currentHeroY, currentHeroX - 1];
            currentHeroVision[3] = map[currentHeroY, currentHeroX + 1];

            hero.GetVision = currentHeroVision;

            for (int i = 0; i < enemies.Length; i++)
            {
                // Updates the enemies' vision arrays
                Tile[] currentEnemyVision = new Tile[4];

                int currentEnemyX;
                int currentEnemyY;

                currentEnemyX = enemies[i].GetX;
                currentEnemyY = enemies[i].GetY;

                currentEnemyVision[0] = map[currentEnemyY - 1, currentEnemyX];
                currentEnemyVision[1] = map[currentEnemyY + 1, currentEnemyX];
                currentEnemyVision[2] = map[currentEnemyY, currentEnemyX - 1];
                currentEnemyVision[3] = map[currentEnemyY, currentEnemyX + 1];

                enemies[i].GetVision = currentEnemyVision;
            }
        }

        /// <summary>
        /// Creates a Tile object of a specified type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Tile Create(Tile.TileType type)
        {
            int posX;
            int posY;

            bool found = false;

            // Checks what type is being created
            if (type.Equals(Tile.TileType.Hero))
            {
                // Assigns a value to the Hero object
                posX = rnd.Next(1, width - 1);
                posY = rnd.Next(1, height - 1);

                hero = new Hero(posX, posY, 100, 2);

                return hero;
            }
            else if (type.Equals(Tile.TileType.Enemy))
            {
                // Assigns values to the Goblin objects
                // Also checks that unique co-oridinates are chosen so that no character is overridden
                int rndEnemy = rnd.Next(1, 4);

                do
                {
                    posX = rnd.Next(1, width - 1);
                    posY = rnd.Next(1, height - 1);

                    if (map[posY, posX].GetSymbol == ' ')
                    {
                        if (rndEnemy == 1) {
                            enemies[eCount] = new Goblin(posX, posY, 10, 1);
                        }
                        else if (rndEnemy == 2)
                        {
                            enemies[eCount] = new Mage(posX, posY, 5, 5);
                        }
                        else
                        {
                            enemies[eCount] = new Leader(posX, posY, 20, 2);
                        }

                        eCount++;
                        found = true;
                    }
                }
                while (!found);

                return enemies[eCount - 1];
            }
            else if (type.Equals(Tile.TileType.Gold))
            {
                // Assigns values to the Gold objects
                // Also checks that unique co-oridinates are chosen so that no character or item is overridden
                do
                {
                    posX = rnd.Next(1, width - 1);
                    posY = rnd.Next(1, height - 1);

                    if (map[posY, posX].GetSymbol == ' ')
                    {
                        items[iCount] = new Gold(posX, posY);
                        iCount++;
                        found = true;
                    }
                }
                while (!found);

                return items[iCount - 1];
            }
            else if (type.Equals(Tile.TileType.Weapon))
            {
                // Assigns values to the Weapon objects
                // Also checks that unique co-oridinates are chosen so that no character or item is overridden
                int weaponType = rnd.Next(1, 5);

                do
                {
                    posX = rnd.Next(1, width - 1);
                    posY = rnd.Next(1, height - 1);

                    if (map[posY, posX].GetSymbol == ' ')
                    {
                        switch (weaponType)
                        {
                            case 1:
                                items[iCount] = new MeleeWeapon(MeleeWeapon.Types.Dagger, posX, posY);
                                break;

                            case 2:
                                items[iCount] = new MeleeWeapon(MeleeWeapon.Types.Longsword, posX, posY);
                                break;

                            case 3:
                                items[iCount] = new RangedWeapon(RangedWeapon.Types.Rifle, posX, posY);
                                break;

                            case 4:
                                items[iCount] = new RangedWeapon(RangedWeapon.Types.Longbow, posX, posY);
                                break;

                            default:
                                break;
                        }

                        iCount++;
                        found = true;
                    }
                }
                while (!found);

                return items[iCount - 1];
            }
            else
            {
                return null;
            }
        }

        public Item GetItemAtPosition(int x, int y)
        {
            Item foundItem = null;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    break;
                }
                else if (items[i].GetX == x && items[i].GetY == y)
                {
                    foundItem = items[i];
                    items[i] = null;
                    break;
                }
            }

            return foundItem;
        }

        public void GoblinAttack(Enemy attacker)
        {
            attacker.Attack(hero);
        }

        public void MageAttack(Enemy attacker)
        {
            int attackerX = attacker.GetX;
            int attackerY = attacker.GetY;

            Tile target;

            int targetX;
            int targetY;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (!(i == 0 && j == 0))
                    {
                        targetX = attackerX + j;
                        targetY = attackerY + i;

                        target = map[targetY, targetX];

                        if (("" + target.GetSymbol).Equals("H"))
                        {
                            attacker.Attack(hero);
                        }
                        else if (("" + target.GetSymbol).Equals("G") || ("" + target.GetSymbol).Equals("M"))
                        {
                            for (int k = 0; k < enemies.Length; k++)
                            {
                                if (enemies[k].GetX == targetX && enemies[k].GetY == targetY)
                                {
                                    attacker.Attack(enemies[k]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
