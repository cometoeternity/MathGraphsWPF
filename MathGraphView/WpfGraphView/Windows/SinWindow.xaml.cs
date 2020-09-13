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
            pointGeneratorSin = new PointGeneratorSin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sinButton_Click(object sender, RoutedEventArgs e)
        {
            pointGeneratorSin.PointGenerator(float.Parse(sinLimitStartTextBox.Text), float.Parse(sinLimitFinishTextBox.Text), float.Parse(sinAmplitTextBox.Text), float.Parse(sinSjatieTextBox.Text), float.Parse(sinXSdvigTextBox.Text), float.Parse(sinYSdvigTextBox.Text));
            PlotModel model = new PlotModel();
            LinearAxis linearX = new LinearAxis();
            linearX.Minimum = double.Parse(sinLimitStartTextBox.Text);
            linearX.Maximum = double.Parse(sinLimitFinishTextBox.Text);
            linearX.Position = AxisPosition.Bottom;

            LinearAxis linearY = new LinearAxis();
            linearY.Minimum = pointGeneratorSin.Points.Min(p => p.Y);
            linearY.Maximum = pointGeneratorSin.Points.Max(p => p.Y);
            linearY.Position = AxisPosition.Left;

            model.Axes.Add(linearX);
            model.Axes.Add(linearY);
            model.Title = "График Синуса";
            LineSeries lineSeries = new LineSeries();
            foreach (var item in pointGeneratorSin.Points)
            {
                lineSeries.Points.Add(new DataPoint(item.X, item.Y));
            }
            model.Series.Add(lineSeries);
            Grafic.Model = model;
        }
    }
}
