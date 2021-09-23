using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace sk
{
    public class Worker
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string position { get; set; }
        public string notes { get; set; }
        public DateTime date_delete { get; set; }
        public Worker()
        {

        }
    }
    class WorkerContext:DbContext
    {
        public WorkerContext():base("EducationDB") { }
        public DbSet<Worker> Workers { get; set; } 
    }
   /* public class WorkersCache
    {
        private static Dictionary<int, object> allWorkers;
        public WorkersCache()
        {
            allWorkers = readWorkers();
        }
        /*private Dictionary<int, object> readWorkers()
        {

        }
    }*/
}
