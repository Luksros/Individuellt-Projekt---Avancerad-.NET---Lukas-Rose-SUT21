using Individuellt_Projekt___Avancerad_.NET___Lukas_Rose_SUT21;
using Microsoft.EntityFrameworkCore;

namespace Indivuduellt_Projekt_API.Data
{
    public class IPDbContext : DbContext
    {
        public IPDbContext(DbContextOptions<IPDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //Seed Product
            

        //    modelBuilder.Entity<Project>().HasData(new Project() { Id = 1, ProjectName = "Lion Bank Inc User App" });

        //    modelBuilder.Entity<TimeReport>().HasData(new TimeReport() { ID = 1, Week = 14, WorkHours = 20, ProjectId = 1, EmployeeId = 1 });

        //    modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 1, FName = "Lukas", LName = "Rose", Title = JobTitle.Developer });
        //}
    }
}
