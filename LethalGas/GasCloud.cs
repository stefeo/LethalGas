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
        public int age;
        public int cap;

        public GasCloud(int _x, int _y, int _fartLevel)
        {
            x = _x;
            y = _y;
            age = 0;
            size = new Size(10, 10);
        }

        public void Grow()
        {

        }
    }
}
