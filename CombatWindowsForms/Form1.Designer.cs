namespace CombatWindowsForms
{
    partial class Form1
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
            this.playerSprite = new System.Windows.Forms.PictureBox();
            this.enemySprite = new System.Windows.Forms.PictureBox();
            this.playerButtonMove1 = new System.Windows.Forms.Button();
            this.playerMove1 = new System.Windows.Forms.TextBox();
            this.playerMove2 = new System.Windows.Forms.TextBox();
            this.playerMove3 = new System.Windows.Forms.TextBox();
            this.playerMove4 = new System.Windows.Forms.TextBox();
            this.enemyMove4 = new System.Windows.Forms.TextBox();
            this.enemyMove3 = new System.Windows.Forms.TextBox();
            this.enemyMove2 = new System.Windows.Forms.TextBox();
            this.enemyMove1 = new System.Windows.Forms.TextBox();
            this.playerButtonMove2 = new System.Windows.Forms.Button();
            this.playerButtonMove3 = new System.Windows.Forms.Button();
            this.playerHealthBar = new System.Windows.Forms.ProgressBar();
            this.enemyHealthBar = new System.Windows.Forms.ProgressBar();
            this.playerButtonMove4 = new System.Windows.Forms.Button();
            this.enemyStats = new System.Windows.Forms.TextBox();
            this.playerStats = new System.Windows.Forms.TextBox();
            this.playerUnitIndicator2 = new System.Windows.Forms.RadioButton();
            this.playerUnitIndicator3 = new System.Windows.Forms.RadioButton();
            this.playerUnitIndicator4 = new System.Windows.Forms.RadioButton();
            this.playerUnitIndicator5 = new System.Windows.Forms.RadioButton();
            this.playerUnitIndicator6 = new System.Windows.Forms.RadioButton();
            this.playerName = new System.Windows.Forms.TextBox();
            this.enemyName = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.combatLogBox = new System.Windows.Forms.TextBox();
            this.playerUnitIndicator1 = new System.Windows.Forms.RadioButton();
            this.playerIndicatorGroupBox = new System.Windows.Forms.GroupBox();
            this.enemyIndicatorGroupBox = new System.Windows.Forms.GroupBox();
            this.enemyUnitIndicator6 = new System.Windows.Forms.RadioButton();
            this.enemyUnitIndicator1 = new System.Windows.Forms.RadioButton();
            this.enemyUnitIndicator2 = new System.Windows.Forms.RadioButton();
            this.enemyUnitIndicator3 = new System.Windows.Forms.RadioButton();
            this.enemyUnitIndicator4 = new System.Windows.Forms.RadioButton();
            this.enemyUnitIndicator5 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.playerSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemySprite)).BeginInit();
            this.playerIndicatorGroupBox.SuspendLayout();
            this.enemyIndicatorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerSprite
            // 
            this.playerSprite.Location = new System.Drawing.Point(12, 74);
            this.playerSprite.Name = "playerSprite";
            this.playerSprite.Size = new System.Drawing.Size(188, 129);
            this.playerSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.playerSprite.TabIndex = 0;
            this.playerSprite.TabStop = false;
            // 
            // enemySprite
            // 
            this.enemySprite.Location = new System.Drawing.Point(709, 74);
            this.enemySprite.Name = "enemySprite";
            this.enemySprite.Size = new System.Drawing.Size(188, 129);
            this.enemySprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.enemySprite.TabIndex = 1;
            this.enemySprite.TabStop = false;
            // 
            // playerButtonMove1
            // 
            this.playerButtonMove1.Location = new System.Drawing.Point(206, 235);
            this.playerButtonMove1.Name = "playerButtonMove1";
            this.playerButtonMove1.Size = new System.Drawing.Size(100, 23);
            this.playerButtonMove1.TabIndex = 2;
            this.playerButtonMove1.Text = "\r\n\r\n";
            this.playerButtonMove1.UseVisualStyleBackColor = true;
            this.playerButtonMove1.Click += new System.EventHandler(this.playerButtonMove1_Click);
            // 
            // playerMove1
            // 
            this.playerMove1.Location = new System.Drawing.Point(12, 238);
            this.playerMove1.Name = "playerMove1";
            this.playerMove1.ReadOnly = true;
            this.playerMove1.Size = new System.Drawing.Size(188, 20);
            this.playerMove1.TabIndex = 3;
            this.playerMove1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerMove2
            // 
            this.playerMove2.Location = new System.Drawing.Point(12, 264);
            this.playerMove2.Name = "playerMove2";
            this.playerMove2.ReadOnly = true;
            this.playerMove2.Size = new System.Drawing.Size(188, 20);
            this.playerMove2.TabIndex = 4;
            this.playerMove2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerMove3
            // 
            this.playerMove3.Location = new System.Drawing.Point(12, 290);
            this.playerMove3.Name = "playerMove3";
            this.playerMove3.ReadOnly = true;
            this.playerMove3.Size = new System.Drawing.Size(188, 20);
            this.playerMove3.TabIndex = 5;
            this.playerMove3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerMove4
            // 
            this.playerMove4.Location = new System.Drawing.Point(12, 316);
            this.playerMove4.Name = "playerMove4";
            this.playerMove4.ReadOnly = true;
            this.playerMove4.Size = new System.Drawing.Size(188, 20);
            this.playerMove4.TabIndex = 6;
            this.playerMove4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enemyMove4
            // 
            this.enemyMove4.Location = new System.Drawing.Point(709, 316);
            this.enemyMove4.Name = "enemyMove4";
            this.enemyMove4.ReadOnly = true;
            this.enemyMove4.Size = new System.Drawing.Size(188, 20);
            this.enemyMove4.TabIndex = 11;
            this.enemyMove4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enemyMove3
            // 
            this.enemyMove3.Location = new System.Drawing.Point(709, 290);
            this.enemyMove3.Name = "enemyMove3";
            this.enemyMove3.ReadOnly = true;
            this.enemyMove3.Size = new System.Drawing.Size(188, 20);
            this.enemyMove3.TabIndex = 10;
            this.enemyMove3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enemyMove2
            // 
            this.enemyMove2.Location = new System.Drawing.Point(709, 264);
            this.enemyMove2.Name = "enemyMove2";
            this.enemyMove2.ReadOnly = true;
            this.enemyMove2.Size = new System.Drawing.Size(188, 20);
            this.enemyMove2.TabIndex = 9;
            this.enemyMove2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enemyMove1
            // 
            this.enemyMove1.Location = new System.Drawing.Point(709, 238);
            this.enemyMove1.Name = "enemyMove1";
            this.enemyMove1.ReadOnly = true;
            this.enemyMove1.Size = new System.Drawing.Size(188, 20);
            this.enemyMove1.TabIndex = 8;
            this.enemyMove1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerButtonMove2
            // 
            this.playerButtonMove2.Location = new System.Drawing.Point(206, 261);
            this.playerButtonMove2.Name = "playerButtonMove2";
            this.playerButtonMove2.Size = new System.Drawing.Size(100, 23);
            this.playerButtonMove2.TabIndex = 12;
            this.playerButtonMove2.Text = "\r\n\r\n";
            this.playerButtonMove2.UseVisualStyleBackColor = true;
            this.playerButtonMove2.Click += new System.EventHandler(this.playerButtonMove2_Click);
            // 
            // playerButtonMove3
            // 
            this.playerButtonMove3.Location = new System.Drawing.Point(206, 287);
            this.playerButtonMove3.Name = "playerButtonMove3";
            this.playerButtonMove3.Size = new System.Drawing.Size(100, 23);
            this.playerButtonMove3.TabIndex = 13;
            this.playerButtonMove3.Text = "\r\n\r\n";
            this.playerButtonMove3.UseVisualStyleBackColor = true;
            this.playerButtonMove3.Click += new System.EventHandler(this.playerButtonMove3_Click);
            // 
            // playerHealthBar
            // 
            this.playerHealthBar.Location = new System.Drawing.Point(12, 209);
            this.playerHealthBar.Name = "playerHealthBar";
            this.playerHealthBar.Size = new System.Drawing.Size(188, 23);
            this.playerHealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.playerHealthBar.TabIndex = 14;
            this.playerHealthBar.Value = 100;
            // 
            // enemyHealthBar
            // 
            this.enemyHealthBar.Location = new System.Drawing.Point(709, 209);
            this.enemyHealthBar.Name = "enemyHealthBar";
            this.enemyHealthBar.Size = new System.Drawing.Size(188, 23);
            this.enemyHealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.enemyHealthBar.TabIndex = 15;
            this.enemyHealthBar.Value = 100;
            // 
            // playerButtonMove4
            // 
            this.playerButtonMove4.Location = new System.Drawing.Point(206, 313);
            this.playerButtonMove4.Name = "playerButtonMove4";
            this.playerButtonMove4.Size = new System.Drawing.Size(100, 23);
            this.playerButtonMove4.TabIndex = 16;
            this.playerButtonMove4.Text = "\r\n\r\n";
            this.playerButtonMove4.UseVisualStyleBackColor = true;
            this.playerButtonMove4.Click += new System.EventHandler(this.playerButtonMove4_Click);
            // 
            // enemyStats
            // 
            this.enemyStats.Location = new System.Drawing.Point(603, 74);
            this.enemyStats.Multiline = true;
            this.enemyStats.Name = "enemyStats";
            this.enemyStats.ReadOnly = true;
            this.enemyStats.Size = new System.Drawing.Size(100, 129);
            this.enemyStats.TabIndex = 18;
            // 
            // playerStats
            // 
            this.playerStats.Location = new System.Drawing.Point(206, 74);
            this.playerStats.Multiline = true;
            this.playerStats.Name = "playerStats";
            this.playerStats.ReadOnly = true;
            this.playerStats.Size = new System.Drawing.Size(100, 129);
            this.playerStats.TabIndex = 19;
            // 
            // playerUnitIndicator2
            // 
            this.playerUnitIndicator2.AutoSize = true;
            this.playerUnitIndicator2.Enabled = false;
            this.playerUnitIndicator2.Location = new System.Drawing.Point(34, 12);
            this.playerUnitIndicator2.Name = "playerUnitIndicator2";
            this.playerUnitIndicator2.Size = new System.Drawing.Size(14, 13);
            this.playerUnitIndicator2.TabIndex = 21;
            this.playerUnitIndicator2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playerUnitIndicator2.UseVisualStyleBackColor = true;
            // 
            // playerUnitIndicator3
            // 
            this.playerUnitIndicator3.AutoSize = true;
            this.playerUnitIndicator3.Enabled = false;
            this.playerUnitIndicator3.Location = new System.Drawing.Point(68, 12);
            this.playerUnitIndicator3.Name = "playerUnitIndicator3";
            this.playerUnitIndicator3.Size = new System.Drawing.Size(14, 13);
            this.playerUnitIndicator3.TabIndex = 22;
            this.playerUnitIndicator3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playerUnitIndicator3.UseVisualStyleBackColor = true;
            // 
            // playerUnitIndicator4
            // 
            this.playerUnitIndicator4.AutoSize = true;
            this.playerUnitIndicator4.Enabled = false;
            this.playerUnitIndicator4.Location = new System.Drawing.Point(103, 12);
            this.playerUnitIndicator4.Name = "playerUnitIndicator4";
            this.playerUnitIndicator4.Size = new System.Drawing.Size(14, 13);
            this.playerUnitIndicator4.TabIndex = 23;
            this.playerUnitIndicator4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playerUnitIndicator4.UseVisualStyleBackColor = true;
            // 
            // playerUnitIndicator5
            // 
            this.playerUnitIndicator5.AutoSize = true;
            this.playerUnitIndicator5.Enabled = false;
            this.playerUnitIndicator5.Location = new System.Drawing.Point(139, 12);
            this.playerUnitIndicator5.Name = "playerUnitIndicator5";
            this.playerUnitIndicator5.Size = new System.Drawing.Size(14, 13);
            this.playerUnitIndicator5.TabIndex = 24;
            this.playerUnitIndicator5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playerUnitIndicator5.UseVisualStyleBackColor = true;
            // 
            // playerUnitIndicator6
            // 
            this.playerUnitIndicator6.AutoSize = true;
            this.playerUnitIndicator6.Enabled = false;
            this.playerUnitIndicator6.Location = new System.Drawing.Point(171, 12);
            this.playerUnitIndicator6.Name = "playerUnitIndicator6";
            this.playerUnitIndicator6.Size = new System.Drawing.Size(14, 13);
            this.playerUnitIndicator6.TabIndex = 25;
            this.playerUnitIndicator6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playerUnitIndicator6.UseVisualStyleBackColor = true;
            // 
            // playerName
            // 
            this.playerName.Location = new System.Drawing.Point(12, 48);
            this.playerName.Name = "playerName";
            this.playerName.ReadOnly = true;
            this.playerName.Size = new System.Drawing.Size(188, 20);
            this.playerName.TabIndex = 32;
            this.playerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enemyName
            // 
            this.enemyName.Location = new System.Drawing.Point(709, 48);
            this.enemyName.Name = "enemyName";
            this.enemyName.ReadOnly = true;
            this.enemyName.Size = new System.Drawing.Size(188, 20);
            this.enemyName.TabIndex = 33;
            this.enemyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 369);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 34;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(797, 369);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(100, 23);
            this.loadButton.TabIndex = 35;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // combatLogBox
            // 
            this.combatLogBox.Location = new System.Drawing.Point(312, 9);
            this.combatLogBox.Multiline = true;
            this.combatLogBox.Name = "combatLogBox";
            this.combatLogBox.ReadOnly = true;
            this.combatLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.combatLogBox.Size = new System.Drawing.Size(285, 194);
            this.combatLogBox.TabIndex = 36;
            // 
            // playerUnitIndicator1
            // 
            this.playerUnitIndicator1.AutoSize = true;
            this.playerUnitIndicator1.Enabled = false;
            this.playerUnitIndicator1.Location = new System.Drawing.Point(3, 12);
            this.playerUnitIndicator1.Name = "playerUnitIndicator1";
            this.playerUnitIndicator1.Size = new System.Drawing.Size(14, 13);
            this.playerUnitIndicator1.TabIndex = 20;
            this.playerUnitIndicator1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playerUnitIndicator1.UseVisualStyleBackColor = true;
            // 
            // playerIndicatorGroupBox
            // 
            this.playerIndicatorGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.playerIndicatorGroupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playerIndicatorGroupBox.Controls.Add(this.playerUnitIndicator6);
            this.playerIndicatorGroupBox.Controls.Add(this.playerUnitIndicator1);
            this.playerIndicatorGroupBox.Controls.Add(this.playerUnitIndicator2);
            this.playerIndicatorGroupBox.Controls.Add(this.playerUnitIndicator3);
            this.playerIndicatorGroupBox.Controls.Add(this.playerUnitIndicator4);
            this.playerIndicatorGroupBox.Controls.Add(this.playerUnitIndicator5);
            this.playerIndicatorGroupBox.ForeColor = System.Drawing.Color.Transparent;
            this.playerIndicatorGroupBox.Location = new System.Drawing.Point(12, 9);
            this.playerIndicatorGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.playerIndicatorGroupBox.Name = "playerIndicatorGroupBox";
            this.playerIndicatorGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.playerIndicatorGroupBox.Size = new System.Drawing.Size(188, 33);
            this.playerIndicatorGroupBox.TabIndex = 0;
            this.playerIndicatorGroupBox.TabStop = false;
            // 
            // enemyIndicatorGroupBox
            // 
            this.enemyIndicatorGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.enemyIndicatorGroupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.enemyIndicatorGroupBox.Controls.Add(this.enemyUnitIndicator6);
            this.enemyIndicatorGroupBox.Controls.Add(this.enemyUnitIndicator1);
            this.enemyIndicatorGroupBox.Controls.Add(this.enemyUnitIndicator2);
            this.enemyIndicatorGroupBox.Controls.Add(this.enemyUnitIndicator3);
            this.enemyIndicatorGroupBox.Controls.Add(this.enemyUnitIndicator4);
            this.enemyIndicatorGroupBox.Controls.Add(this.enemyUnitIndicator5);
            this.enemyIndicatorGroupBox.ForeColor = System.Drawing.Color.Transparent;
            this.enemyIndicatorGroupBox.Location = new System.Drawing.Point(709, 9);
            this.enemyIndicatorGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.enemyIndicatorGroupBox.Name = "enemyIndicatorGroupBox";
            this.enemyIndicatorGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.enemyIndicatorGroupBox.Size = new System.Drawing.Size(188, 33);
            this.enemyIndicatorGroupBox.TabIndex = 26;
            this.enemyIndicatorGroupBox.TabStop = false;
            // 
            // enemyUnitIndicator6
            // 
            this.enemyUnitIndicator6.AutoSize = true;
            this.enemyUnitIndicator6.Enabled = false;
            this.enemyUnitIndicator6.Location = new System.Drawing.Point(171, 12);
            this.enemyUnitIndicator6.Name = "enemyUnitIndicator6";
            this.enemyUnitIndicator6.Size = new System.Drawing.Size(14, 13);
            this.enemyUnitIndicator6.TabIndex = 25;
            this.enemyUnitIndicator6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enemyUnitIndicator6.UseVisualStyleBackColor = true;
            // 
            // enemyUnitIndicator1
            // 
            this.enemyUnitIndicator1.AutoSize = true;
            this.enemyUnitIndicator1.Enabled = false;
            this.enemyUnitIndicator1.Location = new System.Drawing.Point(3, 12);
            this.enemyUnitIndicator1.Name = "enemyUnitIndicator1";
            this.enemyUnitIndicator1.Size = new System.Drawing.Size(14, 13);
            this.enemyUnitIndicator1.TabIndex = 20;
            this.enemyUnitIndicator1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enemyUnitIndicator1.UseVisualStyleBackColor = true;
            // 
            // enemyUnitIndicator2
            // 
            this.enemyUnitIndicator2.AutoSize = true;
            this.enemyUnitIndicator2.Enabled = false;
            this.enemyUnitIndicator2.Location = new System.Drawing.Point(34, 12);
            this.enemyUnitIndicator2.Name = "enemyUnitIndicator2";
            this.enemyUnitIndicator2.Size = new System.Drawing.Size(14, 13);
            this.enemyUnitIndicator2.TabIndex = 21;
            this.enemyUnitIndicator2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enemyUnitIndicator2.UseVisualStyleBackColor = true;
            // 
            // enemyUnitIndicator3
            // 
            this.enemyUnitIndicator3.AutoSize = true;
            this.enemyUnitIndicator3.Enabled = false;
            this.enemyUnitIndicator3.Location = new System.Drawing.Point(68, 12);
            this.enemyUnitIndicator3.Name = "enemyUnitIndicator3";
            this.enemyUnitIndicator3.Size = new System.Drawing.Size(14, 13);
            this.enemyUnitIndicator3.TabIndex = 22;
            this.enemyUnitIndicator3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enemyUnitIndicator3.UseVisualStyleBackColor = true;
            // 
            // enemyUnitIndicator4
            // 
            this.enemyUnitIndicator4.AutoSize = true;
            this.enemyUnitIndicator4.Enabled = false;
            this.enemyUnitIndicator4.Location = new System.Drawing.Point(103, 12);
            this.enemyUnitIndicator4.Name = "enemyUnitIndicator4";
            this.enemyUnitIndicator4.Size = new System.Drawing.Size(14, 13);
            this.enemyUnitIndicator4.TabIndex = 23;
            this.enemyUnitIndicator4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enemyUnitIndicator4.UseVisualStyleBackColor = true;
            // 
            // enemyUnitIndicator5
            // 
            this.enemyUnitIndicator5.AutoSize = true;
            this.enemyUnitIndicator5.Enabled = false;
            this.enemyUnitIndicator5.Location = new System.Drawing.Point(139, 12);
            this.enemyUnitIndicator5.Name = "enemyUnitIndicator5";
            this.enemyUnitIndicator5.Size = new System.Drawing.Size(14, 13);
            this.enemyUnitIndicator5.TabIndex = 24;
            this.enemyUnitIndicator5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enemyUnitIndicator5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 404);
            this.Controls.Add(this.enemyIndicatorGroupBox);
            this.Controls.Add(this.combatLogBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.enemyName);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.playerStats);
            this.Controls.Add(this.enemyStats);
            this.Controls.Add(this.playerButtonMove4);
            this.Controls.Add(this.enemyHealthBar);
            this.Controls.Add(this.playerHealthBar);
            this.Controls.Add(this.playerButtonMove3);
            this.Controls.Add(this.playerButtonMove2);
            this.Controls.Add(this.enemyMove4);
            this.Controls.Add(this.enemyMove3);
            this.Controls.Add(this.enemyMove2);
            this.Controls.Add(this.enemyMove1);
            this.Controls.Add(this.playerMove4);
            this.Controls.Add(this.playerMove3);
            this.Controls.Add(this.playerMove2);
            this.Controls.Add(this.playerMove1);
            this.Controls.Add(this.playerButtonMove1);
            this.Controls.Add(this.enemySprite);
            this.Controls.Add(this.playerSprite);
            this.Controls.Add(this.playerIndicatorGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.playerSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemySprite)).EndInit();
            this.playerIndicatorGroupBox.ResumeLayout(false);
            this.playerIndicatorGroupBox.PerformLayout();
            this.enemyIndicatorGroupBox.ResumeLayout(false);
            this.enemyIndicatorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox playerSprite;
        private System.Windows.Forms.PictureBox enemySprite;
        private System.Windows.Forms.Button playerButtonMove1;
        private System.Windows.Forms.TextBox playerMove1;
        private System.Windows.Forms.TextBox playerMove2;
        private System.Windows.Forms.TextBox playerMove3;
        private System.Windows.Forms.TextBox playerMove4;
        private System.Windows.Forms.TextBox enemyMove4;
        private System.Windows.Forms.TextBox enemyMove3;
        private System.Windows.Forms.TextBox enemyMove2;
        private System.Windows.Forms.TextBox enemyMove1;
        private System.Windows.Forms.Button playerButtonMove2;
        private System.Windows.Forms.Button playerButtonMove3;
        private System.Windows.Forms.ProgressBar playerHealthBar;
        private System.Windows.Forms.ProgressBar enemyHealthBar;
        private System.Windows.Forms.Button playerButtonMove4;
        private System.Windows.Forms.TextBox enemyStats;
        private System.Windows.Forms.TextBox playerStats;
        private System.Windows.Forms.RadioButton playerUnitIndicator2;
        private System.Windows.Forms.RadioButton playerUnitIndicator3;
        private System.Windows.Forms.RadioButton playerUnitIndicator4;
        private System.Windows.Forms.RadioButton playerUnitIndicator5;
        private System.Windows.Forms.RadioButton playerUnitIndicator6;
        private System.Windows.Forms.TextBox playerName;
        private System.Windows.Forms.TextBox enemyName;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox combatLogBox;
        private System.Windows.Forms.RadioButton playerUnitIndicator1;
        private System.Windows.Forms.GroupBox playerIndicatorGroupBox;
        private System.Windows.Forms.GroupBox enemyIndicatorGroupBox;
        private System.Windows.Forms.RadioButton enemyUnitIndicator6;
        private System.Windows.Forms.RadioButton enemyUnitIndicator1;
        private System.Windows.Forms.RadioButton enemyUnitIndicator2;
        private System.Windows.Forms.RadioButton enemyUnitIndicator3;
        private System.Windows.Forms.RadioButton enemyUnitIndicator4;
        private System.Windows.Forms.RadioButton enemyUnitIndicator5;
    }
}

