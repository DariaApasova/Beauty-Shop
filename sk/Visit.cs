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
        public Client client { get; set; }
        public DateTime date_visit { get; set; }
        public DateTime duration { get; set; }
        public decimal price { get; set; }
        public string notes { get; set; }
        public DateTime date_delete { get; set; }
        public Visit()
        {
        }
    }
    class VisitContext:DbContext
    {
        public VisitContext() : base("EducationDB") { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Visit> Visits { get; set; }
        
    }
}
