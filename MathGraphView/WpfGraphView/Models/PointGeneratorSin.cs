using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphView.Models
{
    public class PointGeneratorSin
    {
        public List<Point> Points { get; set; }
        public PointGeneratorSin()
        {
            Points = new List<Point>();
        }
        public List<Point> PointGenerator(double sinLimitStart, double sinLimitFinish, double sinAmplit, double sinSjatie, double sinXSdvig, double sinYSdvig)
        {
            Points = new List<Point>();
            for (double x = sinLimitStart; x < sinLimitFinish; x += 0.5)
            {
                Points.Add(new Point(x, Calculate(x, sinAmplit, sinSjatie, sinXSdvig, sinYSdvig)));
            }
            return Points;
        }

        private double Calculate(double x, double sinAmplit, double sinSjatie, double sinXSdvig, double sinYSdvig)
        {
            return sinAmplit * Math.Sin(x * sinSjatie + sinXSdvig) + sinYSdvig;
        }
    }
}

