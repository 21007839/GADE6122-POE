using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class MeleeWeapon : Weapon
    {
        public enum Types { Dagger, Longsword }

        public override int GetRange { get { return range; } set { range = 1; } }

        public MeleeWeapon(Types inType, int inX, int inY) : base(inX, inY)
        {
            if (inType.Equals(Types.Dagger))
            {
                durability = 10;
                damage = 3;
                cost = 3;
                type = "Dagger";
            }
            else
            {
                durability = 6;
                damage = 4;
                cost = 5;
                type = "Longsword";
            }
        }

        public override string ToString()
        {
            return null; ;
        }

    }
}
