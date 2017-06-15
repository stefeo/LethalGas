using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LethalGas
{
    class GasCloud
    {
        public int x;
        public int y;
        public Size size;
        public Rectangle rect;
        public int age;
        public int cap;

        public GasCloud(int _x, int _y, int _fartLevel)
        {
            x = _x;
            y = _y;
            age = 0;
            size = new Size(10, 10);
            rect = new Rectangle(x, y, size.Width, size.Height);
            cap = _fartLevel;
        }

        public GasCloud()
        {

        }

        public void Grow()
        {
            rect.Width = size.Width;
            rect.Height = size.Height;
            size.Width+= 2;
            x--;
            size.Height+= 2;
            y--;
            age++;
        }
    }
}
