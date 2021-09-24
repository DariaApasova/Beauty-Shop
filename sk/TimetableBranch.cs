using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace sk
{
    public class TimetableBranch
    {
        public int id_timetable { get; set; }
        public string beginning { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string ending { get; set; }
        public DateTime date_delete { get; set; }
        public TimetableBranch()
        {

        }
        public TimetableBranch(string []pr)
        {
            this.id_timetable = Convert.ToInt32(pr[0]);
            this.beginning = pr[1];
            this.start = pr[2];
            this.end = pr[3];
            this.ending = pr[4];
            this.date_delete = Convert.ToDateTime(pr[5]);
        }
    }
    public class TTBContext:DbContext
    {
        public TTBContext() : base("EducationDB") { }
        public DbSet<TimetableBranch> TTBs { get; set; }
    }
    public class TimetableBranchCache
    {
        private static Dictionary<int, TimetableBranch> allTTB;
        public TimetableBranchCache()
        {
            allTTB = readTTB();

        }
        public Dictionary<int, TimetableBranch> readTTB()
        {
            Dictionary<int, TimetableBranch> list = new Dictionary<int, TimetableBranch>();
            using (TTBContext ttb = new TTBContext())
            {
                var tt = ttb.TTBs;
                foreach(TimetableBranch t in tt)
                {

                    list.Add(t.id_timetable, t);
                }
            }
            return list;
        }
        public TimetableBranch findByID(int id)
        {
            return allTTB.Where(x => x.Key == id).FirstOrDefault().Value;
        }
    }
}
