using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Authentification_Pattern_ChainOfRespons.View
{
    /// <summary>
    /// Interaction logic for Pincode.xaml
    /// </summary>
    public partial class Pincode : Window
    {
        private int _pincode;
        public Pincode(int pincode, string userName)
        {
            InitializeComponent();
            this._pincode = pincode;
            userLogin.Text = userName;
        }

        private void PasswordBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_pincode == Int16.Parse(PincodePassBox.Password))
            {
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid PIN", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
