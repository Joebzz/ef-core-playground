using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Playground.DataAccess.Models
{
    public class Employee
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        // public string Title { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }

        public string SocialSecurityNumber { get; set; }

        private string _username;
        [Required]
        public string Username
        {
            get
            {
                if (string.IsNullOrEmpty(_username))
                    _username = char.ToLower(Firstname[0]) + Surname.ToLower();
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
        [Display(Name = "Roles")]
        public ICollection<EmployeeRole> EmployeeRoles { get; } = new List<EmployeeRole>();

        /// <summary>
        /// For checking concurrency
        /// </summary>
        /// <value></value>
        [Timestamp]
        [ConcurrencyCheck]
        public byte[] RowVersion { get; set; }
    }
}