﻿using System;
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
using WpfGraphView.Windows.OxyPlotWindow;

namespace WpfGraphView
{
    /// <summary>
    /// Логика взаимодействия для SinWindow.xaml
    /// </summary>
    public partial class SinWindow : Window
    {
        public SinWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sinButton_Click(object sender, RoutedEventArgs e)
        {

            SinOxyplotWindow oxyplotPage = new SinOxyplotWindow();
            oxyplotPage.Show();
        }
    }
}
