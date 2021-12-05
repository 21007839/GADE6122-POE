using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    [Serializable]
    public class Mage : Enemy
    {
        /// <summary>
        /// Mage constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        /// <param name="inMaxHP"></param>
        /// <param name="inDamage"></param>
        public Mage (int inX, int inY, int inMaxHP, int inDamage) : base(inX, inY, inMaxHP, inDamage, GameEngine.GetMageSymbol)
        {

        }

        /// <summary>
        /// The method by which a mage attacks both the hero and other enemies around it.
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
                    // Updates the map display if the hero/enemy is defeated
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
            return MovementEnum.None;
        }

        /// <summary>
        /// Checks if a target is in range of an attack
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override bool CheckRange(Character target)
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

        /// <summary>
        /// Calculates the distance between the attacker and the target
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


    }
}
