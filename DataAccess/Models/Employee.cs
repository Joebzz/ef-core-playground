using System.ComponentModel.DataAnnotations;

namespace EFCore.Playground.DataAccess.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public int ManagerId { get; set; }
        public Employee Manager { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}