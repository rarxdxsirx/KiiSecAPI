using KiiSecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KiiSecAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitRequest> VisitRequests { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitStatus> VisitsStatus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<EmployeePermissions> EmployeePermissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
        }
    }
}
