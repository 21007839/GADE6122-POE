using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    [Serializable]
    public class Goblin : Enemy
    {
        /// <summary>
        /// Goblin constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        /// <param name="inMaxHP"></param>
        /// <param name="inDamage"></param>
        public Goblin(int inX, int inY, int inMaxHP, int inDamage) : base(inX, inY, inMaxHP, inDamage, GameEngine.GetGoblinSymbol)
        {
            GetEquipment = new MeleeWeapon(MeleeWeapon.Types.Dagger, -1, -1);
        }

        /// <summary>
        /// The method by which a goblin attacks the hero.
        /// </summary>
        /// <param name="target"></param>
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

        /// <summary>
        /// Checks if a movement is valid.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public override MovementEnum ReturnMove(MovementEnum move)
        {
            Map tempMap = Game.ge.GetGameMap;

            // Generates a random direction for the goblin to move in
            int direction = rnd.Next(1, 5);

            // Checks an inputted movement against the goblin's vision array
            switch (direction)
            {
                case 1:
                    if (vision[0].GetSymbol == ' ')
                    {
                        MessageBox.Show("" + vision[0].GetSymbol);

                        return MovementEnum.Up;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case 2:
                    if (vision[1].GetSymbol == ' ')
                    {
                        MessageBox.Show("" + vision[1].GetSymbol);

                        return MovementEnum.Down;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case 3:
                    if (vision[2].GetSymbol == ' ')
                    {
                        MessageBox.Show("" + vision[2].GetSymbol);

                        return MovementEnum.Left;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case 4:
                    if (vision[3].GetSymbol == ' ')
                    {
                        MessageBox.Show("" + vision[3].GetSymbol);

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
