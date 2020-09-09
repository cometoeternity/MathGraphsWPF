using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphView.Models
{
    public class PointGeneratorExp
    {
        public List<Point> Points { get; set; }
        public PointGeneratorExp()
        {
            Points = new List<Point>();
        }
        public List<Point> PointGenerator(double limitStart, double limitFinish, double y, double z, double w)
        {
            Points = new List<Point>();
            for (double x = limitStart; x < limitFinish; x += 0.1)
            {
                Points.Add(new Point(x, Calculate(x, y, z, w)));
            }
            return Points;
        }

        private double Calculate(double x, double y, double z, double w)
        {
            var b = Math.Exp(x);
            return b;
        }
    }
}
}
