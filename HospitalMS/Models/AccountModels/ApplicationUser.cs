using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.AccountModels
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Blood Groupe")]
        public BloodGroupEnumClass? BloodGroup { get; set; }

        public GenderEnum? Gender { get; set; }

        [Display(Name = "Present Address")]
        public String PresentAddress { get; set; }

        [Display(Name = "PermanentAddress")]
        public String PermanentAddress { get; set; }

        // public String PhotoPath { get; set; }
        public int? IUser { get; set; }
        public DateTime? IDate { get; set; }
        public int? EUser { get; set; }
        public DateTime? EDate { get; set; }
    }
}
