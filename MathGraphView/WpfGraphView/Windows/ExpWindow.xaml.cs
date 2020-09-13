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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using WpfGraphView.Models;


namespace WpfGraphView
{
    /// <summary>
    /// Логика взаимодействия для ExpWindow.xaml
    /// </summary>
    public partial class ExpWindow : Window
    {
        PointGeneratorExp pointGeneratorExp;
        public ExpWindow()
        {
            InitializeComponent();
            expButton.Click += expButton_Click;
            pointGeneratorExp = new PointGeneratorExp();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void expButton_Click(object sender, RoutedEventArgs e)
        {
            pointGeneratorExp.PointGenerator(float.Parse(expLimitStartTextBox.Text), float.Parse(expLimitFinishTextBox.Text), float.Parse(expAmplitTextBox.Text), float.Parse(expSjatieTextBox.Text), float.Parse(expXSdvigTextBox.Text), float.Parse(expYSdvigTextBox.Text));
            PlotModel model = new PlotModel();
            LinearAxis linearX = new LinearAxis();
            linearX.Minimum = double.Parse(expLimitStartTextBox.Text);
            linearX.Maximum = double.Parse(expLimitFinishTextBox.Text);
            linearX.Position = AxisPosition.Bottom;

            LinearAxis linearY = new LinearAxis();
            linearY.Minimum = pointGeneratorExp.Points.Min(p => p.Y);
            linearY.Maximum = pointGeneratorExp.Points.Max(p => p.Y);
            linearY.Position = AxisPosition.Left;

            model.Axes.Add(linearX);
            model.Axes.Add(linearY);
            model.Title = "График Экспоненты";
            LineSeries lineSeries = new LineSeries();
            foreach (var item in pointGeneratorExp.Points)
            {
                lineSeries.Points.Add(new DataPoint(item.X, item.Y));
            }
            model.Series.Add(lineSeries);
            Grafic.Model = model;
        }
    }
}
