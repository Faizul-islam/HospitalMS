using HospitalMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.AspNetUserRolesModels
{
    public class SQLAspNetUserRolesRepository : IAspNetUserRolesRepository
    {
        private readonly AppDbContext context;

        public SQLAspNetUserRolesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<AspNetUserRoles> GetAllAspNetUserRoles()
        {
            return null; //context.AspNetUserRoles;
        }

        public AspNetUserRoles GetAspNetUserRoles(string id)
        {
            return null; //context.AspNetUserRoles.Find(id);
        }
    }
}
