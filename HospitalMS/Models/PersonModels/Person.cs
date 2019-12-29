using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.PersonModels
{
    public class Person
    {
        public Int64? Id { get; set; }

        public String Name { get; set; }
        public String PhoneNo { get; set; }
        public String Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BirthDate { get; set; }
        public GenderEnum? Gender { get; set; }
        public BloodGroupEnumClass? BloodGroup { get; set; }
        public String PresentAddress { get; set; }
        public String PermanentAddress { get; set; }
       
        public int IUser { get; set; }
        public DateTime? IDate { get; set; }
        public int EUser { get; set; }
        public DateTime? EDate { get; set; }



    }
}
