using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace sk
{
    public class Visit
    {
        public int id { get; set; }
        public Client id_client { get; set; }
        public DateTime date_visit { get; set; }
        public TimeSpan duration { get; set; }
        public decimal price { get; set; }
        public string notes { get; set; }
        public DateTime date_delete { get; set; }
        public Visit()
        {
        }
        public Visit(int idd)
        {
            this.id = idd;
        }
    }
    class VisitContext:DbContext
    {
        public VisitContext() : base("EducationDB") { }
        public DbSet<Visit> Visits { get; set; }
    }
    public class VisitsCache
    {
        private static Dictionary<int, Visit> allVisits;
        public VisitsCache()
        {
            allVisits = readVisits();
        }
        private Dictionary<int, Visit> getCache()
        {
            return allVisits;
        }
        private Dictionary<int, Visit> readVisits()
        {
            Dictionary<int, Visit> dict = new Dictionary<int, Visit>();
            using (VisitContext vc = new VisitContext())
            {
                var visits=vc.Visits;
                foreach(Visit v in visits)
                {
                    dict.Add(v.id, v);
                }
            }
            return dict;
        }
    }
    
}
