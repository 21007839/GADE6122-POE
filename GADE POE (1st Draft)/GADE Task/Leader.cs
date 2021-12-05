using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Leader : Enemy
    {
        private Tile target;
        public Tile GetTarget { get { return target; } set { target = value; } }

        public Leader(int inX, int inY, int inMaxHP, int inDamage, char symbol) : base(inX, inY, inMaxHP, inDamage, symbol)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum move)
        {
            
        }
    }
}
