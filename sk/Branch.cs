using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace sk
{
    public class Branch
    {
        public int id { get; set; }
        public TimetableBranch timetable { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime date_delete { get; set; }
        public List<Visit> Visits { get; set; }
        public List<Cabinet> Cabinets { get; set; }
        public Branch()
        {
        }
    }
    class BranchContext:DbContext
    {
        public BranchContext() : base("EducationDB") { }
        public DbSet<TimetableBranch> TTBs { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
    static class BranchCache
    {
        private static Dictionary<int, Branch> allBranches= new Dictionary<int, Branch>();
        public static Dictionary<int,Branch> getCache()
        {
           if(allBranches.Count==0)
            {
                using (BranchContext dc = new BranchContext())
                {
                    var branches = dc.Branches.Include(x=>x.timetable).ToList();
                    foreach (Branch b in branches)
                    {
                       allBranches.Add(b.id, b);
                    }
                    var br = dc.Branches.Include(x => x.Cabinets).ToList();
                    foreach(Branch b in br)
                    {
                        int n = b.Cabinets.Count();
                    }
                }
            }
            return allBranches;
        }
        public static Dictionary<int, Branch> updateCache()
        {
            allBranches.Clear();
            using (BranchContext dc = new BranchContext())
            {
                var branches = dc.Branches.Include(x=>x.timetable).ToList();
                foreach (Branch b in branches)
                {
                    allBranches.Add(b.id, b);
                }
                var br = dc.Branches.Include(x => x.Cabinets).ToList();
                foreach(Branch b in br)
                {
                    int n = b.Cabinets.Count();
                }
            }
            return allBranches;
        }
    }
}
