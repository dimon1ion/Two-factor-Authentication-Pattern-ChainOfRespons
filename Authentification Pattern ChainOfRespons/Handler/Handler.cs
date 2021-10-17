using Authentification_Pattern_ChainOfRespons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentification_Pattern_ChainOfRespons.Handler
{
    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void Handle(Receiver receiver, User user);
    }
}
