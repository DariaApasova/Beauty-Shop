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
        public void addClient(Client s)
        {
            Dictionary<int, Client> dict = ClientsCache.getCache();
            dict.Add(s.id, s);
        }
        public Client getClient(int id)
        {
            Dictionary<int, Client> dict = ClientsCache.getCache();
            return dict.Where(x => x.Key == id).FirstOrDefault().Value;
        }
    }
    class ClientContext:DbContext
    {
        public ClientContext():base("EducationDB"){ }
        public DbSet<Client> Clients { get; set; }
    }
    class ClientsCache
    {
        private ClientsCache()
        {
            allClients = readClients();
        }
        private static Dictionary<int, Client> allClients= new Dictionary<int, Client>();
        public static Dictionary<int, Client> getCache()
        {
            if(allClients.Count==0)
            {
                ClientsCache a = new ClientsCache();
            }
            return allClients;
        }
        public static Dictionary<int, Client> updateCache()
        {
            allClients.Clear();
            ClientsCache a = new ClientsCache();
            return allClients;
        }
            
        private Dictionary<int,Client> readClients()
        {
            using (ClientContext cc = new ClientContext())
            {
                var clients = cc.Clients;
                foreach(Client c in clients)
                {
                    allClients.Add(c.id,c);
                }
            }
            return allClients;
        }
    }
}
