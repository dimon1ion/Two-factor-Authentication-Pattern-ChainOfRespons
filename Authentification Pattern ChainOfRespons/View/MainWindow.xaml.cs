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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Authentification_Pattern_ChainOfRespons.Models;
using Authentification_Pattern_ChainOfRespons.Service;
using Authentification_Pattern_ChainOfRespons.Handler;

namespace Authentification_Pattern_ChainOfRespons.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IFileService fileService { get; set; }
        public string path { get; set; }
        public List<User> users { get; set; }
        public Receiver Receiver { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            path = "users.json";
            fileService = new JsonFileService();
            users = fileService.Open(path);
            Receiver = new Receiver(true, true);
        }

        private bool CheckLogin(string login)
        {
            foreach (User user in users)
            {
                if (user.Login == login)
                {
                    return true;
                }
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = String.Empty;
            if (!(SignUpLogin.Text.Length >= 4))
            {
                errorMessage += "Login must have at least 4 characters\n";
            }
            else
            {
                if (CheckLogin(SignUpLogin.Text) == true)
                {
                    errorMessage += "This login is already registered\n";
                }
            }
            if (!(SignUpPassword.Password.Length >= 8))
            {
                errorMessage += "Password must have at least 8 characters\n";
            }
            if (!(SignUpPinCode.Password.Length == 4))
            {
                errorMessage += "Pin code must have 4 digits\n";
            }
            if (errorMessage != String.Empty)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                users.Add(new User(SignUpLogin.Text, SignUpPassword.Password, Int16.Parse(SignUpPinCode.Password)));
                fileService.Save(path, users);
                MessageBox.Show("User created successfully", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SignUpPinCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CheckLogin(SignInLogin.Text) == false)
            {
                MessageBox.Show("Login wasn't found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            PasswordHandler passwordHandler = new PasswordHandler();
            PINHandler pinHandler = new PINHandler();
            passwordHandler.Successor = pinHandler;
            passwordHandler.Handle(Receiver, new User(SignInLogin.Text, SignInPassword.Password, 0));
        }
    }
}
