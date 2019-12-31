using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public List<DoctorsScheduleViewhome> DoctorsScheduleList { get; set; }
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

   
    public class DoctorsScheduleViewhome
    {
        public int Id { get; set; }
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Day { get; set; }
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public DateTime? Time { get; set; }

        public string Name { get; set; }
        [NotMapped]
        public string PersonId { get; set; }

    }
}
