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
        public InstructionScreen()
        {
            InitializeComponent();
        }

        private void InstructionScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // Create an instance of the SecondScreen
                mainGame cs = new mainGame();
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
                CharacterSelect cs = new CharacterSelect();
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
