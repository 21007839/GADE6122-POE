using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    [Serializable]
    public class Obstacle : Tile
    {
        /// <summary>
        /// Obstacle constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Obstacle(int x, int y) : base(x, y, GameEngine.GetObstacleSymbol)
        {
            
        }
    }
}
