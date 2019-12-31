using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalMS.Models.AspNetUserRolesModels
{
    public class AspNetUserRoles
    {
        [NotMapped]
        [Key]
      
        public int? Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
