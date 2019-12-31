using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.DoctorScheduleModels
{
    public interface IDoctorsScheduleRepository
    {
        DoctorsSchedule GetDoctorsSchedule(int id);
        IEnumerable<DoctorsSchedule> GetAllDoctorsSchedule();
        DoctorsSchedule Add(DoctorsSchedule doctorsSchedule);
        DoctorsSchedule Update(DoctorsSchedule doctorsScheduleChanges);
        DoctorsSchedule Delete(int id);
    }
}
