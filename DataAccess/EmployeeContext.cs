using Microsoft.EntityFrameworkCore;

using EFCore.Playground.DataAccess.Models;

namespace EFCore.Playground.DataAccess
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Employees;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Need to add the Many to Many mapping table EmployeeRoles primary key here.
            modelBuilder.Entity<EmployeeRole>()
                .HasKey(er => new { er.EmployeeId, er.RoleId });

            // Unique Employee Email
            modelBuilder.Entity<Employee>()
               .HasIndex(u => u.Email)
               .IsUnique();

            // Unique Employee Username
            modelBuilder.Entity<Employee>()
               .HasIndex(u => u.Username)
               .IsUnique();

            // Default Value for Office
            modelBuilder.Entity<Department>()
                .Property(b => b.OfficeId)
                .HasDefaultValue(-1);

            #region Seed Data
            // Offices
            var londonOffice = new Office { OfficeId = -1, Title = "London (HQ)", PostalCode = "SK2 5JY", PhoneNumber = "+1234567891" };
            modelBuilder.Entity<Office>().HasData(londonOffice);
            var newYorkOffice = new Office { OfficeId = -2, Title = "New York", PostalCode = "10001", PhoneNumber = "+1234567892" };
            modelBuilder.Entity<Office>().HasData(newYorkOffice);

            // Departments
            var hrDepartment = new Department { DepartmentId = -1, Title = "HR", OfficeId = londonOffice.OfficeId };
            modelBuilder.Entity<Department>().HasData(hrDepartment);
            var itDepartment = new Department { DepartmentId = -2, Title = "IT", OfficeId = londonOffice.OfficeId };
            modelBuilder.Entity<Department>().HasData(itDepartment);
            var softwareDepartment = new Department { DepartmentId = -3, Title = "Software", OfficeId = newYorkOffice.OfficeId };
            modelBuilder.Entity<Department>().HasData(softwareDepartment);

            // Roles
            var adminRole = new Role { RoleId = -1, Title = "Administrator" };
            modelBuilder.Entity<Role>().HasData(adminRole);
            var devRole = new Role { RoleId = -2, Title = "Developer" };
            modelBuilder.Entity<Role>().HasData(devRole);

            // Employees
            var stanSmith = new Employee
            {
                EmployeeId = -1,
                Title = "Mr",
                Firstname = "Stan",
                Surname = "Smith",
                Username = "ssmith",
                Email = "ssmith@company.com",
                PhoneNumber = "+1234567893",
                DepartmentId = hrDepartment.DepartmentId
            };
            modelBuilder.Entity<Employee>().HasData(stanSmith);

            var timBean = new Employee
            {
                EmployeeId = -2,
                Title = "Mr",
                Firstname = "Tim",
                Surname = "Bean",
                Username = "tbean",
                Email = "tbean@company.com",
                PhoneNumber = "+1234567894",
                DepartmentId = softwareDepartment.DepartmentId
            };
            modelBuilder.Entity<Employee>().HasData(timBean);

            var jackBlack = new Employee
            {
                EmployeeId = -3,
                Title = "Mr",
                Firstname = "Jack",
                Surname = "Black",
                Username = "jblack",
                Email = "jblack@company.com",
                PhoneNumber = "+1234567895",
                ManagerId = timBean.EmployeeId,
                DepartmentId = softwareDepartment.DepartmentId
            };
            modelBuilder.Entity<Employee>().HasData(jackBlack);

            var stanSmithEmployeeRole = new EmployeeRole { EmployeeId = stanSmith.EmployeeId, RoleId = adminRole.RoleId };
            modelBuilder.Entity<EmployeeRole>().HasData(stanSmithEmployeeRole);

            var timBeanEmployeeRoleDev = new EmployeeRole { EmployeeId = timBean.EmployeeId, RoleId = devRole.RoleId };
            modelBuilder.Entity<EmployeeRole>().HasData(timBeanEmployeeRoleDev);

            var timBeanEmployeeRoleAdmin = new EmployeeRole { EmployeeId = timBean.EmployeeId, RoleId = adminRole.RoleId };
            modelBuilder.Entity<EmployeeRole>().HasData(timBeanEmployeeRoleAdmin);

            var jackBlackEmployeeRole = new EmployeeRole { EmployeeId = jackBlack.EmployeeId, RoleId = devRole.RoleId };
            modelBuilder.Entity<EmployeeRole>().HasData(jackBlackEmployeeRole);

            #endregion Seed Data
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    }
}