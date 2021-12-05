using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    public partial class Game : Form
    {
        /// <summary>
        /// Global static variable
        /// </summary>
        public static GameEngine ge;

        /// <summary>
        /// Game constructor
        /// </summary>
        public Game()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instructions to be executed when the form loads for the first time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Load(object sender, EventArgs e)
        {
            // A new GameEngine object is created using the parameters from the StartScreen form
            ge = new GameEngine(StartScreen.minWidth, StartScreen.maxWidth,
                                           StartScreen.minHeight, StartScreen.maxHeight,
                                           StartScreen.numEnemies,
                                           StartScreen.numItemDrops);

            // The combobox containing all the possible enemy targets is populated with enemies
            int length = ge.GetGameMap.GetEnemies.Length;
            for (int i = 0; i < length; i++)
            {
                if (!(("" + ge.GetGameMap.GetEnemies[i].GetSymbol).Equals("D")))
                {
                    cmbTarget.Items.Add(ge.GetGameMap.GetEnemies[i]);
                }
            }

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        /// <summary>
        /// A button that moves the player one space up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            ge.MovePlayer(Character.MovementEnum.Up);

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        /// <summary>
        /// A button that moves the player one space down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            // The player is moved according to the inputted direction
            ge.MovePlayer(Character.MovementEnum.Down);

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        /// <summary>
        /// A button that moves the player one space left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            // The player is moved according to the inputted direction
            ge.MovePlayer(Character.MovementEnum.Left);

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        /// <summary>
        /// A button that moves the player one space right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            // The player is moved according to the inputted direction
            ge.MovePlayer(Character.MovementEnum.Right);

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            // Checks if a target has been selected
            if (cmbTarget.SelectedItem != null)
            {
                // The player attacks according to the selected target
                ge.GetGameMap.GetHero.Attack(ge.GetGameMap.GetEnemies[cmbTarget.SelectedIndex]);

                // The map and player stats labels are rendered
                lblMap.Text = "" + ge;
                lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;

                // Resets the target combobox
                // (This requires an enemy to be reselected after every attack)
                cmbTarget.Items.Clear();
                for (int i = 0; i < ge.GetGameMap.GetEnemies.Length; i++)
                {
                    // Checks if an enemy has been defeated
                    if (ge.GetGameMap.GetEnemies[i].GetHP > 0)
                    {
                        cmbTarget.Items.Add(ge.GetGameMap.GetEnemies[i]);
                    }
                }

                ge.PlayerAttacks();
            }
            else
            {
                MessageBox.Show("A target has not been selected.");
            }
        }

        /// <summary>
        /// Calls on the save method located in the GameEngine class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ge.Save();
        }

        /// <summary>
        /// Calls on the save method located in the GameEngine class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            ge.Load();
        }
    }
}
