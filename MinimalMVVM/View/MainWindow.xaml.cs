using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MinimalMVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MinimalMVVM.ViewModel.Presenter tohigh = new MinimalMVVM.ViewModel.Presenter();
        MinimalMVVM.ViewModel.PresenterToLower tolow = new MinimalMVVM.ViewModel.PresenterToLower();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = tohigh;
            ToHigh.IsEnabled = false;
        }
        private void Button_Click_to_high(object sender, RoutedEventArgs e)
        {
            DataContext = tohigh;
            ToLow.IsEnabled = true;
            ToHigh.IsEnabled = false;
        }

        private void Button_Click_to_low(object sender, RoutedEventArgs e)
        {
            DataContext = tolow;
            ToHigh.IsEnabled = true;
            ToLow.IsEnabled = false;
        }
    }
}
