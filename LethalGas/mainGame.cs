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

        List<Image> pedImages = new List<Image>();
        List<Image> pedImages2 = new List<Image>();
        List<Image> pedImagesL = new List<Image>();
        List<Image> pedImages2L = new List<Image>();

        List<Pedestrian> peds = new List<Pedestrian>();
        List<GasCloud> farts = new List<GasCloud>();
        Random randNum = new Random();
        Rectangle pic1 = new Rectangle(0, 0, 10, 10);
        Rectangle playerRect = new Rectangle();

        SolidBrush blockBrush = new SolidBrush(Color.Green);
        SolidBrush blockBrush2 = new SolidBrush(Color.Green);
        SolidBrush blockBrush3 = new SolidBrush(Color.Green);
        SolidBrush backBrush = new SolidBrush(Color.FromArgb(190, 0, 0, 0));
        SolidBrush backBrush1 = new SolidBrush(Color.FromArgb(180, 0, 0, 0));
        SolidBrush backBrush2 = new SolidBrush(Color.FromArgb(200, 0, 0, 0));

        int pedSpawnTimer;
        int speed;
        int speedBoostTimer;
        int img, imgStill;
        int fartTimer, fartLevel;
        bool still, fart, pause;
        int brightness, brightness2, day;
        bool right, left;
        int position;
        double counter;

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

            pedImages.Add(Properties.Resources.pedoStillR);
            pedImages.Add(Properties.Resources.pedoWalk1R);
            pedImages.Add(Properties.Resources.pedoWalk2R);
            pedImages.Add(Properties.Resources.pedoStillR);
            
            pedImagesL.Add(Properties.Resources.pedoStill);
            pedImagesL.Add(Properties.Resources.pedoWalk1);
            pedImagesL.Add(Properties.Resources.pedoWalk2);
            pedImagesL.Add(Properties.Resources.pedoStill);

            pedImages2.Add(Properties.Resources.bluePedoStillR);
            pedImages2.Add(Properties.Resources.bluePedoWalk1R);
            pedImages2.Add(Properties.Resources.bluePedoWalk2R);
            pedImages2.Add(Properties.Resources.bluePedoStillR);

            pedImages2L.Add(Properties.Resources.bluePedoStill);
            pedImages2L.Add(Properties.Resources.bluePedoWalk1);
            pedImages2L.Add(Properties.Resources.bluePedoWalk2);
            pedImages2L.Add(Properties.Resources.bluePedoStill);

            lightPoints();

            playerRect = new Rectangle(position, this.Height - 329, 150, 300);
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
            if (e.KeyCode == Keys.Escape)
            {
                pause = true;
                if (brightness > 100) { backBrush.Color = Color.FromArgb(140, 0, 0, 0); backBrush2.Color = Color.FromArgb(120, 0, 0, 0); }
                timer1.Enabled = false; Refresh();
            }

            if (!pause)
            {
                if (e.KeyCode == Keys.Right && !fart ) { right = true; }
                if (e.KeyCode == Keys.Left && !fart ) { left = true; }
                if (e.KeyCode == Keys.Space) { right = false; left = false; fart = true; }
            }
            
            else
            {
                if (e.KeyCode == Keys.Space) { pause = false; timer1.Enabled = true; Refresh(); }
                if(e.KeyCode == Keys.M)
                {
                    // Create an instance of the SecondScreen
                    Form1.mainGameMusic.Stop();
                    Form1.titleMusic.Play();
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
                speedBoostTimer = 20;

                if (Keyboard.IsKeyDown(Key.Right))
                {
                    right = true;
                }

                if (Keyboard.IsKeyDown(Key.Left))
                {
                    left = true;
                }
            }


        }

        public void dayChange()
        {
            day++;
            
            if (day > 500 && day < 730) { brightness++; }
            else if (day >= 1300 && day < 1529) { brightness--; }
            else if (day == 2100) { day = 0; }

            if (day > 560 && day <730) { brightness2++; }
            else if (day >= 1360 && day < 1329) { brightness2--; }
            else if (day == 2100) { day = 0; }

            backBrush.Color = Color.FromArgb(brightness, 0, 0, 0);
            backBrush2.Color = Color.FromArgb(brightness2, 0, 0, 0);

        }

        public void fartMeter()
        {
                //fart Mete#test change#r
                blockBrush.Color = Color.FromArgb(200 - fartTimer / 4, 50, 128, 40);
                blockBrush2.Color = Color.FromArgb(200 - fartTimer / 3, 0, 100, 0);
                blockBrush3.Color = Color.FromArgb(fartTimer / 2, 165, 42, 42);

            if (fart && fartTimer > 0)
            {
                fartTimer -= 2;
                fartLevel += 2;
            }
            else if (fartTimer < 260) { fartTimer++; }
            else if (fartTimer >= 260)
            {
                //lose
                // Create an instance of the SecondScreen
                Form1.mainGameMusic.Stop();
                Form1.titleMusic.Play();
                loseScreen cs = new loseScreen();
                cs.Location = new Point(this.Left, this.Top);
                // Add the User Control to the Form
                Form form = this.FindForm();
                form.Controls.Remove(this);
                form.Controls.Add(cs);
                cs.Focus();
                timer1.Enabled = false;
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            timeLabel.Text = "Time:" + (counter/28).ToString("000");
            scoreLabel.Text = "Score:" + (Form1.score).ToString("0000");

            dayChange();
            fartMeter();

            #region fartlLevel
            if (Keyboard.IsKeyDown(Key.Space))
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
                    if (p.Collide(f.rect)) { Form1.score++; }
                    if (p.FartCheck(f.rect, playerRect))
                    {
                        //lose
                        // Create an instance of the SecondScreen
                        Form1.mainGameMusic.Stop();
                        Form1.titleMusic.Play();
                        loseScreen cs = new loseScreen();
                        cs.Location = new Point(this.Left, this.Top);
                        // Add the User Control to the Form
                        Form form = this.FindForm();
                        form.Controls.Remove(this);
                        form.Controls.Add(cs);
                        cs.Focus();
                        timer1.Enabled = false;
                        return;
                    }
                }
            }

            #endregion

            playerRect.X = position;

            if (speedBoostTimer > 0)
            {
                speed = 10;
                speedBoostTimer--;
            }
            else
            {
                speed = 5;
            }

            if (right && position < this.Width - 119)
            {
                left = false;
                position += speed;
                still = false;
                imageChange();
            }
            else if (left && position > -40)
            {
                right = false;
                still = false;
                position -= speed;
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
                e.Graphics.DrawImage(Properties.Resources.fart2, f.rect);
            }

            #endregion

            if (!still && right)
            {
                if (img < 10)
                {
                    e.Graphics.DrawImage(characters[0], playerRect);
                }
                if (img < 20 && img >= 10)
                {
                    e.Graphics.DrawImage(characters[1], playerRect);
                }
                if (img >= 20 && img < 30)
                {
                    e.Graphics.DrawImage(characters[0], playerRect);
                }
                if (img >= 30 && img <= 40)
                {
                    e.Graphics.DrawImage(characters[2], playerRect);
                }
            }
            else if (!still && left)
            {
                if (img < 10)
                {
                    e.Graphics.DrawImage(charactersL[0], playerRect);
                }
                if (img < 20 && img >= 10)
                {
                    e.Graphics.DrawImage(charactersL[1], playerRect);
                }
                if (img >= 20 && img < 30)
                {
                    e.Graphics.DrawImage(charactersL[0], playerRect);
                }
                if (img >= 30 && img <= 40)
                {
                    e.Graphics.DrawImage(charactersL[2], playerRect);
                }
            }
            else if (fart) { e.Graphics.DrawImage(characters[5], playerRect); }
          //if player is not moving
            else
            {
                if (imgStill < 30)
                {
                    e.Graphics.DrawImage(characters[3], playerRect);
                }
                if (imgStill <= 60 && imgStill >= 30)
                {
                    e.Graphics.DrawImage(characters[4], playerRect);
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
            if (randNum.Next(0, 120) == 1)
            {//charcter randomness
                if (randNum.Next(1, 3) == 1)
                {//side random
                    if (randNum.Next(1, 3) == 1)
                    {//speed rndom
                        if (randNum.Next(1, 3) == 1)
                        {
                            Pedestrian ped = new Pedestrian(-100, 1, 2, "paul", pedImages, pic1);
                            peds.Add(ped);
                        }
                        else
                        {
                            Pedestrian ped = new Pedestrian(-100, 1, 3, "paul", pedImages, pic1);
                            peds.Add(ped);

                        }
                    }

                    else
                    {
                        if (randNum.Next(1, 3) == 1)
                        {
                            Pedestrian ped = new Pedestrian(this.Width, -1, 3, "phil", pedImagesL, pic1);
                            peds.Add(ped);
                        }
                        else
                        {
                            Pedestrian ped = new Pedestrian(this.Width, -1, 2, "phil", pedImagesL, pic1);
                            peds.Add(ped);
                        }
                    }
                }

                else
                {
                    if (randNum.Next(1, 3) == 1)
                    {
                        if (randNum.Next(1, 3) == 1)
                        {
                            Pedestrian ped = new Pedestrian(-100, 1, 2, "paul", pedImages2, pic1);
                            peds.Add(ped);
                        }
                        else
                        {
                            Pedestrian ped = new Pedestrian(-100, 1, 3, "paul", pedImages2, pic1);
                            peds.Add(ped);

                        }
                    }

                    else
                    {
                        if (randNum.Next(1, 3) == 1)
                        {
                            Pedestrian ped = new Pedestrian(this.Width, -1, 3, "phil", pedImages2L, pic1);
                            peds.Add(ped);
                        }
                        else
                        {
                            Pedestrian ped = new Pedestrian(this.Width, -1, 2, "phil", pedImages2L, pic1);
                            peds.Add(ped);
                        }
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
    }
}
