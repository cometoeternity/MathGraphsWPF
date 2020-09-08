using System;
using OxyPlot;
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
    /// Логика взаимодействия для TgOxyplotWindow.xaml
    /// </summary>
    public partial class TgOxyplotWindow : Window
    {
        public TgOxyplotWindow()
        {
            this.MyModel = new PlotModel { Title = "График Тангенса" };
            this.MyModel.Series.Add(new FunctionSeries(Math.Tan, 0, 20, 0.1, "tg (x)"));
    }

        public PlotModel MyModel { get; private set; }
    }
}
