using HospitalMS.Data;
using HospitalMS.Models.AccountModels;
using HospitalMS.Models.EmployeeModels;
using HospitalMS.Models.PersonModels;
using HospitalMS.Models.PositionModels;
using HospitalMS.Models.SpecialityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IPersonRepository _personRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public EmployeesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment, IPersonRepository personRepository, IAccountRepository accountRepository, ISpecialityRepository specialityRepository, IPositionRepository positionRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;            
            this.hostingEnvironment = hostingEnvironment;
            _personRepository = personRepository;
            _employeeRepository = employeeRepository;
            _accountRepository = accountRepository;
            _specialityRepository = specialityRepository;
            _positionRepository = positionRepository;
        }
        public IActionResult Index()
        {
            //List<ApplicationUser> person = _accountRepository.GetAllPerson().ToList();

            //List<Employee> employee = _employeeRepository.GetAllEmployees().ToList();
            //var model = _employeeRepository.GetAllEmployees();
            Employee model = new Employee();
            List<EmployeeView> empList = (from e in _employeeRepository.GetAllEmployees()
                                             join p in _accountRepository.GetAllPerson() on e.PersonId equals p.Id
                                             select new EmployeeView
                                             {
                                                 Id = e.Id,
                                                 PersonId = e.PersonId,
                                                 PositionId = e.PositionId,
                                                 Name = p.Name,
                                                 PhotoPath = e.PhotoPath
                                             }).ToList();
            // var model = _employeeRepository.GetAllEmployees();
            model.EmployeeList = empList;
            return View(model);
        }

        public ViewResult Details(int id, string personid, int positionid)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Person = _employeeRepository.GetPerson(personid),
                Employee = _employeeRepository.GetEmployee(id),
                Position = _employeeRepository.GetPosition(positionid),
                PageTitle = "Employee Details"
            };

            return View(employeeViewModel);
        }




        [HttpGet]
        [AllowAnonymous]
        public ViewResult Create()
        {
            //List<ApplicationUser> li = new List<ApplicationUser>();
            //li = _context.AspNetUsers.ToList();
            //ViewBag.PersonList = li;
            ViewBag.PersonList = _accountRepository.GetAllPerson().OrderBy(x => x.IDate).ThenBy(x=> x.Name).ToList();
            ViewBag.SpecialityList = _specialityRepository.GetAllSpeciality().OrderBy(x => x.Name).ToList();
            ViewBag.PositionList = _positionRepository.GetAllPosition().OrderBy(x => x.PositionName).ToList();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(EmployeeViewModel model)
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

                Employee newEmployee = new Employee
                {
                    PersonId = model.PersonId,
                    SpecialtyId = model.SpecialtyId,
                    PositionId = model.PositionId,
                    Salary = model.Salary,
                    IUser = 1,
                    IDate = DateTime.Now,
                    EUser = 0,
                    EDate = null,

                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id, personid = newEmployee.PersonId, positionid = newEmployee.PositionId });
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id, string personid, int positionid)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            ApplicationUser person = _employeeRepository.GetPerson(personid);
            Position position = _employeeRepository.GetPosition(positionid);
            EmployeeViewModel employeeEditViewModel = new EmployeeViewModel
            {
                Name = person.Name,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                BirthDate = person.BirthDate,
                BloodGroup = person.BloodGroup,
                PresentAddress = person.PresentAddress,
                PermanentAddress = person.PermanentAddress,
                Id = employee.Id,
                PersonId = employee.PersonId,
                SpecialtyId = employee.SpecialtyId,
                PositionId = employee.PositionId,
                Salary = employee.Salary,

                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                ApplicationUser person = _employeeRepository.GetPerson(model.PersonId);
                Position position = _employeeRepository.GetPosition(model.PositionId);
                person.Name = model.Name;
                person.Email = model.Email;
                person.PhoneNumber = model.PhoneNumber;
                person.Gender = model.Gender;
                person.BloodGroup = model.BloodGroup;
                person.BirthDate = model.BirthDate;
                person.PresentAddress = model.PresentAddress;
                person.PermanentAddress = model.PermanentAddress;
                employee.PositionId = model.PositionId;
                employee.PersonId = model.PersonId;
                employee.SpecialtyId = model.SpecialtyId;
                employee.Salary = model.Salary;
                employee.EDate = DateTime.Now;
                if(model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                Employee updatedEmployee = _employeeRepository.Update(employee);
                ApplicationUser updatedPerson = _accountRepository.Update(person);
                //Position updatePosition = _positionRepository.Update(position);
                               
                return RedirectToAction("Index");
            }
            return View(model);
        }
        ///// ekhane image path rename
        private string ProcessUploadedFile(EmployeeViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult CreateDoctorShedule()
        {
            ViewBag.EmployeeList = (from p in _accountRepository.GetAllPerson()
                                     join e in _employeeRepository.GetAllEmployees() on p.Id equals e.PersonId
                                     select new EmployeeViewModel
                                     {
                                         Id= e.Id,
                                         Name=p.Name
                                     }).OrderBy(x => x.Name).ToList();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateDoctorShedule(EmployeeViewModel model)
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

                Employee newEmployee = new Employee
                {
                    PersonId = model.PersonId,
                    SpecialtyId = model.SpecialtyId,
                    PositionId = model.PositionId,
                    Salary = model.Salary,
                    IUser = 1,
                    IDate = DateTime.Now,
                    EUser = 0,
                    EDate = null,

                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id, personid = newEmployee.PersonId, positionid = newEmployee.PositionId });
            }

            return View();
        }

    }
}
