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
        public List<Visit> Visits { get; set; } = new List<Visit>();
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

            Client a = dict[id];
            return a;
        }
    }
    class ClientContext:DbContext
    {
        public ClientContext():base("EducationDB"){ }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
      static  class  ClientsCache
    {
        private static Dictionary<int, Client> allClients= new Dictionary<int, Client>();
        private static Dictionary<int, int> allvisits = new Dictionary<int, int>();
        public static Dictionary<int, Client> getCache()
        {
            if(allClients.Count==0)
            {
                using (ClientContext cc = new ClientContext())
                {
                    var clients = cc.Clients;
                    foreach (Client c in clients)
                    {
                        allClients.Add(c.id, c);
                    }
                    var t = cc.Clients.Include(x => x.Visits).ToList();
                    foreach(Client c in t)
                    {
                        int n = c.Visits.Count();
                    }
                }
            }
            return allClients;
        }
        public static Dictionary<int, Client> updateCache()
        {
            allClients.Clear();
            using (ClientContext cc = new ClientContext())
            {
                var clients = cc.Clients;
                foreach (Client c in clients)
                {
                    allClients.Add(c.id, c);
                }
                var t = cc.Clients.Include(x => x.Visits).ToList();
                foreach(Client c in t)
                {
                    int n = c.Visits.Count();
                }
            }
            return allClients;
        }
        public static Dictionary <int, int> getOrders()
        {
            allvisits.Clear();
            using (ClientContext cc = new ClientContext())
            {
                var t = cc.Clients.Include(x => x.Visits).ToList();
                foreach (Client c in t)
                {
                    allvisits.Add(c.id, c.Visits.Count());
                }
            }
            return allvisits;
        }
    }
}
