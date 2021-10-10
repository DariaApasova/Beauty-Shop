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
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<TimetableWorker> TTWs { get; set; }
    }
}
