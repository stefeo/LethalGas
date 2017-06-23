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
using System.Xml;
using System.IO;

/// <summary>
/// By Dylon Lemus and Stefan Andrekovic
/// For: Mr. Theodoropolous, Arcade Cabinet, anyone else who cares
/// Finished 2017-06-23 00:05
/// Farting game
/// Reference source: http://www.addictinggames.com/funny-games/hidethefart.jsp
/// Screens and good looking shit, player movement, animator, daylight cycle, highscore dude - Dylon Lemus
/// Art, music, farts, pedestrians, engine mechanics - Stefan Andrekovic
/// 
/// Thanks for teaching us how to code.
/// Thanks for letting us be shit-heads and have fun
/// Hope you enjoy.
/// Have a good life
/// </summary>
/// 

namespace LethalGas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static System.Windows.Media.MediaPlayer mainGameMusic = new System.Windows.Media.MediaPlayer();
        public static System.Windows.Media.MediaPlayer titleMusic = new System.Windows.Media.MediaPlayer();
        public static SoundPlayer fartSound = new SoundPlayer(Properties.Resources.Long_Fart_Sound_Effect_NEW);
        public static List<Highscore> highscoreList = new List<Highscore>();

        public static int currentScore;
        public static int score;

        private void Form1_Load(object sender, EventArgs e)
        {
            titleMusic.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "BONGO.mp3")));
            mainGameMusic.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "funky beat.mp3")));

            // Create an instance of the MainScreen
            MainScreen ms = new MainScreen();

            titleMusic.Stop();
            titleMusic.Play();

            // Add the User Control to the Form
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
            loadHighscores();
        }

        private void loadHighscores() //method for loading any saved highscores in the highscoreDB xml file
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Highscores.xml");

            XmlNode parent;
            parent = doc.DocumentElement;
            foreach (XmlNode child in parent.ChildNodes)
            {
                Highscore hs = new Highscore(null, null, null);
                foreach (XmlNode grandChild in child.ChildNodes)
                {
                    if (grandChild.Name == "name")
                    {
                        hs.name = grandChild.InnerText;
                    }
                    if (grandChild.Name == "level")
                    {
                        hs.level = grandChild.InnerText;
                    }
                    if (grandChild.Name == "score")
                    {
                        hs.score = grandChild.InnerText;
                    }
                }
                highscoreList.Add(hs);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // if (e.KeyCode == Keys.Escape) { this.Close(); }
        }

    }
}