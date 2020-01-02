using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.PatientModes
{
    public class PatientViewModel
    {
        #region Patient

        public int? Id { get; set; }
        [Display(Name = "Name")]
        public string PersonId { get; set; }
        public int? ProblemCategoryId { get; set; }
        [Display(Name = "Problem Description")]
        public string ProblemDescription { get; set; }
        public int? EmployeId { get; set; }
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        //public string PhotoPath { get; set; }

        public int? IUser { get; set; }
        public DateTime? IDate { get; set; }
        public int? EUser { get; set; }
        public DateTime? EDate { get; set; }

        #endregion


        #region Other

        public int? Ids { get; set; }
        public string TempPersonId { get; set; }
        public IFormFile Photo { get; set; }
        public Patient Patient { get; internal set; }
        public string ExistingPhotoPath { get; set; }
        public string PageTitle { get; set; }
        #endregion
    }
}
