using Authentification_Pattern_ChainOfRespons.Models;
using Authentification_Pattern_ChainOfRespons.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Authentification_Pattern_ChainOfRespons.Handler
{
    class PasswordHandler : Handler
    {
        public override void Handle(Receiver receiver, User user)
        {
            if (receiver.PassHandler == true)
            {
                IFileService fileService = new JsonFileService();
                List<User> baseUsers = fileService.Open("users.json");
                foreach (User baseUser in baseUsers)
                {
                    if (baseUser.Login == user.Login)
                    {
                        if (baseUser.Password == user.Password && base.Successor != null)
                        {
                            base.Successor.Handle(receiver, user);
                            return;
                        }
                    }
                }
                MessageBox.Show("Password isn't right", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
