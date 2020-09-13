using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphView.Models
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point (float x, float y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return string.Format("({0},{1}", X, Y);
        }
    }
}
