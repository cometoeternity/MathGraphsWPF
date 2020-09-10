using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphView.Models
{
    public class PointGeneratorLog
    {
        public List<Point> Points { get; set; }
        public PointGeneratorLog()
        {
            Points = new List<Point>();
        }
        public List<Point> PointGenerator(double logLimitStart, double logLimitFinish, double logAmplit, double logSjatie, double logXSdvig, double logYSdvig)
        {
            Points = new List<Point>();
            for (double x = logLimitStart; x < logLimitFinish; x += 0.5)
            {
                Points.Add(new Point(x, Calculate(x, logAmplit, logSjatie, logXSdvig, logYSdvig)));
            }
            return Points;
        }

        private double Calculate(double x, double logAmplit, double logSjatie, double logXSdvig, double logYSdvig)
        {
            return logAmplit * Math.Log(x * logSjatie + logXSdvig) + logYSdvig;
        }
    }
}

