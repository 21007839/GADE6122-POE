﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class RangedWeapon : Weapon
    {
        public enum Types { Rifle, Longbow}

        public override int GetRange { get { return base.range; } set { range = value; } }

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

        public override string ToString()
        {
            return this.GetType;
        }

    }
}
