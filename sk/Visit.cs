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
        public Branch branch { get; set; }
        public DateTime date_visit { get; set; }
        public string duration { get; set; }
        public decimal price { get; set; }
        public string notes { get; set; }
        public DateTime date_delete { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public List<Cabinet> Cabinets { get; set; } = new List<Cabinet>();
     //   public List<Client> Clients { get; set; } = new List<Client>();
        public Visit()
        {
        }
    }
    class VisitContext : DbContext
    {
        public VisitContext() : base("EducationDB") { }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
