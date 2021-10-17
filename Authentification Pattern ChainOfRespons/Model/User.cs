using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentification_Pattern_ChainOfRespons.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string login, string password, short pinCode)
        {
            Login = login;
            Password = password;
            PinCode = pinCode;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public short PinCode { get; set; }
    }
}
