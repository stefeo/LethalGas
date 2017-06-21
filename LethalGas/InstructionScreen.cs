using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LethalGas
{
    public partial class InstructionScreen : UserControl
    {
        public bool nextEnabled = false;

        public InstructionScreen()
        {
            InitializeComponent();
            index = 0;
            pictureBox1.Image = null;
        }

        int index;
        private void InstructionScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (index == 0) { pictureBox1.Image = Properties.Resources.InstructionsSTART; }
                if (index == 1) { pictureBox1.Image = Properties.Resources.Instructions2; }
                if (index == 2)
                {
                    nextEnabled = true;
                }
                index++;
            }

            if (e.KeyCode == Keys.Escape)
            {
                    // Create an instance of the SecondScreen
                    HighScoreScreen cs = new HighScoreScreen();
                    cs.Location = new Point(this.Left, this.Top);
                    // Add the User Control to the Form
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    f.Controls.Add(cs);
                    cs.Focus();
            }
        }

        private void InstructionScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && nextEnabled)
            {
                Form1.titleMusic.Stop();
                // Create an instance of the SecondScreen
                mainGame cs = new mainGame();
                cs.Location = new Point(this.Left, this.Top);
                // Add the User Control to the Form
                Form f = this.FindForm();
                f.Controls.Remove(this);
                f.Controls.Add(cs);
                cs.Focus();
            }
        }
    }
}
