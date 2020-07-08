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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using OxyPlot;
using OxyPlot.Series;

namespace WpfGraphView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void VisibilityAndIsOpen()
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }
        private void sin_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = sin;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Синус";
        }

        private void sin_MouseLeave(object sender, MouseEventArgs e)
        {
            VisibilityAndIsOpen();
        }

        private void cos_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = cos;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Косинус";
        }

        private void cos_MouseLeave(object sender, MouseEventArgs e)
        {
            VisibilityAndIsOpen();
        }

        private void tg_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = tg;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Тангенс";
        }

        private void tg_MouseLeave(object sender, MouseEventArgs e)
        {
            VisibilityAndIsOpen();
        }

        private void ctg_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = ctg;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Катангенс";
        }

        private void ctg_MouseLeave(object sender, MouseEventArgs e)
        {
            VisibilityAndIsOpen();
        }

        private void exp_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = exp;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Экспанента";
        }

        private void exp_MouseLeave(object sender, MouseEventArgs e)
        {
            VisibilityAndIsOpen();
        }

        private void log_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = log;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Логарифм";
        }

        private void log_MouseLeave(object sender, MouseEventArgs e)
        {
            VisibilityAndIsOpen();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
