using HospitalMS.Models.AccountModels;
using HospitalMS.Models.PositionModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.EmployeeModels
{
    public class EmployeeViewModel
    {
        public ApplicationUser Person { get; set; }
        public Employee Employee { get; set; }
        public Position Position { get; set; }
        public string PageTitle { get; set; }

        #region Employee
        public int Id { get; set; }

        public string PersonId { get; set; }
        public int SpecialtyId { get; set; }
        public int PositionId { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal Salary { get; set; }
        public string PhotoPath { get; set; }


        #endregion

        #region Common Fild
        public int? IUser { get; set; }
        public DateTime? IDate { get; set; }
        public int? EUser { get; set; }
        public DateTime? EDate { get; set; }
        #endregion

        #region Person/User (Asp .Net User)
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }
        public BloodGroupEnumClass? BloodGroup { get; set; }
        public GenderEnum? Gender { get; set; }
        public String PresentAddress { get; set; }
        public String PermanentAddress { get; set; }

        #endregion


        #region Other
        public string TempPersonId { get; set; }
        public IFormFile Photo { get; set; }
        public string ExistingPhotoPath { get; set; }
        #endregion
    }
}
