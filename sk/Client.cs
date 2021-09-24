using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace sk
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string notes { get; set; }
        public DateTime date_delete { get; set; }
        public Client()
        {

        }
    }
    class ClientContext:DbContext
    {
        public ClientContext():base("EducationDB"){ }
        public DbSet<Client> Clients { get; set; }
    }
    public class ClientsCache
    {
        private static Dictionary<int, Client> allClients;
        public ClientsCache()
        {
            allClients = readClients();
        }
        public Dictionary<int, Client> getCache()
        {
            return allClients;
        }
        private Dictionary<int,Client> readClients()
        {
           Dictionary<int, Client> list = new Dictionary<int, Client>();
            using (ClientContext cc = new ClientContext())
            {
                var clients = cc.Clients;
                foreach(Client c in clients)
                {
                    list.Add(c.id,c);
                }
            }
            return list;
        }
    }
}
