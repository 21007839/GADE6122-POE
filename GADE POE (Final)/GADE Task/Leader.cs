using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Leader : Enemy
    {
        /// <summary>
        /// Local field and its respective public accessor
        /// </summary>
        private Tile target;
        public Tile GetTarget { get { return target; } set { target = value; } }

        /// <summary>
        /// Leader constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        /// <param name="inMaxHP"></param>
        /// <param name="inDamage"></param>
        public Leader(int inX, int inY, int inMaxHP, int inDamage) : base(inX, inY, inMaxHP, inDamage, GameEngine.GetLeaderSymbol)
        {
            // Gives the leader a default starting weapon and amount of gold to carry
            GetEquipment = new MeleeWeapon(MeleeWeapon.Types.Longsword, -1, -1);
            damage = GetEquipment.GetDamage;
            GetPurse = 2;
        }

        /// <summary>
        /// The method by which a leader attacks the hero.
        /// </summary>
        /// <param name="target"></param>
        public override void Attack(Character target)
        {
            if (CheckRange(target))
            {
                // Calculates the new HP value
                int newHP = target.GetHP - this.damage;
                target.GetHP = newHP;

                // Decrement the weapon's durability
                if (GetEquipment != null)
                {
                    GetEquipment.GetDurability--;

                    // Destroy the weapon if the durability reaches 0
                    if (GetEquipment.GetDurability == 0)
                    {
                        GetEquipment = null;
                    }
                }

                // Checks if the target is defeated
                if (target.IsDead())
                {
                    // The victor loots the defeated character
                    this.Loot(target);

                    // Updates the map display if the hero is defeated
                    Game.ge.GetGameMap.GetMap[target.GetY, target.GetX] = new EmptyTile(target.GetY, target.GetX);
                }
            }
        }

        /// <summary>
        /// Checks if a movement is valid
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public override MovementEnum ReturnMove(MovementEnum move)
        {
            Map tempMap = Game.ge.GetGameMap;

            MovementEnum direction = MovementEnum.None;

            // Get leader and hero co-ordinates
            int enemyX = this.GetX;
            int enemyY = this.GetY;

            int heroX = tempMap.GetHero.GetX;
            int heroY = tempMap.GetHero.GetY;

            // Generate a random number for randomising pathways
            int rndDirection = rnd.Next(1, 3);

            // Check for shortest route to player
            if (enemyX < heroX && enemyY < heroY)
            {
                if (rndDirection == 1)
                {
                    direction = MovementEnum.Right;
                }
                else
                {
                    direction = MovementEnum.Down;
                }
            }
            else if (enemyX > heroX && enemyY < heroY)
            {
                if (rndDirection == 1)
                {
                    direction = MovementEnum.Left;
                }
                else
                {
                    direction = MovementEnum.Down;
                }
            }
            else if (enemyX < heroX && enemyY > heroY)
            {
                if (rndDirection == 1)
                {
                    direction = MovementEnum.Right;
                }
                else
                {
                    direction = MovementEnum.Up;
                }
            }
            else if (enemyX > heroX && enemyY > heroY)
            {
                if (rndDirection == 1)
                {
                    direction = MovementEnum.Left;
                }
                else
                {
                    direction = MovementEnum.Up;
                }
            }
            else if (enemyX == heroX)
            {
                if (enemyY > heroY)
                {
                    direction = MovementEnum.Up;
                }
                else if (enemyY < heroY)
                {
                    direction = MovementEnum.Down;
                }
            }
            else if (enemyY == heroY)
            {
                if (enemyX > heroX)
                {
                    direction = MovementEnum.Left;
                }
                else if (enemyX < heroX)
                {
                    direction = MovementEnum.Right;
                }
            }

            // Checks an inputted movement against the leader's vision array
            switch (direction)
            {
                case MovementEnum.Up:
                    if (vision[0].GetSymbol == ' ' || vision[0].GetSymbol == 'W')
                    {
                        return MovementEnum.Up;
                    }
                    else
                    {
                        return GetRandomMovement(MovementEnum.Up);
                    }

                case MovementEnum.Down:
                    if (vision[1].GetSymbol == ' ' || vision[1].GetSymbol == 'W')
                    {
                        return MovementEnum.Down;
                    }
                    else
                    {
                        return GetRandomMovement(MovementEnum.Down);
                    }

                case MovementEnum.Left:
                    if (vision[2].GetSymbol == ' ' || vision[2].GetSymbol == 'W')
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return GetRandomMovement(MovementEnum.Left);
                    }

                case MovementEnum.Right:
                    if (vision[3].GetSymbol == ' ' || vision[3].GetSymbol == 'W')
                    {
                        return MovementEnum.Right;
                    }
                    else
                    {
                        return GetRandomMovement(MovementEnum.Right);
                    }

                default:
                    return MovementEnum.None;
            }
        }

        /// <summary>
        /// Returns a random direction for the leader to go in if there is an obstacle
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        private MovementEnum GetRandomMovement(MovementEnum move)
        {
            int newDirection;
            MovementEnum direction;

            // Selects a random direction until a suitable one is found
            do
            {
                newDirection = rnd.Next(1, 5);

                switch (newDirection)
                {
                    case 1:
                        if (vision[0].GetSymbol == ' ' || vision[0].GetSymbol == 'W')
                        {
                            direction = MovementEnum.Up;
                        }
                        else
                        {
                            direction = MovementEnum.None;
                        }
                        break;

                    case 2:
                        if (vision[1].GetSymbol == ' ' || vision[1].GetSymbol == 'W')
                        {
                            direction = MovementEnum.Down;
                        }
                        else
                        {
                            direction = MovementEnum.None;
                        }
                        break;

                    case 3:
                        if (vision[2].GetSymbol == ' ' || vision[2].GetSymbol == 'W')
                        {
                            direction = MovementEnum.Left;
                        }
                        else
                        {
                            direction = MovementEnum.None;
                        }
                        break;

                    case 4:
                        if (vision[3].GetSymbol == ' ' || vision[3].GetSymbol == 'W')
                        {
                            direction = MovementEnum.Right;
                        }
                        else
                        {
                            direction = MovementEnum.None;
                        }
                        break;

                    default:
                        direction = MovementEnum.None;
                        break;
                }

            } while ((direction).Equals(move));

            return direction;
        }
    }
}
