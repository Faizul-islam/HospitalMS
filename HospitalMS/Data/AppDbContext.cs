using HospitalMS.Models.AccountModels;
using HospitalMS.Models.DoctorScheduleModels;
using HospitalMS.Models.EmployeeModels;
using HospitalMS.Models.PatientModes;
using HospitalMS.Models.PersonModels;
using HospitalMS.Models.PositionModels;
using HospitalMS.Models.SpecialityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Data
{
   // public class AppDbContext : DbContext
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<DoctorsSchedule> DoctorsSchedule { get; set; }
    }
}
