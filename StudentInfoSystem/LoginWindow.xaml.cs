using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserLogin;
using static StudentInfoSystem.LoginViewModel;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(Login login)
        {
            this.DataContext = new LoginViewModel(login, CloseWindow);
            InitializeComponent();
        }

        private void CloseWindow()
        {
            this.Close();
        }
    }
}
