using HospitalMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.SpecialityModels
{
    public class SQLSpecialityRepository : ISpecialityRepository
    {
        private readonly AppDbContext context;

        public SQLSpecialityRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Speciality Add(Speciality speciality)
        {
            context.Speciality.Add(speciality);
            context.SaveChanges();
            return speciality;
        }

        public Speciality Delete(int id)
        {
            Speciality speciality = context.Speciality.Find(id);
            if(speciality != null)
            {
                context.Speciality.Remove(speciality);
                context.SaveChanges();
            }
            return speciality;
        }

        public IEnumerable<Speciality> GetAllSpeciality()
        {
            return context.Speciality;
        }

        public Speciality GetSpeciality(int id)
        {
            return context.Speciality.Find(id);
        }

        public Speciality Uodate(Speciality specialityChanges)
        {
            var speciality = context.Speciality.Attach(specialityChanges);
            speciality.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return specialityChanges;
        }
    }
}
