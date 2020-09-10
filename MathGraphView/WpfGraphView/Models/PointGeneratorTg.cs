using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphView.Models
{
    public class PointGeneratorTg
    {
        public List<Point> Points { get; set; }
        public PointGeneratorTg()
        {
            Points = new List<Point>();
        }
        public List<Point> PointGenerator(double tgLimitStart, double tgLimitFinish, double tgAmplit, double tgSjatie, double tgXSdvig, double tgYSdvig)
        {
            Points = new List<Point>();
            for (double x = tgLimitStart; x < tgLimitFinish; x += 0.5)
            {
                Points.Add(new Point(x, Calculate(x, tgAmplit, tgSjatie, tgXSdvig, tgYSdvig)));
            }
            return Points;
        }

        private double Calculate(double x, double tgAmplit, double tgSjatie, double tgXSdvig, double tgYSdvig)
        {
            return tgAmplit * Math.Tan(x* tgSjatie + tgXSdvig)+ tgYSdvig;
        }
    }
}

