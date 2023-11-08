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
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitStatus> VisitsStatus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<EmployeePermissions> EmployeePermissions { get; set; }
        public DbSet<VisitOfVisitor> VisitsOfVisitors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeePermissions>()
                .HasKey(ep => new { ep.EmployeeID, ep.PermissionID });
            modelBuilder.Entity<EmployeePermissions>()
                .HasOne(p => p.Permission)
                .WithMany(ep => ep.EmployeePermissions)
                .HasForeignKey(p => p.PermissionID);
            modelBuilder.Entity<EmployeePermissions>()
                .HasOne(e => e.Employee)
                .WithMany(ep => ep.EmployeePermissions)
                .HasForeignKey(e => e.EmployeeID);

            modelBuilder.Entity<VisitOfVisitor>()
                .HasKey(gv => new { gv.VisitId, gv.VisitorId });
            modelBuilder.Entity<VisitOfVisitor>()
                .HasOne(g => g.Visitor)
                .WithMany(gv => gv.VisitsOfVisitors)
                .HasForeignKey(g => g.VisitorId);
            modelBuilder.Entity<VisitOfVisitor>()
                .HasOne(v => v.Visit)
                .WithMany(gv => gv.VisitsOfVisitors)
                .HasForeignKey(v => v.VisitId);

        }
    }
}
