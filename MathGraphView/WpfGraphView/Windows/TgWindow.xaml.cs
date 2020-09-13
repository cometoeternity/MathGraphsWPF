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
    /// Логика взаимодействия для TgWindow.xaml
    /// </summary>
    public partial class TgWindow : Window
    {
        PointGeneratorTg pointGeneratorTg;
        public TgWindow()
        {
            InitializeComponent();
            tgButton.Click += tgButton_Click;
            pointGeneratorTg = new PointGeneratorTg();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tgButton_Click(object sender, RoutedEventArgs e)
        {
            pointGeneratorTg.PointGenerator(float.Parse(tgLimitStartTextBox.Text), float.Parse(tgLimitFinishTextBox.Text), float.Parse(tgAmplitTextBox.Text), float.Parse(tgSjatieTextBox.Text), float.Parse(tgXSdvigTextBox.Text), float.Parse(tgYSdvigTextBox.Text));
            PlotModel model = new PlotModel();
            LinearAxis linearX = new LinearAxis();
            linearX.Minimum = double.Parse(tgLimitStartTextBox.Text);
            linearX.Maximum = double.Parse(tgLimitFinishTextBox.Text);
            linearX.Position = AxisPosition.Bottom;

            LinearAxis linearY = new LinearAxis();
            linearY.Minimum = pointGeneratorTg.Points.Min(p => p.Y);
            linearY.Maximum = pointGeneratorTg.Points.Max(p => p.Y);
            linearY.Position = AxisPosition.Left;

            model.Axes.Add(linearX);
            model.Axes.Add(linearY);
            model.Title = "График Тангенса";
            LineSeries lineSeries = new LineSeries();
            foreach (var item in pointGeneratorTg.Points)
            {
                lineSeries.Points.Add(new DataPoint(item.X, item.Y));
            }
            model.Series.Add(lineSeries);
            Grafic.Model = model;
        }
    }
}
