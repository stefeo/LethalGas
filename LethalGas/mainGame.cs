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
    public partial class mainGame : UserControl
    {
        public mainGame()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            
        }

        private void mainGame_Load(object sender, EventArgs e)
        {
            characters.Add(Properties.Resources.dylonIdle1);
            characters.Add(Properties.Resources.dylonIdle2);
            characters.Add(Properties.Resources.dylonFart);
        }

        bool right, left;
        int position;

        private void mainGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Application.Exit(); }
            if (e.KeyCode == Keys.Right) { right = true; }
        }
        private void mainGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = false; }
        }


        List<Image> characters = new List<Image>();
        int img;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(right == true)
            { position++;
                img++;

            }
            Refresh();
        }

       

        private void mainGame_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawImage(characters[2], new Rectangle(position, this.Height / 2 - 200, 200, 400));
        }
    }
}
