using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace sk
{
    public class Cabinet
    {
        public int id { get; set; }
        public string cabinet_name { get; set; }
        public int capacity { get; set; }
        public Branch branch { get; set; }
        public string notes { get; set; }
        public DateTime date_delete { get; set; }
        public Cabinet()
        {

        }
    }
    class CabinetsContext : DbContext
    {
        public CabinetsContext() : base("EducationDB") { }
        public DbSet<Branch> Branches { get; set;  }
        public DbSet<Cabinet> Cabinets { get; set; }
    }
    static class CabinetsCache
    {
        private static Dictionary<int, Cabinet> allCabinets=new Dictionary<int, Cabinet>();
        public static Dictionary<int,Cabinet> getCache()
        {
            if(allCabinets.Count==0)
            {
                using (CabinetsContext cc = new CabinetsContext())
                {
                    var c = cc.Cabinets.Include(x => x.branch).ToList();
                    foreach (Cabinet ca in c)
                    {
                        allCabinets.Add(ca.id, ca);
                    }
                }
            }
            return allCabinets;
        }
        public static Dictionary<int, Cabinet> updateCache()
        {
            allCabinets.Clear();
            using (CabinetsContext cc = new CabinetsContext())
            {
                var c = cc.Cabinets.Include(x => x.branch).ToList();
                foreach(Cabinet ca in c)
                {
                    allCabinets.Add(ca.id, ca);
                }
            }
            return allCabinets;
        }
    }
}
