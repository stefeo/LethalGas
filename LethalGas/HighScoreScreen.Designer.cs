﻿namespace LethalGas
{
    partial class HighScoreScreen
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
            this.top10Output = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // top10Output
            // 
            this.top10Output.BackColor = System.Drawing.Color.Transparent;
            this.top10Output.Font = new System.Drawing.Font("Outline Pixel7 Solid", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top10Output.ForeColor = System.Drawing.Color.White;
            this.top10Output.Location = new System.Drawing.Point(204, 168);
            this.top10Output.Name = "top10Output";
            this.top10Output.Size = new System.Drawing.Size(608, 401);
            this.top10Output.TabIndex = 2;
            // 
            // HighScoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LethalGas.Properties.Resources.highScoreScreen;
            this.Controls.Add(this.top10Output);
            this.Name = "HighScoreScreen";
            this.Size = new System.Drawing.Size(1020, 650);
            this.Load += new System.EventHandler(this.HighScoreScreen_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HighScoreScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label top10Output;
    }
}
