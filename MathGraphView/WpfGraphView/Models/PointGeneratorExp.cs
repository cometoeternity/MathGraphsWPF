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
        public List<Point> PointGenerator(double expLimitStart, double expLimitFinish, double expAmplit, double expSjatie, double expXSdvig, double expYSdvig)
        {
            Points = new List<Point>();
            for (double x = expLimitStart; x < expLimitFinish; x += 0.5)
            {
                Points.Add(new Point(x, Calculate(x, expAmplit, expSjatie, expXSdvig, expYSdvig)));
            }
            return Points;
        }

        private double Calculate(double x, double expAmplit, double expSjatie, double expXSdvig, double expYSdvig)
        {
            return expAmplit * Math.Exp(x * expSjatie + expXSdvig) + expYSdvig;
        }
    }
}

