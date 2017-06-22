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
                index++;
                instructionChange();
                if (index == 3)
                {
                    nextEnabled = true;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                index--;
                instructionChange();
                if (index == -1)
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
        }

        private void instructionChange()
        {
            if (index == 0) { pictureBox1.Image = null; label2.Text = "You are dangerously flatulent from that taco fiesta last night, and you must relieve your gas secretly. Make sure nobody notices you farting, although you will earn points when others smell your farts. Don't let your fart meter reach the max, or you will recieve a stinky taco surprise."; }
            if (index == 1) { pictureBox1.Image = Properties.Resources.InstructionsSTART; label2.Text = "Drop farts on people to earn points. Keep a safe distance from your target, or you will get caught."; }
            if (index == 2) { pictureBox1.Image = Properties.Resources.Instructions2; label2.Text = "Don't let your fart meter reach the limit, or else you will have to perform emergency release."; }
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
