using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace sk
{
    public class Attendance
    {
        public int id { get; set; }
        public Visit visit { get; set; }
        public Service service { get; set; }
        public Worker worker { get; set; }
        public Cabinet cabinet { get; set; }
        public decimal price { get; set; }
        public DateTime date_delete { get; set; }
        public Attendance()
        {

        }
    }
    class AttendaceContext:DbContext
    {
        public AttendaceContext() : base("EducationDB") { }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
    static class AttendanceCache
    {
        private static Dictionary<int, Attendance> allatt = new Dictionary<int, Attendance>();
        public static Dictionary<int,Attendance> lstWorkers()
        {
            allatt.Clear();
            using (AttendaceContext ac = new AttendaceContext())
            {
                var attendance = ac.Attendances.Include(x => x.worker).Include(x => x.visit).Include(x => x.service).Include(x => x.cabinet).ToList();
                foreach(Attendance a in attendance)
                {
                        allatt.Add(a.id,a);   
                }
            }
            return allatt;
        }
    }
}
