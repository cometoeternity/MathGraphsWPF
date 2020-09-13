using System;
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
using WpfGraphView.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using WpfGraphView.Models;

namespace WpfGraphView
{
    /// <summary>
    /// Логика взаимодействия для SinWindow.xaml
    /// </summary>
    public partial class SinWindow : Window
    {
        PointGeneratorSin pointGeneratorSin;
        public SinWindow()
        {
            InitializeComponent();
            sinButton.Click += sinButton_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sinButton_Click(object sender, RoutedEventArgs e)
        {
            pointGeneratorSin = new PointGeneratorSin();
            pointGeneratorSin.PointGenerator();
            PlotModel model = new PlotModel();
            LinearAxis linearX = new LinearAxis();
            linearX.Minimum = pointGeneratorSin.SinLimitStart;
            linearX.Maximum = pointGeneratorSin.SinLimitFinish;
            linearX.Position = AxisPosition.Bottom;

            LinearAxis linearY = new LinearAxis();
            linearY.Minimum = pointGeneratorSin.Points.Min(p => p.Y);
            linearY.Maximum = pointGeneratorSin.Points.Max(p => p.Y);
            linearY.Position = AxisPosition.Left;

            model.Axes.Add(linearX);
            model.Axes.Add(linearY);
            model.Title = "График Синуса";
            model.TitleColor = OxyColor.FromRgb(224, 255, 255);
            model.TextColor = OxyColor.FromRgb(224, 255, 255);
            model.PlotAreaBorderColor = OxyColor.FromRgb(224, 255, 255);
            model.LegendTextColor = OxyColor.FromRgb(224, 255, 255);
            model.LegendTitleColor = OxyColor.FromRgb(224, 255, 255);
            model.SubtitleColor = OxyColor.FromRgb(224, 255, 255); ;
            model.SelectionColor = OxyColor.FromRgb(224, 255, 255);
            LineSeries lineSeries = new LineSeries();
            lineSeries.Color = OxyColor.FromRgb(224, 255, 255);
            foreach (var item in pointGeneratorSin.Points)
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
