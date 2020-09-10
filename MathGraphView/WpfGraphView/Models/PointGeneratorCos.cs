using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphView.Models
{
   public class PointGeneratorCos
   {
        public List<Point> Points { get; set; }
        public PointGeneratorCos()
        {
            Points = new List<Point>();
        }
        public List<Point> PointGenerator (double cosbLimitStart, double cosLimitFinish, double cosAmplit, double cosSjatie, double cosXSdvig, double cosYSdvig)
        {
            Points = new List<Point>();
            for(double x= cosbLimitStart; x< cosLimitFinish; x+=0.5)
            {
                Points.Add(new Point(x, Calculate(x, cosAmplit, cosSjatie, cosXSdvig, cosYSdvig)));
            }
            return Points;
        }

        private double Calculate(double x,double cosAmplit, double cosSjatie, double cosXSdvig, double cosYSdvig)
        {
            return cosAmplit*Math.Cos(x* cosSjatie + cosXSdvig) + cosYSdvig;  
        }
    }
}
