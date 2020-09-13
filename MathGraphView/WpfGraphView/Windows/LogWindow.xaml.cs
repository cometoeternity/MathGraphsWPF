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

namespace WpfGraphView.Windows
{
    /// <summary>
    /// Логика взаимодействия для LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        PointGeneratorLog pointGeneratorLog;
        public LogWindow()
        {
            InitializeComponent();
            logButton.Click += logButton_Click;
            pointGeneratorLog = new PointGeneratorLog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            pointGeneratorLog.PointGenerator(float.Parse(logLimitStartTextBox.Text), float.Parse(logLimitFinishTextBox.Text), float.Parse(logAmplitTextBox.Text), float.Parse(logSjatieTextBox.Text), float.Parse(logXSdvigTextBox.Text), float.Parse(logYSdvigTextBox.Text));
            PlotModel model = new PlotModel();
            LinearAxis linearX = new LinearAxis();
            linearX.Minimum = double.Parse(logLimitStartTextBox.Text);
            linearX.Maximum = double.Parse(logLimitFinishTextBox.Text);
            linearX.Position = AxisPosition.Bottom;

            LinearAxis linearY = new LinearAxis();
            linearY.Minimum = pointGeneratorLog.Points.Min(p => p.Y);
            linearY.Maximum = pointGeneratorLog.Points.Max(p => p.Y);
            linearY.Position = AxisPosition.Left;

            model.Axes.Add(linearX);
            model.Axes.Add(linearY);
            model.Title = "График логарифма";
            LineSeries lineSeries = new LineSeries();
            foreach (var item in pointGeneratorLog.Points)
            {
                lineSeries.Points.Add(new DataPoint(item.X, item.Y));
            }
            model.Series.Add(lineSeries);
            Grafic.Model = model;
        }
    }
}
