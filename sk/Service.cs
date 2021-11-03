using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.IO;
using System.Data.SQLite;

namespace sk
{
    public class Service
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string  duration { get; set; }
        public string notes { get; set; }
        public DateTime date_delete { get; set; }
        public List<Cabinet> Cabinets { get; set; } = new List<Cabinet>();
        public Service()
        {
        }
        public void addService(Service s)
        {
            Dictionary<int, Service> dict = ServicesCache.getCache();
            dict.Add(s.id, s);
        }
        public Service getService(int id)
        {
            Dictionary<int, Service> dict = ServicesCache.getCache();
            return dict.Where(x => x.Key == id).FirstOrDefault().Value;
        }
    }
    class ServiceContext:DbContext
    {
        public ServiceContext() : base("EducationDB"){ }
        public DbSet<Service> Services { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
    }
   static class ServicesCache
    {
        private static Dictionary<int, Service> allServices = new Dictionary<int, Service>();
        public  static Dictionary<int, Service> getCache()
        {
            if(allServices.Count==0)
            {
                using (ServiceContext sc = new ServiceContext())
                {
                    var services = sc.Services;
                    foreach (Service s in services)
                    {
                        allServices.Add(s.id, s);
                    }
                    var serv = sc.Services.Include(x => x.Cabinets).ToList();
                    foreach(Service s in serv)
                    {
                        int n = s.Cabinets.Count();
                    }
                }
            }
            return allServices;
        }
        public static Dictionary<int, Service> updateCache()
        {
            allServices.Clear();
            using (ServiceContext sc = new ServiceContext())
            {
                var services = sc.Services;
                foreach (Service s in services)
                {
                    allServices.Add(s.id, s);
                }
            }
            return allServices;
        }
    }
}
