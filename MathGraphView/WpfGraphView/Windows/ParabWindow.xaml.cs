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
    /// Логика взаимодействия для CtgWindow.xaml
    /// </summary>
    public partial class CtgWindow : Window
    {
        PointGeneratorParab pointGeneratorParab;
        public CtgWindow()
        {
            InitializeComponent();
            parabButton.Click += ctgButton_Click;
            pointGeneratorParab = new PointGeneratorParab();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ctgButton_Click(object sender, RoutedEventArgs e)
        {
            pointGeneratorParab.PointGenerator(float.Parse(parabLimitStartTextBox.Text), float.Parse(parabLimitFinishTextBox.Text), float.Parse(parabSjatieTextBox.Text), float.Parse(parabXSdvigTextBox.Text), float.Parse(parabYSdvigTextBox.Text), float.Parse(parabPowTextBox.Text));
            PlotModel model = new PlotModel();
            LinearAxis linearX = new LinearAxis();
            linearX.Minimum = double.Parse(parabLimitStartTextBox.Text);
            linearX.Maximum = double.Parse(parabLimitFinishTextBox.Text);
            linearX.Position = AxisPosition.Bottom;

            LinearAxis linearY = new LinearAxis();
            linearY.Minimum = pointGeneratorParab.Points.Min(p => p.Y);
            linearY.Maximum = pointGeneratorParab.Points.Max(p => p.Y);
            linearY.Position = AxisPosition.Left;

            model.Axes.Add(linearX);
            model.Axes.Add(linearY);
            model.Title = "График Параболы";
            LineSeries lineSeries = new LineSeries();
            foreach (var item in pointGeneratorParab.Points)
            {
                lineSeries.Points.Add(new DataPoint(item.X, item.Y));
            }
            model.Series.Add(lineSeries);
            Grafic.Model = model;
        }

    }
}
