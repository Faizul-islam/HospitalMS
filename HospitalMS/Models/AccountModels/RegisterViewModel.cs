﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.AccountModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        //[ValidEmailDomain(allowedDomain: "gmail.com",
        //ErrorMessage = "Email domain must be pragimtech.com")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        [Display(Name = "Birth-Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public GenderEnum? Gender { get; set; }

        public BloodGroupEnumClass? BloodGroup { get; set; }
        public String PresentAddress { get; set; }
        public String PermanentAddress { get; set; }
        public String PhotoPath { get; set; }
        public int IUser { get; set; }
        public DateTime? IDate { get; set; }
        public int EUsaer { get; set; }
        public DateTime EDate { get; set; }
    }
}
