using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryNamespace
{
    public class ClientsService
    {
        private List<Client> Clients;

        public ClientsService() 
        {
            Clients = new List<Client>();
        }

        public Client FindClient(String name)
        {
            foreach (Client client in Clients)
            {
                if (client.GetName() == name)
                {
                    return client;
                }
            }
            return null;
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void RemoveClient(Client client)
        {
            if (FindClient(client.GetName()) != null)
            {
                Clients.Remove(client);
            }
        }
     
    }
}
