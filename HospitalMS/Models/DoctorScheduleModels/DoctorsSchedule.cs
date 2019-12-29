using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.DoctorScheduleModels
{
    public class DoctorsSchedule
    {
        public int Id { get; set; }
        [Display(Name="Employee")]
        public int EmployeeId { get; set; }

        public DateTime? Day { get; set; }
        public DateTime? Time { get; set; }

        public int IUser { get; set; }
        public DateTime IDate { get; set; }
        public int EUser { get; set; }
        public DateTime EDate { get; set; }
    }
}
