using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Playground.DataAccess.Models
{
    public class Department
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        public string Title { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}