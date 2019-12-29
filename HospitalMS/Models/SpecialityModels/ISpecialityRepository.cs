using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.SpecialityModels
{
    public interface ISpecialityRepository
    {
        Speciality GetSpeciality(int id);
        IEnumerable<Speciality> GetAllSpeciality();
        Speciality Add(Speciality speciality);
        Speciality Uodate(Speciality specialityChanges);
        Speciality Delete(int id);
    }
}
