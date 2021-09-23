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
        public Service()
        {
            
        }
        public Service(int id)
        {
            this.id = id;
        }
    }
    class ServiceContext:DbContext
    {
        public ServiceContext() : base("EducationDB"){ }
        public DbSet<Service> Services { get; set; }
    }
    public class ServicesCache
    {
        private static Dictionary<int, Service> allServices;
        public ServicesCache()
        {
            allServices= readServices();
        }
        public Dictionary<int, Service> getCache()
        {
            return allServices;
        }
        private Dictionary<int, Service> readServices()
        {
            Dictionary<int, Service> dict = new Dictionary<int,Service>();
            using (ServiceContext sc = new ServiceContext())
            {
                var services = sc.Services;
                foreach (Service s in services)
                {
                    dict.Add(s.id, s);
                }
            }
            return dict;
        }
        public void addService(Service s)
        {
            allServices.Add(s.id, s);
        }
        public Service getService(int id)
        {
            return allServices.Where(x => x.Key == id).FirstOrDefault().Value;
        }
        public int getMaxID()
        {
            int max = 0;
            foreach(Service s in allServices.Values)
            {
                if(s.id>max)
                {
                    max = s.id;
                }
            }
            return max;
        }
        public void replaceServices(Service s)
        {
            int index = 0;
            foreach(Service se in allServices.Values)
            {
                if(se.id==s.id)
                {
                    index = se.id;
                    allServices[index] = s;
                }
            }
        }
    }
}
