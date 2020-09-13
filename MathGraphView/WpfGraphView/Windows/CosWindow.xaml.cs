using System;
using System.Collections.Generic;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
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
using WpfGraphView.Models;
using System.Management.Instrumentation;

namespace WpfGraphView
{
    /// <summary>
    /// Логика взаимодействия для CosWindow.xaml
    /// </summary>
    public partial class CosWindow : Window
    {
        PointGeneratorCos pointGenertorCos;
        public CosWindow()
        {
            InitializeComponent();
            cosButton.Click += cosButton_Click;
            pointGenertorCos = new PointGeneratorCos();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cosButton_Click(object sender, RoutedEventArgs e)
        {
            pointGenertorCos.PointGenerator();
            PlotModel model = new PlotModel();
            LinearAxis linearX = new LinearAxis();
            linearX.Minimum = pointGenertorCos.CosLimitStart;
            linearX.Maximum = pointGenertorCos.CosLimitFinish;
            linearX.Position = AxisPosition.Bottom;

            LinearAxis linearY = new LinearAxis();
            linearY.Minimum = pointGenertorCos.Points.Min(p => p.Y);
            linearY.Maximum = pointGenertorCos.Points.Max(p => p.Y);
            linearY.Position = AxisPosition.Left;

            model.Axes.Add(linearX);
            model.Axes.Add(linearY);
            model.Title = "График Косинуса";
            model.TitleColor = OxyColor.FromRgb(224, 255, 255);
            model.TextColor = OxyColor.FromRgb(224, 255, 255);
            model.PlotAreaBorderColor = OxyColor.FromRgb(224, 255, 255);
            model.LegendTextColor = OxyColor.FromRgb(224, 255, 255);
            model.LegendTitleColor = OxyColor.FromRgb(224, 255, 255);
            model.SubtitleColor = OxyColor.FromRgb(224, 255, 255); ;
            model.SelectionColor = OxyColor.FromRgb(224, 255, 255);
            LineSeries lineSeries = new LineSeries();
            lineSeries.Color = OxyColor.FromRgb(224, 255, 255);
            foreach (var item in pointGenertorCos.Points)
            {
                lineSeries.Points.Add(new DataPoint(item.X, item.Y));
            }
            model.Series.Add(lineSeries);
            Grafic.Model = model;
        }
        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
        }
    }
}
