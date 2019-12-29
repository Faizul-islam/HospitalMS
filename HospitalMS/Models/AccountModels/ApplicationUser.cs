using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.AccountModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public BloodGroupEnumClass? BloodGroup { get; set; }
        public GenderEnum? Gender { get; set; }
        public String PresentAddress { get; set; }
        public String PermanentAddress { get; set; }
        // public String PhotoPath { get; set; }
        public int? IUser { get; set; }
        public DateTime? IDate { get; set; }
        public int? EUser { get; set; }
        public DateTime? EDate { get; set; }
    }
}
