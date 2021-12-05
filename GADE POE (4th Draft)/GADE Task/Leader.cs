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

        public override MovementEnum ReturnMove(MovementEnum move)
        {
            Map tempMap = Game.ge.GetGameMap;

            MovementEnum direction = MovementEnum.None;

            int enemyX = this.GetX;
            int enemyY = this.GetY;

            int heroX = tempMap.GetHero.GetX;
            int heroY = tempMap.GetHero.GetY;

            if (enemyX == heroX)
            {

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
                        return MovementEnum.None;
                    }

                case MovementEnum.Down:
                    if (vision[1].GetSymbol == ' ')
                    {
                        return MovementEnum.Down;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Left:
                    if (vision[2].GetSymbol == ' ')
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Right:
                    if (vision[3].GetSymbol == ' ')
                    {
                        return MovementEnum.Right;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                default:
                    return MovementEnum.None;
            }
        }
    }
}
