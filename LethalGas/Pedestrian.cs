using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace LethalGas
{
    public class Pedestrian
    {
        public Point position;
        public int direction;
        public int speed;
        public string type;
        public Rectangle pic;
        public List<Image> Images;
        public int imgDex;

        public Pedestrian(int _position, int _direction, int _speed, string _type, List<Image> _Images, Rectangle _pic)
        {
            position.X = _position;
            position.Y = 320;
            direction = _direction;
            speed = _speed;
            type = _type;
            Images = _Images;
            pic = _pic;
            pic.Width = 150;
            pic.Height = 300;
            pic.Location = position;
            imgDex = 0;
        }

        public bool FartCheck(Rectangle fart, Rectangle player)
        {
            if (fart.IntersectsWith(player) && fart.IntersectsWith(pic))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Move()
        {
            position.X += direction * speed;
            pic.Location = position;

            imgDex++;
            if (imgDex == 40)
            {
                imgDex = 0;
            }
        }

        public bool Collide(Rectangle rect)
        {
            if (rect.IntersectsWith(pic))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
