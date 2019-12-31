using HospitalMS.Models.AccountModels;
using HospitalMS.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.DoctorScheduleModels
{
    public class DoctorSheduleViewModel
    {
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Day { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Time)]
        public DateTime? Time { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public ApplicationUser Person { get; set; }
        public Employee Employee { get; set; }
    }
}
