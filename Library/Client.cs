using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    public class Client
    {
        private String Name;

        public Client(String name)
        {
            Name = name;
        }

        public void SetName(String name) => Name = name;
        public String GetName() => Name;
    }
}
