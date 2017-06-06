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
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        private void MainScreen_Load(object sender, EventArgs e)
        {
            Focus();
        }

        private void MainScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Application.Exit(); }
            else
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
