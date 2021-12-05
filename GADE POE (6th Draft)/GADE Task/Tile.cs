using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    [Serializable]
    public abstract class Tile
    {
        /// <summary>
        /// Local variables and their respective public accessors
        /// </summary>
        protected int x;
        public int GetX { get { return x; } set { x = value; } }

        protected int y;
        public int GetY { get { return y; } set { y = value; } }

        protected char symbol;
        public char GetSymbol { get { return symbol; } set { symbol = value; } }

        public enum TileType { Hero, Enemy, Gold, Weapon }

        /// <summary>
        /// Tile constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        /// <param name="inSymbol"></param>
        public Tile(int inX, int inY, char inSymbol)
        {
            x = inX;
            y = inY;
            symbol = inSymbol;
        }
    }
}
