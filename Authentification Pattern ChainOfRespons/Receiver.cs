using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentification_Pattern_ChainOfRespons
{
    public class Receiver
    {
        public Receiver(bool passHandler, bool pINHandler)
        {
            PassHandler = passHandler;
            PINHandler = pINHandler;
        }

        public bool PassHandler { get; set; }
        public bool PINHandler { get; set; }
    }
}
