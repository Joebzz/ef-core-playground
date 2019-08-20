using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Playground.DataAccess.Models
{
    public class Role
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string Title { get; set; }

        public ICollection<EmployeeRole> EmployeeRoles { get; } = new List<EmployeeRole>();
    }
}