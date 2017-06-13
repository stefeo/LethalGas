namespace LethalGas
{
    partial class loseScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scoreOutput = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Label();
            this.nameText3 = new System.Windows.Forms.Label();
            this.nameText2 = new System.Windows.Forms.Label();
            this.nameText1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreOutput
            // 
            this.scoreOutput.BackColor = System.Drawing.Color.Transparent;
            this.scoreOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreOutput.ForeColor = System.Drawing.Color.White;
            this.scoreOutput.Location = new System.Drawing.Point(113, 270);
            this.scoreOutput.Name = "scoreOutput";
            this.scoreOutput.Size = new System.Drawing.Size(794, 40);
            this.scoreOutput.TabIndex = 14;
            this.scoreOutput.Text = "You scored 0 points!";
            this.scoreOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playButton
            // 
            this.playButton.AutoSize = true;
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.White;
            this.playButton.Location = new System.Drawing.Point(188, 474);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(253, 55);
            this.playButton.TabIndex = 13;
            this.playButton.Text = "Play Again";
            // 
            // menuButton
            // 
            this.menuButton.AutoSize = true;
            this.menuButton.BackColor = System.Drawing.Color.Transparent;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.Location = new System.Drawing.Point(571, 474);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(262, 55);
            this.menuButton.TabIndex = 12;
            this.menuButton.Text = "Main Menu";
            // 
            // nameText3
            // 
            this.nameText3.AutoSize = true;
            this.nameText3.BackColor = System.Drawing.Color.Transparent;
            this.nameText3.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameText3.ForeColor = System.Drawing.Color.White;
            this.nameText3.Location = new System.Drawing.Point(571, 121);
            this.nameText3.Name = "nameText3";
            this.nameText3.Size = new System.Drawing.Size(109, 108);
            this.nameText3.TabIndex = 11;
            this.nameText3.Text = "A";
            this.nameText3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameText2
            // 
            this.nameText2.AutoSize = true;
            this.nameText2.BackColor = System.Drawing.Color.Transparent;
            this.nameText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameText2.ForeColor = System.Drawing.Color.White;
            this.nameText2.Location = new System.Drawing.Point(456, 121);
            this.nameText2.Name = "nameText2";
            this.nameText2.Size = new System.Drawing.Size(109, 108);
            this.nameText2.TabIndex = 10;
            this.nameText2.Text = "A";
            this.nameText2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameText1
            // 
            this.nameText1.AutoSize = true;
            this.nameText1.BackColor = System.Drawing.Color.Transparent;
            this.nameText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameText1.ForeColor = System.Drawing.Color.Red;
            this.nameText1.Location = new System.Drawing.Point(341, 121);
            this.nameText1.Name = "nameText1";
            this.nameText1.Size = new System.Drawing.Size(109, 108);
            this.nameText1.TabIndex = 9;
            this.nameText1.Text = "A";
            this.nameText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LethalGas.Properties.Resources.background;
            this.Controls.Add(this.scoreOutput);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.nameText3);
            this.Controls.Add(this.nameText2);
            this.Controls.Add(this.nameText1);
            this.Name = "loseScreen";
            this.Size = new System.Drawing.Size(1020, 650);
            this.Load += new System.EventHandler(this.loseScreen_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.loseScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.loseScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreOutput;
        private System.Windows.Forms.Label playButton;
        private System.Windows.Forms.Label menuButton;
        private System.Windows.Forms.Label nameText3;
        private System.Windows.Forms.Label nameText2;
        private System.Windows.Forms.Label nameText1;
    }
}
