using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphView.Models
{
   public class PointGeneratorParab
   {
        public List<Point> Points { get; set; }
        public PointGeneratorParab()
        {
            Points = new List<Point>();
        }
        public List<Point> PointGenerator(double parabLimitStart, double parabLimitFinish, double parabSjatie, double parabXSdvig, double parabYSdvig, double parabPow)
        {
            Points = new List<Point>();
            for (double x = parabLimitStart; x < parabLimitFinish; x += 0.5)
            {
                Points.Add(new Point(x, Calculate(x, parabSjatie, parabXSdvig, parabYSdvig, parabPow)));
            }
            return Points;
        }

        private double Calculate(double x, double parabSjatie, double parabXSdvig, double parabYSdvig, double parabPow)
        {
            return parabSjatie * Math.Pow(x + parabXSdvig, parabPow)+ parabYSdvig;    
        }
    }
}

