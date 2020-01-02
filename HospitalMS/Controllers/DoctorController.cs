using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalMS.Models.AccountModels;
using HospitalMS.Models.DoctorScheduleModels;
using HospitalMS.Models.EmployeeModels;
using HospitalMS.Models.PersonModels;
using HospitalMS.Models.PositionModels;
using HospitalMS.Models.SpecialityModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalMS.Controllers
{
    public class DoctorController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IPersonRepository _personRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IDoctorsScheduleRepository _doctorsScheduleRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        public DoctorController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment, IPersonRepository personRepository, IAccountRepository accountRepository, ISpecialityRepository specialityRepository, IPositionRepository positionRepository, IDoctorsScheduleRepository doctorsScheduleRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;
            _personRepository = personRepository;
            _employeeRepository = employeeRepository;
            _accountRepository = accountRepository;
            _specialityRepository = specialityRepository;
            _positionRepository = positionRepository;
            _doctorsScheduleRepository = doctorsScheduleRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Prescription()
        {
            return View();
        }


    }
}
