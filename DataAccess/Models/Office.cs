using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Playground.DataAccess.Models
{
    public class Office
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OfficeId { get; set; }

        public string Title { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}