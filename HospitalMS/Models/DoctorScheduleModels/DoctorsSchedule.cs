using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.DoctorScheduleModels
{
    public class DoctorsSchedule
    {
        public int Id { get; set; }
        [Display(Name="Employee Name")]
        public int EmployeeId { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Day { get; set; }
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public DateTime? Time { get; set; }

        public int IUser { get; set; }
        public DateTime? IDate { get; set; }
        public int EUser { get; set; }
        public DateTime? EDate { get; set; }

        #region  other
        #endregion
        public List<DoctorsScheduleView> DoctorsScheduleList { get; set; }
        public class DoctorsScheduleView
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
}
