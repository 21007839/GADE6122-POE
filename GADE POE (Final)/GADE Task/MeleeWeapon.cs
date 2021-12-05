using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class MeleeWeapon : Weapon
    {
        /// <summary>
        /// Public enum
        /// </summary>
        public enum Types { Dagger, Longsword }

        public override int GetRange { get { return range; } set { range = 1; } }

        /// <summary>
        /// MeleeWeapon constructor
        /// </summary>
        /// <param name="inType"></param>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        public MeleeWeapon(Types inType, int inX, int inY) : base(inX, inY)
        {
            if (inType.Equals(Types.Dagger))
            {
                durability = 10;
                damage = 3;
                cost = 3;
                range = 1;
                type = "Dagger";
            }
            else
            {
                durability = 6;
                damage = 4;
                cost = 5;
                range = 1;
                type = "Longsword";
            }
        }

        /// <summary>
        /// Represents the object as a formatted string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType;
        }

    }
}
