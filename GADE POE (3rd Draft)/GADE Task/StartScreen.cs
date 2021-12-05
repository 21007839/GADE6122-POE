using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_Task
{
    public partial class StartScreen : Form
    {
        /// <summary>
        /// Global static variables
        /// </summary>
        public static int minWidth;
        public static int maxWidth;

        public static int minHeight;
        public static int maxHeight;

        public static int numEnemies;
        public static int numItemDrops;

        /// <summary>
        /// StartScreen constructor
        /// </summary>
        public StartScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This button starts the game after all the parameters have been entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Storing all the parameters
            minWidth = Convert.ToInt32(numMinWidth.Value);
            maxWidth = Convert.ToInt32(numMaxWidth.Value);

            minHeight = Convert.ToInt32(numMinHeight.Value);
            maxHeight = Convert.ToInt32(numMaxHeight.Value);

            numEnemies = Convert.ToInt32(numNumEnemies.Value);
            numItemDrops = Convert.ToInt32(numNumItemDrops.Value);

            // Starts up the main form
            this.Hide();
            Game game = new Game();
            game.Show();
        }
    }
}
