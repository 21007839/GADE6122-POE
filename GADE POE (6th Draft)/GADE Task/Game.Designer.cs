
namespace GADE_Task
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMap = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.lblPlayerStats = new System.Windows.Forms.Label();
            this.cmbTarget = new System.Windows.Forms.ComboBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.lblTarget = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnStock2 = new System.Windows.Forms.Button();
            this.btnStock1 = new System.Windows.Forms.Button();
            this.btnStock3 = new System.Windows.Forms.Button();
            this.lblShop = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMap.Location = new System.Drawing.Point(404, 25);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(180, 25);
            this.lblMap.TabIndex = 0;
            this.lblMap.Text = "<insert map>";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(10, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(388, 31);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Slayer of the Goblins:";
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUp.Location = new System.Drawing.Point(99, 261);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(58, 46);
            this.btnUp.TabIndex = 9;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDown.Location = new System.Drawing.Point(99, 366);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(58, 46);
            this.btnDown.TabIndex = 10;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLeft.Location = new System.Drawing.Point(35, 314);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(58, 46);
            this.btnLeft.TabIndex = 11;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRight.Location = new System.Drawing.Point(163, 314);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(58, 46);
            this.btnRight.TabIndex = 12;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // lblPlayerStats
            // 
            this.lblPlayerStats.AutoSize = true;
            this.lblPlayerStats.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerStats.Location = new System.Drawing.Point(10, 60);
            this.lblPlayerStats.Name = "lblPlayerStats";
            this.lblPlayerStats.Size = new System.Drawing.Size(178, 22);
            this.lblPlayerStats.TabIndex = 13;
            this.lblPlayerStats.Text = "<insert stats>";
            // 
            // cmbTarget
            // 
            this.cmbTarget.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbTarget.FormattingEnabled = true;
            this.cmbTarget.IntegralHeight = false;
            this.cmbTarget.Location = new System.Drawing.Point(12, 467);
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(632, 28);
            this.cmbTarget.TabIndex = 14;
            // 
            // btnAttack
            // 
            this.btnAttack.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAttack.Location = new System.Drawing.Point(12, 501);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(632, 40);
            this.btnAttack.TabIndex = 15;
            this.btnAttack.Text = "Attack Targeted Enemy";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTarget.Location = new System.Drawing.Point(10, 429);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(236, 25);
            this.lblTarget.TabIndex = 16;
            this.lblTarget.Text = "Target an Enemy:";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(12, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(330, 33);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save Game";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.Location = new System.Drawing.Point(348, 548);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(296, 33);
            this.btnLoad.TabIndex = 18;
            this.btnLoad.Text = "Load Game";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnStock2
            // 
            this.btnStock2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStock2.Location = new System.Drawing.Point(662, 507);
            this.btnStock2.Name = "btnStock2";
            this.btnStock2.Size = new System.Drawing.Size(284, 34);
            this.btnStock2.TabIndex = 19;
            this.btnStock2.Text = "<insert stock>";
            this.btnStock2.UseVisualStyleBackColor = true;
            this.btnStock2.Click += new System.EventHandler(this.btnStock2_Click);
            // 
            // btnStock1
            // 
            this.btnStock1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStock1.Location = new System.Drawing.Point(662, 467);
            this.btnStock1.Name = "btnStock1";
            this.btnStock1.Size = new System.Drawing.Size(284, 34);
            this.btnStock1.TabIndex = 20;
            this.btnStock1.Text = "<insert stock>";
            this.btnStock1.UseVisualStyleBackColor = true;
            this.btnStock1.Click += new System.EventHandler(this.btnStock1_Click);
            // 
            // btnStock3
            // 
            this.btnStock3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStock3.Location = new System.Drawing.Point(662, 547);
            this.btnStock3.Name = "btnStock3";
            this.btnStock3.Size = new System.Drawing.Size(284, 34);
            this.btnStock3.TabIndex = 21;
            this.btnStock3.Text = "<insert stock>";
            this.btnStock3.UseVisualStyleBackColor = true;
            this.btnStock3.Click += new System.EventHandler(this.btnStock3_Click);
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblShop.Location = new System.Drawing.Point(662, 429);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(166, 25);
            this.lblShop.TabIndex = 22;
            this.lblShop.Text = "Shop Stock:";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 591);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.btnStock3);
            this.Controls.Add(this.btnStock1);
            this.Controls.Add(this.btnStock2);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.cmbTarget);
            this.Controls.Add(this.lblPlayerStats);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMap);
            this.Name = "Game";
            this.Text = "Game Screen";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label lblPlayerStats;
        private System.Windows.Forms.ComboBox cmbTarget;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnStock2;
        private System.Windows.Forms.Button btnStock1;
        private System.Windows.Forms.Button btnStock3;
        private System.Windows.Forms.Label lblShop;
    }
}