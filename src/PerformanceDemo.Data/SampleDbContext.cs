using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Data.Models;

namespace PerformanceDemo.Data
{
    public class SampleDbContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }

        public SampleDbContext() : base("PerformanceDemoConnection")
        {
            //For testing
            Database.Log += Console.WriteLine;
        }
    }
}
