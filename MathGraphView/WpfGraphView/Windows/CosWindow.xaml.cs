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
            pointGenertorCos.PointGenerator(float.Parse(cosbLimitStartTextBox.Text), float.Parse(cosLimitFinishTextBox.Text), float.Parse(cosAmplitTextBox.Text), float.Parse(cosSjatieTextBox.Text), float.Parse(cosXSdvigTextBox.Text), float.Parse(cosYSdvigTextBox.Text));
            PlotModel model = new PlotModel();
            LinearAxis linearX = new LinearAxis();
            linearX.Minimum = double.Parse(cosbLimitStartTextBox.Text);
            linearX.Maximum = double.Parse(cosLimitFinishTextBox.Text);
            linearX.Position = AxisPosition.Bottom;

            LinearAxis linearY = new LinearAxis();
            linearY.Minimum = pointGenertorCos.Points.Min(p => p.Y);
            linearY.Maximum = pointGenertorCos.Points.Max(p => p.Y);
            linearY.Position = AxisPosition.Left;

            model.Axes.Add(linearX);
            model.Axes.Add(linearY);
            model.Title = "График Косинуса";
            LineSeries lineSeries = new LineSeries();
            foreach (var item in pointGenertorCos.Points)
            {
                lineSeries.Points.Add(new DataPoint(item.X, item.Y));
            }
            model.Series.Add(lineSeries);
            Grafic.Model = model;
        }
    }
}
