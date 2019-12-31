using System.ComponentModel.DataAnnotations;

namespace HospitalMS.Models.AspNetRolesModels
{
    public class AspNetRoles
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
