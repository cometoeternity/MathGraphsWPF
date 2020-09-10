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
using WpfGraphView.Windows.OxyPlotWindow;

namespace WpfGraphView
{
    /// <summary>
    /// Логика взаимодействия для CtgWindow.xaml
    /// </summary>
    public partial class CtgWindow : Window
    {
        public CtgWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ctgButton_Click(object sender, RoutedEventArgs e)
        {
            CtgOxyplotWindow oxyplotPage = new CtgOxyplotWindow();
            oxyplotPage.Show();
        }

    }
}
