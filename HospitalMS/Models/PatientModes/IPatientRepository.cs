using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.PatientModes
{
    public interface IPatientRepository
    {
        Patient GetPatient(int id);
        IEnumerable<Patient> GetAllPatient();
        Patient Add(Patient patient);
        Patient Uodate(Patient patientChanges);
        Patient Delete(int id);
    }
}
