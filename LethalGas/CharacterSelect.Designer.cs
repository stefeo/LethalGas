namespace LethalGas
{
    partial class CharacterSelect
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
            this.SuspendLayout();
            // 
            // CharacterSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LethalGas.Properties.Resources.background;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CharacterSelect";
            this.Size = new System.Drawing.Size(1020, 650);
            this.Load += new System.EventHandler(this.CharacterSelect_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CharacterSelect_Paint);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.CharacterSelect_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
