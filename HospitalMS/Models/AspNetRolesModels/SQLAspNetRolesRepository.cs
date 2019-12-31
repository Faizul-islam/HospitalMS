using HospitalMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.AspNetRolesModels
{
    public class SQLAspNetRolesRepository : IAspNetRolesRepository
    {
        private readonly AppDbContext context;

        public SQLAspNetRolesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<AspNetRoles> GetAllAspNetRoles()
        {
            return null; // context.AspNetRoles;
        }

        public AspNetRoles GetAspNetRoles(string id)
        {
            return null;// context.AspNetRoles.Find(id);
        }
    }
}
