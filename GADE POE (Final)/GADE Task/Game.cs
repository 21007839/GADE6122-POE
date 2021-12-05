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
        /// Temporary global varaibles
        /// </summary>
        public Enemy[] tempEnemies;
        public Hero tempHero;
        public Weapon[] tempWeapons;

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
                tempEnemies = ge.GetEnemyArray();
                cmbTarget.Items.Add(tempEnemies[i].ToString());
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

            tempHero = ge.GetMapHero();
            lblPlayerStats.Text = "" + tempHero;
        }

        /// <summary>
        /// A button that moves the player one space up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            // The player is moved according to the inputted direction
            ge.MovePlayer(Character.MovementEnum.Up);

            // Update availability
            UpdateShopButtons();

            // Resets the target combobox
            // (This requires an enemy to be reselected after every attack)
            cmbTarget.Items.Clear();
            for (int i = 0; i < ge.GetGameMap.GetEnemies.Length; i++)
            {
                tempEnemies = ge.GetEnemyArray();
                cmbTarget.Items.Add(tempEnemies[i].ToString());
            }

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;

            tempHero = ge.GetMapHero();
            lblPlayerStats.Text = "" + tempHero;
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

            // Update availability
            UpdateShopButtons();

            // Resets the target combobox
            // (This requires an enemy to be reselected after every attack)
            cmbTarget.Items.Clear();
            for (int i = 0; i < ge.GetGameMap.GetEnemies.Length; i++)
            {
                tempEnemies = ge.GetEnemyArray();
                cmbTarget.Items.Add(tempEnemies[i].ToString());
            }

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;

            tempHero = ge.GetMapHero();
            lblPlayerStats.Text = "" + tempHero;
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

            // Update availability
            UpdateShopButtons();

            // Resets the target combobox
            // (This requires an enemy to be reselected after every attack)
            cmbTarget.Items.Clear();
            for (int i = 0; i < ge.GetGameMap.GetEnemies.Length; i++)
            {
                tempEnemies = ge.GetEnemyArray();
                cmbTarget.Items.Add(tempEnemies[i].ToString());
            }

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;

            tempHero = ge.GetMapHero();
            lblPlayerStats.Text = "" + tempHero;
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

            // Update availability
            UpdateShopButtons();

            // Resets the target combobox
            // (This requires an enemy to be reselected after every attack)
            cmbTarget.Items.Clear();
            for (int i = 0; i < ge.GetGameMap.GetEnemies.Length; i++)
            {
                tempEnemies = ge.GetEnemyArray();
                cmbTarget.Items.Add(tempEnemies[i].ToString());
            }

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;

            tempHero = ge.GetMapHero();
            lblPlayerStats.Text = "" + tempHero;
        }

        /// <summary>
        /// The hero attacks a selected enemy which then attacks back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttack_Click(object sender, EventArgs e)
        {
            // Checks if a target has been selected
            if (cmbTarget.SelectedItem != null)
            {
                // The player attacks according to the selected target
                tempEnemies = ge.GetEnemyArray();
                ge.GetGameMap.GetHero.Attack(tempEnemies[cmbTarget.SelectedIndex]);

                // The map and player stats labels are rendered
                lblMap.Text = "" + ge;

                tempHero = ge.GetMapHero();
                lblPlayerStats.Text = "" + tempHero;

                // Resets the target combobox
                // (This requires an enemy to be reselected after every attack)
                cmbTarget.Items.Clear();
                for (int i = 0; i < ge.GetGameMap.GetEnemies.Length; i++)
                {
                    tempEnemies = ge.GetEnemyArray();
                    cmbTarget.Items.Add(tempEnemies[i].ToString());
                }

                ge.PlayerAttacks();

                // Update availability
                UpdateShopButtons();
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

        /// <summary>
        /// Controls what is displayed on the first button of the shop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStock1_Click(object sender, EventArgs e)
        {
            // Equips new weapon
            ge.GetGameMap.GetHero.Pickup(ge.GetGameShop.GetWeapons[0], ge.GetGameMap.GetHero);

            ge.SetHeroPurse(ge.GetGameShop.GetWeapons[0].GetCost);

            // Removes old weapon from the shop and adds a new one
            ge.GetGameShop.GetWeapons[0] = ge.GetGameShop.RandomWeapon();
            btnStock1.Text = "" + ge.GetStock1();

            // Update availability
            UpdateShopButtons();

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;

            tempHero = ge.GetMapHero();
            lblPlayerStats.Text = "" + tempHero;
        }

        /// <summary>
        /// Controls what is displayed on the second button of the shop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStock2_Click(object sender, EventArgs e)
        {
            // Equips new weapon
            ge.GetGameMap.GetHero.Pickup(ge.GetGameShop.GetWeapons[1], ge.GetGameMap.GetHero);
            ge.SetHeroPurse(ge.GetHeroPurse() - ge.GetGameShop.GetWeapons[1].GetCost);

            // Removes old weapon from the shop and adds a new one
            ge.GetGameShop.GetWeapons[1] = ge.GetGameShop.RandomWeapon();
            btnStock2.Text = "" + ge.GetStock2();

            // Update availability
            UpdateShopButtons();

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;

            tempHero = ge.GetMapHero();
            lblPlayerStats.Text = "" + tempHero;
        }

        /// <summary>
        /// Controls what is displayed on the third button of the shop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStock3_Click(object sender, EventArgs e)
        {
            // Equips new weapon
            ge.GetGameMap.GetHero.Pickup(ge.GetGameShop.GetWeapons[2], ge.GetGameMap.GetHero);
            ge.SetHeroPurse(ge.GetHeroPurse() - ge.GetGameShop.GetWeapons[2].GetCost);

            // Removes old weapon from the shop and adds a new one
            ge.GetGameShop.GetWeapons[2] = ge.GetGameShop.RandomWeapon();
            btnStock3.Text = "" + ge.GetStock3();

            // Update availability
            UpdateShopButtons();

            // The map and player stats labels are rendered
            lblMap.Text = "" + ge;

            tempHero = ge.GetMapHero();
            lblPlayerStats.Text = "" + tempHero;
        }

        /// <summary>
        /// Updates the text displayed on each shop button
        /// </summary>
        private void UpdateShopButtons()
        {
            // Gets the shop's stock
            tempWeapons = ge.GetShopStock();

            // Checks if the hero can afford any of the weapons
            if (ge.CheckAvailability(tempWeapons[0]))
            {
                btnStock1.Enabled = true;
            }
            else
            {
                btnStock1.Enabled = false;
            }

            if (ge.CheckAvailability(tempWeapons[1]))
            {
                btnStock2.Enabled = true;
            }
            else
            {
                btnStock2.Enabled = false;
            }

            if (ge.CheckAvailability(tempWeapons[2]))
            {
                btnStock3.Enabled = true;
            }
            else
            {
                btnStock3.Enabled = false;
            }
        }
    }
}
