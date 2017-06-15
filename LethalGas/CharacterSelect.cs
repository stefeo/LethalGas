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
    public partial class CharacterSelect : UserControl
    {
        public CharacterSelect()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Focus();
        }

        int index;
        private void CharacterSelect_Load(object sender, EventArgs e)
        {
            characters.Add(Properties.Resources.dylonIdle1);
            characters.Add(Properties.Resources.dylonIdle2);
            characters.Add(Properties.Resources.dylonFart);
        }

        private void CharacterSelect_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if(index < characters.Count - 1) { index++; }
                else { index = 0; }
            }
            if (e.KeyCode == Keys.Left)
            {
                if(index > 0) { index--; }
                else { index = 2; }
            }
            if(e.KeyCode == Keys.Space)
            {
                // Create an instance of the SecondScreen
                InstructionScreen cs = new InstructionScreen();
                cs.Location = new Point(this.Left, this.Top);
                // Add the User Control to the Form
                Form f = this.FindForm();
                f.Controls.Remove(this);
                f.Controls.Add(cs);
                cs.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                // Create an instance of the SecondScreen
                MainScreen ms = new MainScreen();
                ms.Location = new Point(this.Left, this.Top);
                // Add the User Control to the Form
                Form f = this.FindForm();
                f.Controls.Remove(this);
                f.Controls.Add(ms);
                ms.Focus();
            }
            if(e.KeyCode == Keys.M)
            {
                HighScoreScreen ms = new HighScoreScreen();
                ms.Location = new Point(this.Left, this.Top);
                // Add the User Control to the Form
                Form f = this.FindForm();
                f.Controls.Remove(this);
                f.Controls.Add(ms);
                ms.Focus();
            }
            Refresh();
        }

        List<Image> characters = new List<Image>();
        SolidBrush boxBrush = new SolidBrush(Color.White);
        private void CharacterSelect_Paint(object sender, PaintEventArgs e)
        {
            /*e.Graphics.FillRectangle(boxBrush, this.Width / 4 - 50, this.Height / 2 - 100, 100, 200);
            e.Graphics.FillRectangle(boxBrush, this.Width / 2 - 100, this.Height / 2 - 200, 200, 400);
            e.Graphics.FillRectangle(boxBrush, this.Width / 4 * 3 - 50, this.Height / 2 - 100, 100, 200);
            */
            if (index == 0)
            {
                e.Graphics.DrawImage(characters[1], new Rectangle(this.Width / 4 - 50, this.Height / 2 - 100, 100, 200));
                e.Graphics.DrawImage(characters[2], new Rectangle(this.Width / 2 - 100, this.Height / 2 - 200, 200, 400));
                e.Graphics.DrawImage(characters[0], new Rectangle(this.Width / 4 * 3 -50, this.Height / 2 - 100, 100, 200));
            }
            if (index == 1)
            {
                e.Graphics.DrawImage(characters[0], new Rectangle(this.Width / 4 -50, this.Height / 2 - 100, 100, 200));
                e.Graphics.DrawImage(characters[1], new Rectangle(this.Width / 2 - 100, this.Height / 2 - 200, 200, 400));
                e.Graphics.DrawImage(characters[2], new Rectangle(this.Width / 4 * 3-50, this.Height / 2 - 100, 100, 200));
            }
            if (index == 2)
            {
                e.Graphics.DrawImage(characters[2], new Rectangle(this.Width / 4 -50, this.Height / 2 - 100, 100, 200));
                e.Graphics.DrawImage(characters[0], new Rectangle(this.Width / 2 - 100, this.Height / 2 - 200, 200, 400));
                e.Graphics.DrawImage(characters[1], new Rectangle(this.Width / 4 * 3 -50, this.Height / 2 - 100, 100, 200));
            }
           
        }

   
    }
}
