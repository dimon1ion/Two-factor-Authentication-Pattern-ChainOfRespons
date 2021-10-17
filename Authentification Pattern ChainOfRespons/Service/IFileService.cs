using Authentification_Pattern_ChainOfRespons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentification_Pattern_ChainOfRespons.Service
{
    public interface IFileService
    {
        List<User> Open(string path);
        void Save(string path, List<User> users);
    }
}
