using System;
using OxyPlot;
using OxyPlot.Wpf;
using OxyPlot.Series;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfGraphView.Windows.OxyPlotWindow
{
    /// <summary>
    /// Логика взаимодействия для CosOxyplotWindow.xaml
    /// </summary>
    public partial class CosOxyplotWindow : Window
    {
        public CosOxyplotWindow()
        {
            this.MyModel = new PlotModel { Title = "График Косинуса" };
            this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
        }
        public PlotModel MyModel { get; private set; }
    }
}
