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


namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;

        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            /* if(txtName.Text.Length < 2)
                 MessageBox.Show(txtName.Text + " is too short");
             else
                 MessageBox.Show("Здрасти " + txtName.Text + "!!! \nТова е твоята първа програма на Visual Studio 2012!"); */
            string s = "";
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    s = s + ((TextBox)item).Text;
                    s = s + '\n';
                }
            }
            MessageBox.Show(s, " that's the contents of all TXT BOXES");
        }
        private void factorial_butt_Click(object sender, RoutedEventArgs e)
        {
            int s = 0;
            if (!int.TryParse(factorial_txtbox.Text, out s) || int.Parse(factorial_txtbox.Text) < 1)
            {
                MessageBox.Show("Enter positive integer! ");
            }
            else
            {
                double num = int.Parse(factorial_txtbox.Text);
                for (double i = num - 1; i > 0; --i)
                {
                    num *= i;
                }
                MessageBox.Show("factor = " + num.ToString());
            }
        }
        private void pow_butt_Click(object sender, RoutedEventArgs e)
        {
            int s = 0;
            if (!int.TryParse(factorial_txtbox.Text, out s) || !int.TryParse(pow_txtbox.Text, out s))
                MessageBox.Show("enter a number ");
            else
                MessageBox.Show("pow = " + Math.Pow(double.Parse(factorial_txtbox.Text), double.Parse(pow_txtbox.Text)));
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit", "My Application", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Bot_butt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is Windows Presentation Foundation!");
            textBlock1.Text = DateTime.Now.ToString();
        }

        private void greet_btn_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);

            //MyMessage anotherWindow = new MyMessage();
            //anotherWindow.Show();
        }
    }
}
