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
            Form1.mainGameMusic.Play();
        }

        private void mainGame_Load(object sender, EventArgs e)
        {
            Rectangle pic1 = new Rectangle(0, 0, 10, 10);
            Pedestrian ped1 = new Pedestrian(0, 1, 4, "dink", characters, pic1);
            peds.Add(ped1);
            characters.Add(Properties.Resources.dylonStillRN);
            characters.Add(Properties.Resources.dylonWalk1RN);
            characters.Add(Properties.Resources.dylonWalk2R);
            characters.Add(Properties.Resources.dylonIdle1);
            characters.Add(Properties.Resources.dylonIdle2);
            characters.Add(Properties.Resources.dylonFart);
            charactersL.Add(Properties.Resources.dylonStillN);
            charactersL.Add(Properties.Resources.dylonWalk1N);
            charactersL.Add(Properties.Resources.dylonWalk2);
        }

        bool right, left;
        int position;

        private void mainGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            imgStill = 0;
            if (e.KeyCode == Keys.Escape)
            {
                pause = true;
            }
            if (!pause)
            {
                if (e.KeyCode == Keys.Right && fart == false) { right = true; }
                if (e.KeyCode == Keys.Left && fart == false) { left = true; }
                if (e.KeyCode == Keys.Space) { right = false; left = false; fart = true; }
            }
            else
            {
                if (e.KeyCode == Keys.Space) { pause = false; }
                if(e.KeyCode == Keys.M)
                {
                    // Create an instance of the SecondScreen
                    MainScreen cs = new MainScreen();
                    cs.Location = new Point(this.Left, this.Top);
                    // Add the User Control to the Form
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    f.Controls.Add(cs);
                }
            }

        }

        private void mainGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = false; }
            if (e.KeyCode == Keys.Left) { left = false; }
            if (e.KeyCode == Keys.Space) { fart = false; }
        }


        List<Image> characters = new List<Image>();
        List<Image> charactersL = new List<Image>();
        List<Pedestrian> peds = new List<Pedestrian>();

        int img, imgStill;
        int fartTimer;
        bool still, fart;
        bool pause;
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Pedestrians

            foreach(Pedestrian p in peds)
            {
                p.Move();
                //label1.Text = ;
            }

            #endregion
            if (right)
            {
                left = false;
                position +=5;
                still = false;
                imageChange();
            }
            else if (left)
            {
                right = false;
                still = false;
                position-=5;
                imageChange();
            }
            else
            {
                still = true;
                imgStill++;
                if (imgStill == 60)
                {
                    imgStill = 0;
                }
            }
            Refresh();
        }

       public void imageChange()
        {
            img++;
            if (img == 40)
            {
                img = 0;
            }
        }

        private void mainGame_Paint(object sender, PaintEventArgs e)
        {
            #region

            foreach(Pedestrian p in peds)
            {
                e.Graphics.DrawImage(p.Images[0], p.pic);
            }

            #endregion
            if (!still && right)
            {
                if (img < 10)
                {
                    e.Graphics.DrawImage(characters[0], new Rectangle(position, this.Height-300, 150, 300));
                }
                if (img < 20 && img >= 10)
                {
                    e.Graphics.DrawImage(characters[1], new Rectangle(position, this.Height -300, 150, 300));
                }
                if (img >= 20 && img < 30)
                {
                    e.Graphics.DrawImage(characters[0], new Rectangle(position, this.Height - 300, 150, 300));
                }
                if (img >= 30 && img <= 40)
                {
                    e.Graphics.DrawImage(characters[2], new Rectangle(position, this.Height - 300, 150, 300));
                }
            }
            else if (!still && left)
            {
                if (img < 10)
                {
                    e.Graphics.DrawImage(charactersL[0], new Rectangle(position, this.Height - 300, 150, 300));
                }
                if (img < 20 && img >= 10)
                {
                    e.Graphics.DrawImage(charactersL[1], new Rectangle(position, this.Height - 300, 150, 300));
                }
                if (img >= 20 && img < 30)
                {
                    e.Graphics.DrawImage(charactersL[0], new Rectangle(position, this.Height - 300, 150, 300));
                }
                if (img >= 30 && img <= 40)
                {
                    e.Graphics.DrawImage(charactersL[2], new Rectangle(position, this.Height - 300, 150, 300));
                }
            }
            else if (fart) { e.Graphics.DrawImage(characters[5], new Rectangle(position, this.Height-300, 150, 300)); }
          
            else
            {
                if (imgStill < 30)
                {
                    e.Graphics.DrawImage(characters[3], new Rectangle(position, this.Height - 300, 150, 300));
                }
                if (imgStill <= 60 && imgStill >= 30)
                {
                    e.Graphics.DrawImage(characters[4], new Rectangle(position, this.Height - 300, 150, 300));
                }
            }

            if(pause)
            {
                e.Graphics.DrawImage(Properties.Resources.pauseScreen, new Rectangle(this.Width/2 - 398/2, this.Height/2 - 181/2, 398, 181));
            }
        }
    }
}
