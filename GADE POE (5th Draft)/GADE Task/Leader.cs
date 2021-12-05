using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Leader : Enemy
    {
        private Tile target;
        public Tile GetTarget { get { return target; } set { target = value; } }

        public Leader(int inX, int inY, int inMaxHP, int inDamage) : base(inX, inY, inMaxHP, inDamage, GameEngine.GetLeaderSymbol)
        {
            GetEquipment = new MeleeWeapon(MeleeWeapon.Types.Longsword, -1, -1);
            damage = GetEquipment.GetDamage;
        }

        public override void Attack(Character target)
        {
            if (CheckRange(target))
            {
                // Calculates the new HP value
                int newHP = target.GetHP - this.damage;
                target.GetHP = newHP;

                // Checks if the target is defeated
                if (target.IsDead())
                {
                    // Updates the map display if the hero is defeated
                    Game.ge.GetGameMap.GetMap[target.GetY, target.GetX] = new EmptyTile(target.GetY, target.GetX);
                }
            }
        }

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

            // Checks an inputted movement against the goblin's vision array
            switch (direction)
            {
                case MovementEnum.Up:
                    if (vision[0].GetSymbol == ' ')
                    {
                        return MovementEnum.Up;
                    }
                    else
                    {
                        return GetRandomMovement(MovementEnum.Up);
                    }

                case MovementEnum.Down:
                    if (vision[1].GetSymbol == ' ')
                    {
                        return MovementEnum.Down;
                    }
                    else
                    {
                        return GetRandomMovement(MovementEnum.Down);
                    }

                case MovementEnum.Left:
                    if (vision[2].GetSymbol == ' ')
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return GetRandomMovement(MovementEnum.Left);
                    }

                case MovementEnum.Right:
                    if (vision[3].GetSymbol == ' ')
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

        private MovementEnum GetRandomMovement(MovementEnum move)
        {
            int newDirection;
            MovementEnum direction;

            do
            {
                newDirection = rnd.Next(1, 5);

                switch (newDirection)
                {
                    case 1:
                        if (vision[0].GetSymbol == ' ')
                        {
                            direction = MovementEnum.Up;
                        }
                        else
                        {
                            direction = MovementEnum.None;
                        }
                        break;

                    case 2:
                        if (vision[1].GetSymbol == ' ')
                        {
                            direction = MovementEnum.Down;
                        }
                        else
                        {
                            direction = MovementEnum.None;
                        }
                        break;

                    case 3:
                        if (vision[2].GetSymbol == ' ')
                        {
                            direction = MovementEnum.Left;
                        }
                        else
                        {
                            direction = MovementEnum.None;
                        }
                        break;

                    case 4:
                        if (vision[3].GetSymbol == ' ')
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
