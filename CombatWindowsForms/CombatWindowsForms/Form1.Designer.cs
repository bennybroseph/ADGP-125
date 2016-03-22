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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            ((System.ComponentModel.ISupportInitialize)(this.playerSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemySprite)).BeginInit();
            this.SuspendLayout();
            // 
            // playerSprite
            // 
            this.playerSprite.Image = ((System.Drawing.Image)(resources.GetObject("playerSprite.Image")));
            this.playerSprite.Location = new System.Drawing.Point(12, 12);
            this.playerSprite.Name = "playerSprite";
            this.playerSprite.Size = new System.Drawing.Size(188, 129);
            this.playerSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.playerSprite.TabIndex = 0;
            this.playerSprite.TabStop = false;
            // 
            // enemySprite
            // 
            this.enemySprite.Image = ((System.Drawing.Image)(resources.GetObject("enemySprite.Image")));
            this.enemySprite.Location = new System.Drawing.Point(446, 12);
            this.enemySprite.Name = "enemySprite";
            this.enemySprite.Size = new System.Drawing.Size(188, 129);
            this.enemySprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.enemySprite.TabIndex = 1;
            this.enemySprite.TabStop = false;
            // 
            // playerButtonMove1
            // 
            this.playerButtonMove1.Location = new System.Drawing.Point(118, 176);
            this.playerButtonMove1.Name = "playerButtonMove1";
            this.playerButtonMove1.Size = new System.Drawing.Size(82, 23);
            this.playerButtonMove1.TabIndex = 2;
            this.playerButtonMove1.Text = "button1";
            this.playerButtonMove1.UseVisualStyleBackColor = true;
            // 
            // playerMove1
            // 
            this.playerMove1.Enabled = false;
            this.playerMove1.Location = new System.Drawing.Point(12, 176);
            this.playerMove1.Name = "playerMove1";
            this.playerMove1.ReadOnly = true;
            this.playerMove1.Size = new System.Drawing.Size(100, 20);
            this.playerMove1.TabIndex = 3;
            this.playerMove1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerMove2
            // 
            this.playerMove2.Enabled = false;
            this.playerMove2.Location = new System.Drawing.Point(12, 202);
            this.playerMove2.Name = "playerMove2";
            this.playerMove2.ReadOnly = true;
            this.playerMove2.Size = new System.Drawing.Size(100, 20);
            this.playerMove2.TabIndex = 4;
            this.playerMove2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerMove3
            // 
            this.playerMove3.Enabled = false;
            this.playerMove3.Location = new System.Drawing.Point(12, 228);
            this.playerMove3.Name = "playerMove3";
            this.playerMove3.ReadOnly = true;
            this.playerMove3.Size = new System.Drawing.Size(100, 20);
            this.playerMove3.TabIndex = 5;
            this.playerMove3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerMove4
            // 
            this.playerMove4.Enabled = false;
            this.playerMove4.Location = new System.Drawing.Point(12, 254);
            this.playerMove4.Name = "playerMove4";
            this.playerMove4.ReadOnly = true;
            this.playerMove4.Size = new System.Drawing.Size(100, 20);
            this.playerMove4.TabIndex = 6;
            this.playerMove4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enemyMove4
            // 
            this.enemyMove4.Enabled = false;
            this.enemyMove4.Location = new System.Drawing.Point(534, 254);
            this.enemyMove4.Name = "enemyMove4";
            this.enemyMove4.ReadOnly = true;
            this.enemyMove4.Size = new System.Drawing.Size(100, 20);
            this.enemyMove4.TabIndex = 11;
            this.enemyMove4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enemyMove3
            // 
            this.enemyMove3.Enabled = false;
            this.enemyMove3.Location = new System.Drawing.Point(534, 228);
            this.enemyMove3.Name = "enemyMove3";
            this.enemyMove3.ReadOnly = true;
            this.enemyMove3.Size = new System.Drawing.Size(100, 20);
            this.enemyMove3.TabIndex = 10;
            this.enemyMove3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enemyMove2
            // 
            this.enemyMove2.Enabled = false;
            this.enemyMove2.Location = new System.Drawing.Point(534, 202);
            this.enemyMove2.Name = "enemyMove2";
            this.enemyMove2.ReadOnly = true;
            this.enemyMove2.Size = new System.Drawing.Size(100, 20);
            this.enemyMove2.TabIndex = 9;
            this.enemyMove2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enemyMove1
            // 
            this.enemyMove1.Enabled = false;
            this.enemyMove1.Location = new System.Drawing.Point(534, 176);
            this.enemyMove1.Name = "enemyMove1";
            this.enemyMove1.ReadOnly = true;
            this.enemyMove1.Size = new System.Drawing.Size(100, 20);
            this.enemyMove1.TabIndex = 8;
            this.enemyMove1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerButtonMove2
            // 
            this.playerButtonMove2.Location = new System.Drawing.Point(118, 200);
            this.playerButtonMove2.Name = "playerButtonMove2";
            this.playerButtonMove2.Size = new System.Drawing.Size(82, 23);
            this.playerButtonMove2.TabIndex = 12;
            this.playerButtonMove2.Text = "button2";
            this.playerButtonMove2.UseVisualStyleBackColor = true;
            // 
            // playerButtonMove3
            // 
            this.playerButtonMove3.Location = new System.Drawing.Point(118, 225);
            this.playerButtonMove3.Name = "playerButtonMove3";
            this.playerButtonMove3.Size = new System.Drawing.Size(82, 23);
            this.playerButtonMove3.TabIndex = 13;
            this.playerButtonMove3.Text = "button3";
            this.playerButtonMove3.UseVisualStyleBackColor = true;
            // 
            // playerHealthBar
            // 
            this.playerHealthBar.Location = new System.Drawing.Point(12, 147);
            this.playerHealthBar.Name = "playerHealthBar";
            this.playerHealthBar.Size = new System.Drawing.Size(188, 23);
            this.playerHealthBar.TabIndex = 14;
            // 
            // enemyHealthBar
            // 
            this.enemyHealthBar.Location = new System.Drawing.Point(446, 147);
            this.enemyHealthBar.Name = "enemyHealthBar";
            this.enemyHealthBar.Size = new System.Drawing.Size(188, 23);
            this.enemyHealthBar.TabIndex = 15;
            // 
            // playerButtonMove4
            // 
            this.playerButtonMove4.Location = new System.Drawing.Point(118, 251);
            this.playerButtonMove4.Name = "playerButtonMove4";
            this.playerButtonMove4.Size = new System.Drawing.Size(82, 23);
            this.playerButtonMove4.TabIndex = 16;
            this.playerButtonMove4.Text = "button4";
            this.playerButtonMove4.UseVisualStyleBackColor = true;
            // 
            // enemyStats
            // 
            this.enemyStats.Enabled = false;
            this.enemyStats.Location = new System.Drawing.Point(340, 12);
            this.enemyStats.Multiline = true;
            this.enemyStats.Name = "enemyStats";
            this.enemyStats.ReadOnly = true;
            this.enemyStats.Size = new System.Drawing.Size(100, 129);
            this.enemyStats.TabIndex = 18;
            // 
            // playerStats
            // 
            this.playerStats.Enabled = false;
            this.playerStats.Location = new System.Drawing.Point(206, 12);
            this.playerStats.Multiline = true;
            this.playerStats.Name = "playerStats";
            this.playerStats.ReadOnly = true;
            this.playerStats.Size = new System.Drawing.Size(100, 129);
            this.playerStats.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 300);
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
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.playerSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemySprite)).EndInit();
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
    }
}

