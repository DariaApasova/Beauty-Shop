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
        public Branch id_branch { get; set; }
        public string notes { get; set; }
        public DateTime date_delete { get; set; }
        public Cabinet()
        {

        }
    }
    class CabinetsContext : DbContext
    {
        public CabinetsContext() : base("EducationDB") { }
        public DbSet<Cabinet> Cabinets { get; set; }
    }
    public class CabinetsCache
    {
        private static Dictionary<int, Cabinet> allCabinets;
        public CabinetsCache()
        {
            allCabinets = readCabinets();
        }
        public Dictionary<int,Cabinet> getCache()
        {
            return allCabinets;
        }
        private Dictionary<int, Cabinet> readCabinets()
        {
            Dictionary<int, Cabinet> dict = new Dictionary<int, Cabinet>();
            using (CabinetsContext cc = new CabinetsContext())
            {
                var c = cc.Cabinets;
                foreach(Cabinet ca in c)
                {
                    dict.Add(ca.id, ca);
                }
            }
            return dict;
        }
    }
}
