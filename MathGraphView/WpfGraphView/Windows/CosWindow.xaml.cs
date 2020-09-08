using System;
using System.Collections.Generic;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
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
using WpfGraphView.Windows.OxyPlotWindow;

namespace WpfGraphView
{
    /// <summary>
    /// Логика взаимодействия для CosWindow.xaml
    /// </summary>
    public partial class CosWindow : Window
    {
        public CosWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cosButton_Click(object sender, RoutedEventArgs e)
        {
            CosOxyplotWindow oxyplotPage = new CosOxyplotWindow();
            oxyplotPage.Show();
        }
    }
}
