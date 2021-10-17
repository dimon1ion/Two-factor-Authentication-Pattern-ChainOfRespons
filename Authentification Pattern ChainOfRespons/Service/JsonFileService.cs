using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Authentification_Pattern_ChainOfRespons.Models;
using System.IO;

namespace Authentification_Pattern_ChainOfRespons.Service
{
    class JsonFileService : IFileService
    {
        public List<User> Open(string path)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<User>));
            List<User> users;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    users = (List<User>)jsonSerializer.ReadObject(fs);
                }
            }
            catch (Exception)
            {
                return new List<User>();
            }
            return users;
        }

        public void Save(string path, List<User> users)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                jsonSerializer.WriteObject(fs, users);
            }
        }
    }
}
