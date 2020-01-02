using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.PatientModes
{
    public class Patient
    {
        public int? Id { get; set; }
        [Display(Name = "name")]
        public string PersonId { get; set; }
        [Display(Name = "Problem Category")]
        public int? ProblemCategoryId { get; set; }
        public string ProblemDescription { get; set; }
        [Display(Name = "Employee namename")]
        public int? EmployeId { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public string PhotoPath { get; set; }

        public int? IUser { get; set; }
        public DateTime? IDate { get; set; }
        public int? EUser { get; set; }
        public DateTime? EDate { get; set; }

        public List<PatientView> PatientList { get; set; }
    }
    public class PatientView
    {
        public int? Id { get; set; }

        public string PersonId { get; set; }
        public int? SpecialtyId { get; set; }
        public int? PositionId { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal? Salary { get; set; }
        public string PhotoPath { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public string PersonName { get; set; }
        [Display(Name = "Employee namename")]
        public int? EmployeId { get; set; }
        [Display(Name = "Problem Category")]
        public int? ProblemCategoryId { get; set; }
        public string ProblemDescription { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
    }
}
