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

            // Update the shop's stock
            btnStock1.Text = "" + ge.GetStock1();
            btnStock2.Text = "" + ge.GetStock2();
            btnStock3.Text = "" + ge.GetStock3();

            // The player starts with no gold, therefore they cannot buy anything
            btnStock1.Enabled = false;
            btnStock2.Enabled = false;
            btnStock3.Enabled = false;

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

            if (ge.GetAvailability[0])
            {
                btnStock1.Enabled = true;
            }
            if (ge.GetAvailability[1])
            {
                btnStock2.Enabled = true;
            }
            if (ge.GetAvailability[2])
            {
                btnStock3.Enabled = true;
            }

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

            if (ge.GetAvailability[0])
            {
                btnStock1.Enabled = true;
            }
            if (ge.GetAvailability[1])
            {
                btnStock2.Enabled = true;
            }
            if (ge.GetAvailability[2])
            {
                btnStock3.Enabled = true;
            }

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

            if (ge.GetAvailability[0])
            {
                btnStock1.Enabled = true;
            }
            if (ge.GetAvailability[1])
            {
                btnStock2.Enabled = true;
            }
            if (ge.GetAvailability[2])
            {
                btnStock3.Enabled = true;
            }

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

            if (ge.GetAvailability[0])
            {
                btnStock1.Enabled = true;
            }
            if (ge.GetAvailability[1])
            {
                btnStock2.Enabled = true;
            }
            if (ge.GetAvailability[2])
            {
                btnStock3.Enabled = true;
            }

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

                if (ge.GetAvailability[0])
                {
                    btnStock1.Enabled = true;
                }
                if (ge.GetAvailability[1])
                {
                    btnStock2.Enabled = true;
                }
                if (ge.GetAvailability[2])
                {
                    btnStock3.Enabled = true;
                }
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

        private void btnStock1_Click(object sender, EventArgs e)
        {
            // Equip new weapon
            ge.GetGameMap.GetHero.Pickup(ge.GetGameShop.GetWeapons[0]);

            // Remove old weaopn from the shop and add a new one
            ge.GetGameShop.GetWeapons[0] = ge.GetGameShop.RandomWeapon();

            // Check if the user can afford the new weapon
            if (ge.GetAvailability[0])
            {
                btnStock1.Enabled = true;
            }
            else
            {
                btnStock1.Enabled = false;
            }

            if (ge.GetAvailability[1])
            {
                btnStock2.Enabled = true;
            }
            else
            {
                btnStock2.Enabled = false;
            }

            if (ge.GetAvailability[2])
            {
                btnStock3.Enabled = true;
            }
            else
            {
                btnStock3.Enabled = false;
            }

            btnStock1.Text = "" + ge.GetStock1();

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        private void btnStock2_Click(object sender, EventArgs e)
        {
            // Equip new weapon
            ge.GetGameMap.GetHero.Pickup(ge.GetGameShop.GetWeapons[1]);

            // Remove old weaopn from the shop and add a new one
            ge.GetGameShop.GetWeapons[1] = ge.GetGameShop.RandomWeapon();

            // Check if the user can afford the new weapon
            if (ge.GetAvailability[0])
            {
                btnStock1.Enabled = true;
            }
            else
            {
                btnStock1.Enabled = false;
            }

            if (ge.GetAvailability[1])
            {
                btnStock2.Enabled = true;
            }
            else
            {
                btnStock2.Enabled = false;
            }

            if (ge.GetAvailability[2])
            {
                btnStock3.Enabled = true;
            }
            else
            {
                btnStock3.Enabled = false;
            }

            btnStock2.Text = "" + ge.GetStock2();

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        private void btnStock3_Click(object sender, EventArgs e)
        {
            // Equip new weapon
            ge.GetGameMap.GetHero.Pickup(ge.GetGameShop.GetWeapons[2]);

            // Remove old weaopn from the shop and add a new one
            ge.GetGameShop.GetWeapons[2] = ge.GetGameShop.RandomWeapon();

            // Check if the user can afford the new weapon
            if (ge.GetAvailability[0])
            {
                btnStock1.Enabled = true;
            }
            else
            {
                btnStock1.Enabled = false;
            }

            if (ge.GetAvailability[1])
            {
                btnStock2.Enabled = true;
            }
            else
            {
                btnStock2.Enabled = false;
            }

            if (ge.GetAvailability[2])
            {
                btnStock3.Enabled = true;
            }
            else
            {
                btnStock3.Enabled = false;
            }

            btnStock3.Text = "" + ge.GetStock3();

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }
    }
}
