using Authentification_Pattern_ChainOfRespons.Models;
using Authentification_Pattern_ChainOfRespons.View;
using Authentification_Pattern_ChainOfRespons.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Authentification_Pattern_ChainOfRespons.Handler
{
    class PINHandler : Handler
    {
        public override void Handle(Receiver receiver, User user)
        {
            if (receiver.PINHandler == true)
            {
                IFileService fileService = new JsonFileService();
                List<User> baseUsers = fileService.Open("users.json");
                int pinCode = 0;
                foreach (User baseUser in baseUsers)
                {
                    if (baseUser.Login == user.Login)
                    {
                        pinCode = baseUser.PinCode;
                    }
                }
                Pincode pincodeView = new Pincode(pinCode, user.Login);
                if (pincodeView.ShowDialog() == true)
                {
                    MessageBox.Show("You are successfully signed in", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (base.Successor != null)
                {
                    base.Successor.Handle(receiver, user);
                }
            }
        }
    }
}
