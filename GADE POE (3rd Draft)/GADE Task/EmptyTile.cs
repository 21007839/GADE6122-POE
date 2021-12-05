using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    [Serializable]
    public class EmptyTile : Tile
    {
        /// <summary>
        /// EmptyTile constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public EmptyTile(int x, int y) : base(x, y, GameEngine.GetEmptySymbol)
        {
            
        }
    }
}
