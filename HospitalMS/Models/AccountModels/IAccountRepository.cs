using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.AccountModels
{
    public interface IAccountRepository
    {
        ApplicationUser GetPerson(int Id);
        IEnumerable<ApplicationUser> GetAllPerson();
        ApplicationUser Update(ApplicationUser personChanges);

    }
}
