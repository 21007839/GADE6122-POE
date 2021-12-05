using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    [Serializable]
    public class Gold : Item
    {
        /// <summary>
        /// Local variables and their respective public accessors
        /// </summary>
        private int numGold;
        public int GetNumGold { get { return numGold; } set { numGold = value; } }

        private Random rnd = new Random();

        /// <summary>
        /// Gold constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        public Gold(int inX, int inY) : base(inX, inY, GameEngine.GetGoldSymbol)
        {
            numGold = rnd.Next(1, 6);
        }

        /// <summary>
        /// Represents the object as a formatted string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "" + numGold;
        }
    }
}
