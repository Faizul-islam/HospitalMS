using HospitalMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.DoctorScheduleModels
{
    public class SQLDoctorsScheduleRepository : IDoctorsScheduleRepository
    {
        private readonly AppDbContext context;

        public SQLDoctorsScheduleRepository(AppDbContext context)
        {
            this.context = context;
        }
        public DoctorsSchedule Add(DoctorsSchedule doctorsSchedule)
        {
            context.DoctorsSchedule.Add(doctorsSchedule);
            context.SaveChanges();
            return doctorsSchedule;
;
        }

        public DoctorsSchedule Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorsSchedule> GetAllDoctorsSchedule()
        {
            return context.DoctorsSchedule;
        }

        public DoctorsSchedule GetDoctorsSchedule(int id)
        {
            return context.DoctorsSchedule.Find(id);
        }

        public DoctorsSchedule Update(DoctorsSchedule doctorsScheduleChanges)
        {
            var doctorschedul = context.DoctorsSchedule.Attach(doctorsScheduleChanges);
            doctorschedul.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return doctorsScheduleChanges;
        }
    }
}
