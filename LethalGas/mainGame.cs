using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace LethalGas
{
    public partial class mainGame : UserControl
    {
        Point[] triangle = new Point[6];
        Point[] triangle1 = new Point[4];

        List<Image> characters = new List<Image>();
        List<Image> charactersL = new List<Image>();
        List<Pedestrian> peds = new List<Pedestrian>();
        List<GasCloud> farts = new List<GasCloud>();
        Random randNum = new Random();
        Rectangle pic1 = new Rectangle(0, 0, 10, 10);

        SolidBrush blockBrush = new SolidBrush(Color.Green);
        SolidBrush blockBrush2 = new SolidBrush(Color.Green);
        SolidBrush blockBrush3 = new SolidBrush(Color.Green);
        SolidBrush backBrush = new SolidBrush(Color.FromArgb(190, 0, 0, 0));
        SolidBrush backBrush1 = new SolidBrush(Color.FromArgb(180, 0, 0, 0));
        SolidBrush backBrush2 = new SolidBrush(Color.FromArgb(200, 0, 0, 0));

        int score;
        int pedSpawnTimer;
        int img, imgStill;
        int fartTimer, fartLevel;
        bool still, fart, pause;
        int brightness, brightness2, day;
        bool right, left;
        int position;

        public mainGame()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void mainGame_Load(object sender, EventArgs e)
        {
            //Pedestrian ped1 = new Pedestrian(this.Width, -1, 3, "dink", charactersL, pic1);
            //peds.Add(ped1);
            Form1.mainGameMusic.Play();
            characters.Add(Properties.Resources.dylonStillRN);
            characters.Add(Properties.Resources.dylonWalk1RN);
            characters.Add(Properties.Resources.dylonWalk2R);
            characters.Add(Properties.Resources.dylonIdle1);
            characters.Add(Properties.Resources.dylonIdle2);
            characters.Add(Properties.Resources.dylonFart);
            charactersL.Add(Properties.Resources.dylonStillN);
            charactersL.Add(Properties.Resources.dylonWalk1N);
            charactersL.Add(Properties.Resources.dylonWalk2);
            lightPoints();
        }
         
        public void lightPoints()
        {
            triangle[0] = new Point(0, 0);
            triangle[1] = new Point(0, this.Height-150);
            triangle[2] = new Point(this.Width - 226, this.Height - 445);
            triangle[3] = new Point(this.Width - 145, this.Height - 445);
            triangle[4] = new Point(this.Width, this.Height - 330);
            triangle[5] = new Point(this.Width, 0);

            triangle1[0] = new Point(this.Width - 136, this.Height);
            triangle1[1] = new Point(this.Width - 151, this.Height - 385);
            triangle1[2] = new Point(this.Width - 221, this.Height - 385);
            triangle1[3] = new Point(this.Width - 236, this.Height);
        }

        private void mainGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            imgStill = 0;
            if (e.KeyCode == Keys.Escape) { pause = true; }

            if (!pause)
            {
                if (e.KeyCode == Keys.Right && !fart ) { right = true; }
                if (e.KeyCode == Keys.Left && !fart ) { left = true; }
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
                    cs.Focus();
                }
            }
            if (brightness < 245)
            {
                if (e.KeyCode == Keys.B) { brightness += 10; }
            }
            if(brightness > 12 )
            { 
                if (e.KeyCode == Keys.M) { brightness -= 10; }
            }

            //gameOver
            if(e.KeyCode == Keys.G)
            {
                // Create an instance of the SecondScreen
                loseScreen cs = new loseScreen();
                cs.Location = new Point(this.Left, this.Top);
                // Add the User Control to the Form
                Form f = this.FindForm();
                f.Controls.Remove(this);
                f.Controls.Add(cs);
                cs.Focus();
            }

        }

        private void mainGame_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = false; }
            if (e.KeyCode == Keys.Left) { left = false; }
            if (e.KeyCode == Keys.Space)
            {
                fart = false;
                fartLevel = 0;
            }
        }

        public void dayChange()
        {
            day++;
            if (day < 230) { brightness++; }
            else if (day >= 800 && day < 1029) { brightness--; }
            else if (day == 1600) { day = 0; }

            if (day > 60 && day <230) { brightness2++; }
            else if (day >= 860 && day < 1029) { brightness2--; }
            else if (day == 1600) { day = 0; }

            backBrush.Color = Color.FromArgb(brightness, 0, 0, 0);
            backBrush2.Color = Color.FromArgb(brightness2, 0, 0, 0);

        }

        public void fartMeter()
        {
            //fart Meter
            blockBrush.Color = Color.FromArgb(200 - fartTimer / 4, 50, 128, 40);
            blockBrush2.Color = Color.FromArgb(200 - fartTimer / 3, 0, 100, 0);
            blockBrush3.Color = Color.FromArgb(fartTimer / 2, 165, 42, 42);

            if (fart && fartTimer > 0)
            {
                fartTimer--;
                fartLevel++;
            }
            else if (fartTimer < 260) { fartTimer++; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region fartlLevel
            if(Keyboard.IsKeyDown(Key.Space))
            {
                if (fartLevel > 3)
                {
                    try
                    {
                    //    farts[farts.Count - 1].size.Width+= 2;
                    //    farts[farts.Count - 1].size.Height+= 2;
                    //    farts[farts.Count - 1].x--;
                    //    farts[farts.Count - 1].y--;
                        farts[farts.Count - 1].cap = fartLevel;
                    }
                    catch
                    {
                        GasCloud g = new GasCloud(position + 75, this.Height - 160, fartLevel);
                        farts.Add(g);
                    }
                    //farts.RemoveAt(farts.IndexOf(g) - 1);
                }
                else
                {
                    GasCloud g = new GasCloud(position + 75, this.Height - 160, fartLevel);
                    farts.Add(g);
                }

                fartLevel++;
            }
            else
            {
                fartLevel = 0;
            }
            #endregion

            dayChange();
            fartMeter();

            #region Farts

            GrowFarts();

            #endregion

            #region Pedestrians

            pedSpawnTimer++;

            SpawnNPC();

            foreach(Pedestrian p in peds)
            {
                p.Move();

                foreach(GasCloud f in farts)
                {
                    if (p.Collide(f.rect)) { score++; }
                }
            }

            #endregion

            if (right && position < this.Width - 119)
            {
                left = false;
                position += 5;
                still = false;
                imageChange();
            }
            else if (left && position > -40)
            {
                right = false;
                still = false;
                position -= 5;
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
            #region ped images

            foreach(Pedestrian p in peds)
            {
                if (p.direction == 1)
                {
                    if (p.imgDex < 10)
                    {
                        e.Graphics.DrawImage(p.Images[0], p.pic);
                    }
                    if (p.imgDex < 20 && p.imgDex >= 10)
                    {
                        e.Graphics.DrawImage(p.Images[1], p.pic);
                    }
                    if (p.imgDex >= 20 && p.imgDex < 30)
                    {
                        e.Graphics.DrawImage(p.Images[0], p.pic);
                    }
                    if (p.imgDex >= 30 && p.imgDex <= 40)
                    {
                        e.Graphics.DrawImage(p.Images[2], p.pic);
                    }
                }
                else if (p.direction == -1)
                {
                    if (p.imgDex < 10)
                    {
                        e.Graphics.DrawImage(p.Images[0], p.pic);
                    }
                    if (p.imgDex < 20 && p.imgDex >= 10)
                    {
                        e.Graphics.DrawImage(p.Images[1], p.pic);
                    }
                    if (p.imgDex >= 20 && p.imgDex < 30)
                    {
                        e.Graphics.DrawImage(p.Images[0], p.pic);
                    }
                    if (p.imgDex >= 30 && p.imgDex <= 40)
                    {
                        e.Graphics.DrawImage(p.Images[2], p.pic);
                    }
                }
            }

            #endregion

            #region farts
            
            foreach (GasCloud f in farts)
            {
                Rectangle r = new Rectangle(f.x, f.y, f.size.Width, f.size.Height);
                e.Graphics.FillRectangle(blockBrush, r);
            }

            #endregion

            if (!still && right)
            {
                if (img < 10)
                {
                    e.Graphics.DrawImage(characters[0], new Rectangle(position, this.Height-329, 150, 300));
                }
                if (img < 20 && img >= 10)
                {
                    e.Graphics.DrawImage(characters[1], new Rectangle(position, this.Height -329, 150, 300));
                }
                if (img >= 20 && img < 30)
                {
                    e.Graphics.DrawImage(characters[0], new Rectangle(position, this.Height - 329, 150, 300));
                }
                if (img >= 30 && img <= 40)
                {
                    e.Graphics.DrawImage(characters[2], new Rectangle(position, this.Height - 329, 150, 300));
                }
            }
            else if (!still && left)
            {
                if (img < 10)
                {
                    e.Graphics.DrawImage(charactersL[0], new Rectangle(position, this.Height - 329, 150, 300));
                }
                if (img < 20 && img >= 10)
                {
                    e.Graphics.DrawImage(charactersL[1], new Rectangle(position, this.Height - 329, 150, 300));
                }
                if (img >= 20 && img < 30)
                {
                    e.Graphics.DrawImage(charactersL[0], new Rectangle(position, this.Height - 329, 150, 300));
                }
                if (img >= 30 && img <= 40)
                {
                    e.Graphics.DrawImage(charactersL[2], new Rectangle(position, this.Height - 329, 150, 300));
                }
            }
            else if (fart) { e.Graphics.DrawImage(characters[5], new Rectangle(position, this.Height-329, 150, 300)); }
          //if player is not moving
            else
            {
                if (imgStill < 30)
                {
                    e.Graphics.DrawImage(characters[3], new Rectangle(position, this.Height - 329, 150, 300));
                }
                if (imgStill <= 60 && imgStill >= 30)
                {
                    e.Graphics.DrawImage(characters[4], new Rectangle(position, this.Height - 329, 150, 300));
                }
            }

            //pause Screen appears
            if(pause)
            {
                e.Graphics.FillRectangle(backBrush1, 0, 0, 1020, 650);
                e.Graphics.DrawImage(Properties.Resources.Pause1, new Rectangle(0,0,1020,650));
            }

            //light
            e.Graphics.FillPolygon(backBrush, triangle);
            e.Graphics.FillPolygon(backBrush2, triangle1);

             
            //FartMeter
            e.Graphics.FillRectangle(blockBrush, (this.Width / 2) - fartTimer, 50, fartTimer*2, 30);
            e.Graphics.FillRectangle(blockBrush2, (this.Width / 2) - fartTimer, 50, fartTimer * 2, 30);
            e.Graphics.FillRectangle(blockBrush3, (this.Width / 2) - fartTimer, 50, fartTimer * 2, 30);
        }

        public void SpawnNPC()
        {
            if (randNum.Next(0, 100) == 1)
            {
                if (randNum.Next(1,3) == 1)
                {
                    if (randNum.Next(1, 3) == 1)
                    {
                        Pedestrian ped = new Pedestrian(-100, 1, 2, "paul", characters, pic1);
                        peds.Add(ped);
                    }
                    else
                    {
                        Pedestrian ped = new Pedestrian(-100, 1, 3, "paul", characters, pic1);
                        peds.Add(ped);

                    }
                }

                else
                {
                    if (randNum.Next(1, 3) == 1)
                    {
                        Pedestrian ped = new Pedestrian(this.Width, -1, 3, "phil", charactersL, pic1);
                        peds.Add(ped);
                    }
                    else
                    {
                        Pedestrian ped = new Pedestrian(this.Width, -1, 2, "phil", charactersL, pic1);
                        peds.Add(ped);
                    }
                }
            }
        }

        public void GrowFarts()
        {
            List<int> fartsToRemove = new List<int>();

            foreach (GasCloud f in farts)
            {
                f.Grow();
                if (f.age >= f.cap)
                {
                    fartsToRemove.Add(farts.IndexOf(f));
                }
            }

            fartsToRemove.Reverse();

            foreach(int i in fartsToRemove)
            {
                farts.RemoveAt(i);
            }
        }

        public void DrawFarts()
        {
        }
    }
}
