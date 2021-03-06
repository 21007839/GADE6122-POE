using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public abstract class Weapon : Item
    {
        protected int damage;
        public int GetDamage { get { return damage; } set { damage = value; } }

        protected int range;
        public virtual int GetRange { get { return range; } set { range = value; } }

        protected int durability;
        public int GetDurablility { get { return durability; } set { durability = value; } }

        protected int cost;
        public int GetCost { get { return cost; } set { cost = value; } }

        protected string type;
        public string GetType { get { return type; } set { type = value; } }

        public Weapon(int inX, int inY) : base(inX, inY, GameEngine.GetWeaponSymbol)
        {

        }


    }
}
