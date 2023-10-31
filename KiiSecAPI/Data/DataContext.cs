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
        public DbSet<VisitorsGroup> VisitorsGroups { get; set; }
        public DbSet<VisitStatus> VisitsStatus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<EmployeePermissions> EmployeePermissions { get; set; }
        public DbSet<GroupsOfVisitors> GroupsOfVisitors { get; set; }


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

            modelBuilder.Entity<GroupsOfVisitors>()
                .HasKey(gv => new { gv.GroupId, gv.VisitorId });
            modelBuilder.Entity<GroupsOfVisitors>()
                .HasOne(g => g.VisitorsGroup)
                .WithMany(gv => gv.GroupsOfVisitors)
                .HasForeignKey(g => g.GroupId);
            modelBuilder.Entity<GroupsOfVisitors>()
                .HasOne(v => v.Visitor)
                .WithMany(gv => gv.GroupsOfVisitors)
                .HasForeignKey(v => v.VisitorId);

        }
    }
}
