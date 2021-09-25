using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace sk
{
    public class TimetableWorker
    {
        public int id { get; set; }
        public string day { get; set; }
        public string opening { get; set; }
        public string closing { get; set; }
        public Branch branch { get; set; }
        public Worker worker { get; set; }
        public DateTime date_delete { get; set; }
        public TimetableWorker()
        {

        }
    }
    class TTWContext:DbContext
    {
        public TTWContext() : base("EducationDB") { }
        public DbSet<TimetableWorker> TTWs { get; set; }
    }
    public class TimetableWorkerCache
    {
        private static Dictionary<int, TimetableWorker> allTTW;
        public TimetableWorkerCache()
        {
            allTTW = readTTW();
        }
        public Dictionary<int, TimetableWorker> readTTW()
        {
            Dictionary<int, TimetableWorker> list = new Dictionary<int, TimetableWorker>();
            using (TTWContext ttw = new TTWContext())
            {
                var tk = ttw.TTWs;
                foreach (TimetableWorker t in tk)
                {

                    list.Add(t.id, t);
                }
            }
            return list;
        }
    }
}
