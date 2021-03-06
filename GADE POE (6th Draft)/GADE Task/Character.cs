using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    [Serializable]
    public abstract class Character : Tile
    {
        /// <summary>
        /// Local variables and their respective public accessors
        /// </summary>
        protected int HP;
        public int GetHP { get { return HP; } set { HP = value; } }

        protected int maxHP;
        public int GetMaxHP { get { return maxHP; } set { maxHP = value; } }

        protected int damage;
        public int GetDamage { get { return damage; } set { damage = value; } }

        protected Tile[] vision = new Tile[4];
        public Tile[] GetVision { get { return vision; } set { vision = value; } }

        public enum MovementEnum { None, Up, Down, Left, Right}

        private int purse;
        public int GetPurse { get { return purse; } set { purse = value; } }

        private Weapon equipment;
        public Weapon GetEquipment { get { return equipment; } set { equipment = value; } }

        /// <summary>
        /// Character constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        /// <param name="inSymbol"></param>
        public Character(int inX, int inY, int inMaxHP, int inDamage, char inSymbol) : base(inX, inY, inSymbol)
        {
            maxHP = inMaxHP;
            HP = inMaxHP;
            damage = inDamage;
        }

        /// <summary>
        /// An amount of damage is dealt to a specified target.
        /// The method also checks if the aforementioned damage defeats the target.
        /// (Method overridden by child classes).
        /// </summary>
        /// <param name="target"></param>
        public virtual void Attack(Character target) {}

        /// <summary>
        /// Checks if a target is defeated by an attack
        /// </summary>
        /// <returns></returns>
        public bool IsDead()
        {
            if (HP <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a target is in range of an attack
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public virtual bool CheckRange(Character target)
        {
            if (this.equipment == null)
            {
                if (DistanceTo(target) <= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int eRange = equipment.GetRange;

                if (DistanceTo(target) <= eRange)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Calculates the distance between two characters
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private int DistanceTo(Character target)
        {
            // Distances between the x and y positions are calculated separately
            double distanceX = Math.Abs(this.GetX - target.GetX);
            double distanceY = Math.Abs(this.GetY - target.GetY);

            // Overall distance is calculated via Pythagoras' theorem
            int distance = Convert.ToInt32(Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2)));

            return distance;
        }

        /// <summary>
        /// The hero and enemies are moved one space in the specified direction(s)
        /// </summary>
        /// <param name="move"></param>
        public void Move(MovementEnum move)
        {
            // Creates a temporary Map object
            Map tempMap = Game.ge.GetGameMap;

            // Checks if a move is possible
            if (move != MovementEnum.None)
            {
                // Creates variables for the current position and destination
                int heroX = tempMap.GetHero.GetX;
                int heroY = tempMap.GetHero.GetY;

                int destX = heroX;
                int destY = heroY;

                // Alters the destination co-ordinates according to the parsed direction
                switch (move)
                {
                    case MovementEnum.Up:
                        destY--;
                        break;

                    case MovementEnum.Down:
                        destY++;
                        break;

                    case MovementEnum.Left:
                        destX--;
                        break;

                    case MovementEnum.Right:
                        destX++;
                        break;

                    default:
                        break;
                }

                // Picks up an item if the hero walks onto its square
                if (tempMap.GetMap[destY, destX].GetSymbol == '$' || 
                    tempMap.GetMap[destY, destX].GetSymbol == 'W')
                {
                    Pickup(tempMap.GetItemAtPosition(destX, destY));
                }

                // New hero position is added to the map array
                tempMap.GetMap[destY, destX] = tempMap.GetMap[heroY, heroX];
                tempMap.GetMap[destY, destX].GetX = destX;
                tempMap.GetMap[destY, destX].GetY = destY;

                // Old position is replaced with an EmptyTile object
                tempMap.GetMap[heroY, heroX] = new EmptyTile(heroY, heroX);

                // Updates the vision arrays of the hero and enemies
                tempMap.UpdateVision();

                // Enemies are moved
                for (int i = 0; i < tempMap.GetEnemies.Length; i++)
                {
                    // Only moves goblin enemies
                    if (tempMap.GetEnemies[i].GetSymbol == 'G' || tempMap.GetEnemies[i].GetSymbol == 'L')
                    {
                        MovementEnum direction = MovementEnum.None;

                        // Checks if the generated movement is valid
                        MovementEnum enemyMove = tempMap.GetEnemies[i].ReturnMove(direction);

                        // Stores the new and old co-ordinates
                        int enemyX = tempMap.GetEnemies[i].GetX;
                        int enemyY = tempMap.GetEnemies[i].GetY;

                        int enemyDestX = enemyX;
                        int enemyDestY = enemyY;

                        switch (enemyMove)
                        {
                            case MovementEnum.Up:
                                enemyDestY--;
                                break;

                            case MovementEnum.Down:
                                enemyDestY++;
                                break;

                            case MovementEnum.Left:
                                enemyDestX--;
                                break;

                            case MovementEnum.Right:
                                enemyDestX++;
                                break;

                            default:
                                break;
                        }

                        if (!(enemyMove.Equals(MovementEnum.None)))
                        {
                            // Picks up an item if the enemy walks onto its square
                            if (("" + tempMap.GetMap[enemyDestY, enemyDestX].GetSymbol).Equals("W"))
                            {
                                Pickup(tempMap.GetItemAtPosition(enemyDestX, enemyDestY));
                            }

                            // Swaps the enemy's old position with the new one and leaves an empty tile behind
                            tempMap.GetMap[enemyDestY, enemyDestX] = tempMap.GetMap[enemyY, enemyX];
                            tempMap.GetMap[enemyDestY, enemyDestX].GetX = enemyDestX;
                            tempMap.GetMap[enemyDestY, enemyDestX].GetY = enemyDestY;

                            tempMap.GetMap[enemyY, enemyX] = new EmptyTile(enemyY, enemyX);
                        }
                        tempMap.UpdateVision();
                    }
                    else if (tempMap.GetEnemies[i].GetSymbol == 'M')
                    {
                        tempMap.UpdateVision();
                    }
                    tempMap.UpdateVision();
                }
            }
        }

        /// <summary>
        /// Checks if a movement is valid.
        /// (Method defined by child classes).
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public abstract MovementEnum ReturnMove(MovementEnum move);

        /// <summary>
        /// Represents the object as a formatted string.
        /// (Method defined by child classes).
        /// </summary>
        /// <returns></returns>
        override
        public abstract string ToString();

        /// <summary>
        /// Picks up an item that is parsed into the method. If the item is gold, it adds the amount to the hero's purse
        /// </summary>
        /// <param name="i"></param>
        public void Pickup(Item i)
        {
            if (i != null)
            {
                if (i.GetSymbol == '$')
                {
                    string inputGold = i.ToString();
                    int outputGold = Convert.ToInt32(inputGold);

                    purse += outputGold;
                }
                else if (i.GetSymbol == 'W')
                {
                    string weaponType = i.ToString();

                    MeleeWeapon tempMelee;
                    RangedWeapon tempRanged;
                    switch (weaponType)
                    {
                        case "Dagger":
                            tempMelee = new MeleeWeapon(MeleeWeapon.Types.Dagger, -1, -1);
                            this.Equip(tempMelee);
                            MessageBox.Show("Dagger");
                            break;

                        case "Longsword":
                            tempMelee = new MeleeWeapon(MeleeWeapon.Types.Longsword, -1, -1);
                            this.Equip(tempMelee);
                            MessageBox.Show("Longsword");
                            break;

                        case "Rifle":
                            tempRanged = new RangedWeapon(RangedWeapon.Types.Rifle, -1, -1);
                            this.Equip(tempRanged);
                            MessageBox.Show("Rifle");
                            break;

                        case "Longbow":
                            tempRanged = new RangedWeapon(RangedWeapon.Types.Longbow, -1, -1);
                            this.Equip(tempRanged);
                            MessageBox.Show("Longbow");
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void Equip(Weapon w)
        {
            equipment = w;
            damage = equipment.GetDamage;
        }

        public void Loot(Character defeated)
        {
            // Adds the gold to the victor's purse
            this.GetPurse += defeated.GetPurse;

            if (this.GetSymbol != 'M')
            {
                // Checks if the victor is not carrying a weapon and if the defeated character was carrying a weapon
                if (this.GetEquipment == null && defeated.GetEquipment != null)
                {
                    // Equips the weapon to the victor and unequips it from the loser
                    this.Equip(defeated.GetEquipment);
                    defeated.GetEquipment = null;
                }
            }
        }
    }
}
