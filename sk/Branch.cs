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
        public TimetableBranch id_timetable { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime date_delete { get; set; }
        public Branch()
        { }
        public Branch(string[] pr, TimetableBranchCache ttb)
        {
            this.id = Convert.ToInt32(pr[0]);
            int t = Convert.ToInt32(pr[1]);
            this.id_timetable = ttb.findByID(t);
            this.name = pr[2];
            this.address = pr[3];
            this.date_delete = Convert.ToDateTime(pr[4]);
        }
    }
    class BranchContext:DbContext
    {
        public BranchContext() : base("EducationDB") { }
        public DbSet<Branch> Branches { get; set; }
    }
    public class BranchCache
    {
        private static Dictionary<int, Branch> allBranches;
        public BranchCache(TimetableBranchCache ttb)
        {
            allBranches = readBranch(ttb);
        }
        public Dictionary<int,Branch> readBranch(TimetableBranchCache ttb)
        {
           Dictionary<int,Branch> list = new Dictionary<int, Branch>();
            using (BranchContext dc = new BranchContext())
            {
                var branches = dc.Branches;
                foreach(Branch b in branches)
                {

                    list.Add(b.id, b);
                }
            }
            return list;
        }
    }
}
