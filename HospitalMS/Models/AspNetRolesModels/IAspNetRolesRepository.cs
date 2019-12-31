using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.AspNetRolesModels
{
    public interface IAspNetRolesRepository
    {
        AspNetRoles GetAspNetRoles(string id);
        IEnumerable<AspNetRoles> GetAllAspNetRoles();
    }
}
