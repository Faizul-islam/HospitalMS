using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HospitalMS.Models.AccountModels;
using HospitalMS.Models.EmployeeModels;
using HospitalMS.Models.PatientModes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static HospitalMS.Models.PatientModes.Patient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalMS.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountRepository _accountRepository;

        public PatientsController(IPatientRepository patientRepository, IHostingEnvironment hostingEnvironment, IEmployeeRepository employeeRepository, IAccountRepository accountRepository)
        {
            _patientRepository = patientRepository;
            this.hostingEnvironment = hostingEnvironment;
            _employeeRepository = employeeRepository;
            _accountRepository = accountRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            Patient model = new Patient();
            List<PatientView> patientList = (from e in _employeeRepository.GetAllEmployees() 
                                             join pa in _patientRepository.GetAllPatient() on e.Id equals pa.EmployeId
                                             join p in _accountRepository.GetAllPerson() on pa.PersonId equals p.Id
                                             select new PatientView
                                             {
                                                 Id = pa.Id,
                                                 PersonId = pa.PersonId,
                                                 EmployeId = pa.EmployeId,
                                                 ProblemCategoryId = pa.ProblemCategoryId,
                                                 ProblemDescription = pa.ProblemDescription,
                                                 Date = pa.Date,
                                                 Name = p.Name,
                                                 PhotoPath = pa.PhotoPath
                                             }).ToList();
            //var model = _patientRepository.GetAllPatient();
            model.PatientList = patientList;
            return View(model);
        }
        [AllowAnonymous]
        public ViewResult Details(int id)
        {
            PatientViewModel patientViewModel = new PatientViewModel()
            {
                Patient = _patientRepository.GetPatient(id),
                PageTitle = "Patient Details"
            };

            return View(patientViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Create()
        {
            Patient patient = new Patient();
            ApplicationUser user = new ApplicationUser();
            ViewBag.PersonList = _accountRepository.GetAllPerson().OrderBy(x => x.IDate).ToList();
            ViewBag.EmployeeList = _employeeRepository.GetAllEmployees().OrderBy(x => x.Name).ToList();
            ViewBag.problemList = _employeeRepository.GetAllEmployees().OrderBy(x => x.Name).ToList();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Patient newPatient = new Patient
                {
                    PersonId = model.PersonId,
                    ProblemCategoryId = model.ProblemCategoryId,
                    ProblemDescription = model.ProblemDescription,
                    EmployeId = model.EmployeId,
                    Date = model.Date,
                    IUser = 1,
                    IDate = DateTime.Now,
                    EUser = 0,
                    EDate = null,

                    PhotoPath = uniqueFileName
                };

                _patientRepository.Add(newPatient);
                return RedirectToAction("details", new { id = newPatient.Id });
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Edit(int id)
        {

            Patient patient = _patientRepository.GetPatient(id);
            PatientViewModel patientViewModel = new PatientViewModel
            {
                Ids = patient.Id,
                PersonId = patient.PersonId,
                ProblemCategoryId = patient.ProblemCategoryId,
                ProblemDescription = patient.ProblemDescription,
                EmployeId = patient.EmployeId,
                Date = patient.Date,

                ExistingPhotoPath = patient.PhotoPath
            };
            return View(patientViewModel);
        }
    }
}
