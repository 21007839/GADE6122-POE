using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    [Serializable]
    public abstract class Item : Tile
    {
        /// <summary>
        /// Item constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        /// <param name="symbol"></param>
        public Item (int inX, int inY, char symbol) : base(inX, inY, symbol)
        {

        }

        /// <summary>
        /// Represents the object as a formatted string
        /// </summary>
        /// <returns></returns>
        public abstract string ToString();
    }
}
