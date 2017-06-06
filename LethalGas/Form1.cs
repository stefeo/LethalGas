using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace LethalGas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static SoundPlayer mainGameMusic = new SoundPlayer(Properties.Resources.funky_beat);

        private void Form1_Load(object sender, EventArgs e)
        {

            // Create an instance of the MainScreen
            MainScreen ms = new MainScreen();

            // Add the User Control to the Form
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           // if (e.KeyCode == Keys.Escape) { this.Close(); }
        }

    }
}
