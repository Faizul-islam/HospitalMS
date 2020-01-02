using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.SpecialityModels
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}
