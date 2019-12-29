using HospitalMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.AccountModels
{
    public class SQLAccountRepository : IAccountRepository
    {
        private readonly AppDbContext context;

        public SQLAccountRepository(AppDbContext context)
        {
            this.context = context;
        }
      
        public IEnumerable<ApplicationUser> GetAllPerson()
        {
            return context.AspNetUsers;
        }

        public ApplicationUser GetPerson(int Id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Update(ApplicationUser personChanges)
        {
            var person = context.AspNetUsers.Attach(personChanges);
            person.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return personChanges;
        }
    }
}
