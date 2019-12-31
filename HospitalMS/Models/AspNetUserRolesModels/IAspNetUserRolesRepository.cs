using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.AspNetUserRolesModels
{
    public interface IAspNetUserRolesRepository
    {
        AspNetUserRoles GetAspNetUserRoles(string id);
        IEnumerable<AspNetUserRoles> GetAllAspNetUserRoles();
    }
}
