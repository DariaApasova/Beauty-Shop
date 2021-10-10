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
        public int id { get; set; }
        public string beginning { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string ending { get; set; }
        public DateTime date_delete { get; set; }
        public TimetableBranch()
        {

        }
    }
    public class TTBContext:DbContext
    {
        public TTBContext() : base("EducationDB") { }
        public DbSet<TimetableBranch> TTBs { get; set; }
    }
    static class TimetableBranchCache
    {
        private static Dictionary<int, TimetableBranch> allTTB= new Dictionary<int, TimetableBranch>();
        public static Dictionary<int, TimetableBranch> getCache()
        {
            if(allTTB.Count==0)
            {
                using (TTBContext ttb = new TTBContext())
                {
                    var tt = ttb.TTBs;
                    foreach (TimetableBranch t in tt)
                    {

                        allTTB.Add(t.id, t);
                    }
                }
            }
            return allTTB;
        }
        public static Dictionary<int, TimetableBranch> updateCache()
        {
            allTTB.Clear();
            using (TTBContext ttb = new TTBContext())
            {
                var tt = ttb.TTBs;
                foreach (TimetableBranch t in tt)
                {

                    allTTB.Add(t.id, t);
                }
            }
            return allTTB;
        }
    }
}
