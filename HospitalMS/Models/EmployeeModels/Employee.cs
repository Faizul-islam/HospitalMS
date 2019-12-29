using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.EmployeeModels
{
    public class Employee
    {
        public int Id { get; set; }

        public string PersonId { get; set; }
        public int SpecialtyId { get; set; }
        public int PositionId { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal Salary { get; set; }
        public string PhotoPath { get; set; }

        public int? IUser { get; set; }
        public DateTime? IDate { get; set; }
        public int? EUser { get; set; }
        public DateTime? EDate { get; set; }

        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public string PersonName { get; set; }

        public List<EmployeeView> EmployeeList { get; set; }

    }

    public class EmployeeView
    {
        public int Id { get; set; }

        public string PersonId { get; set; }
        public int SpecialtyId { get; set; }
        public int PositionId { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal Salary { get; set; }
        public string PhotoPath { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public string PersonName { get; set; }

    }
}
