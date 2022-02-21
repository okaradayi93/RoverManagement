using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement.Entity
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void SetX(int x)
        {
            if (x > -1)
                this.X = x;
        }

        public void SetY(int y)
        {
            if (y > -1)
                this.Y = y;
        }

        public override string ToString()
        {
            return this.X + " " + this.Y;
        }


    }
}
