using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LethalGas
{
    public partial class HighScoreScreen : UserControl
    {
        public HighScoreScreen()
        {
            InitializeComponent();
        }

        private void HighScoreScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Create an instance of the SecondScreen
                CharacterSelect cs = new CharacterSelect();
                cs.Location = new Point(this.Left, this.Top);
                // Add the User Control to the Form
                Form f = this.FindForm();
                f.Controls.Remove(this);
                f.Controls.Add(cs);
                cs.Focus();
            }
        }

        private void HighScoreScreen_Load(object sender, EventArgs e)
        {
            //outputs highscores in format: (Position). NAME level# score 
            for (int i = 0; i < Form1.highscoreList.Count; i++)
            {
                if ((i + 1) >= 10)
                {
                    top10Output.Text += (i + 1) + ".  " + Form1.highscoreList[i].name + "   level " + Form1.highscoreList[i].level + "   " + Form1.highscoreList[i].score + "\n \n";
                }
                else
                {
                    top10Output.Text += (i + 1) + ".   " + Form1.highscoreList[i].name + "   level " + Form1.highscoreList[i].level + "   " + Form1.highscoreList[i].score + "\n \n";
                }
            }
        }
    }
}
