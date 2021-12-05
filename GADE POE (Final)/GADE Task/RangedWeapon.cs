using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class RangedWeapon : Weapon
    {
        /// <summary>
        /// Public enum
        /// </summary>
        public enum Types { Rifle, Longbow}

        public override int GetRange { get { return base.range; } set { range = value; } }

        /// <summary>
        /// RangedWeapon constructor
        /// </summary>
        /// <param name="inType"></param>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        public RangedWeapon(Types inType, int inX, int inY) : base(inX, inY)
        {
            if (inType.Equals(Types.Rifle))
            {
                durability = 3;
                range = 3;
                damage = 5;
                cost = 7;
                type = "Rifle";
            }
            else
            {
                durability = 4;
                range = 2;
                damage = 4;
                cost = 6;
                type = "Longbow";
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
