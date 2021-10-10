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
     static class WorkersCache
    {
        private static Dictionary<int, Worker> allWorkers= new Dictionary<int, Worker>();
        public static Dictionary<int, Worker> getCache()
        {
            if(allWorkers.Count==0)
            {
                using (WorkerContext wc = new WorkerContext())
                {
                    var w = wc.Workers;
                    foreach (Worker s in w)
                    {
                        allWorkers.Add(s.id, s);
                    }
                }
            }
            return allWorkers;
        }
        public static Dictionary<int, Worker> updateCache()
        {
            allWorkers.Clear();
            using (WorkerContext wc = new WorkerContext())
            {
                var w = wc.Workers;
                foreach (Worker s in w)
                {
                    allWorkers.Add(s.id, s);
                }
            }
            return allWorkers;
        }
    }
}
