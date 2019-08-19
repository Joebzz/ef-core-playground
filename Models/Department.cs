using System.Collections.Generic;

namespace EFCore.Playground.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Title { get; set; }

        public int ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}