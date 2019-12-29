using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalMS.Models;
using HospitalMS.Models.PersonModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using HospitalMS.Models.EmployeeModels;
using HospitalMS.Models.AccountModels;

namespace HospitalMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountRepository _accountRepository;

        public HomeController(IEmployeeRepository employeeRepository, IAccountRepository accountRepository, IPersonRepository personRepository,  IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _accountRepository = accountRepository;
            _personRepository = personRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            Employee model = new Employee();
            List<EmployeeView> empList = (from e in _employeeRepository.GetAllEmployees()
                                          join p in _accountRepository.GetAllPerson() on e.PersonId equals p.Id
                                          select new EmployeeView
                                          {
                                              Name = p.Name,
                                              PhotoPath = e.PhotoPath
                                          }).ToList();
            // var model = _employeeRepository.GetAllEmployees();
            model.EmployeeList = empList;
            return View(model);
        }
        //[AllowAnonymous]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [AllowAnonymous]
        public IActionResult DoctorListPartialView()
        {
            Employee model = new Employee();
            List<EmployeeView> empList = (from e in _employeeRepository.GetAllEmployees()
                                          join p in _accountRepository.GetAllPerson() on e.PersonId equals p.Id
                                          select new EmployeeView
                                          {                                             
                                              Name = p.Name,
                                              PhotoPath = e.PhotoPath
                                          }).ToList();
            // var model = _employeeRepository.GetAllEmployees();
            model.EmployeeList = empList;
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Appointment()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Appointment(Person model)
        {
            if(ModelState.IsValid)
            {
                Person nwePerson = new Person
                {
                    Name = model.Name,
                    PhoneNo = model.PhoneNo,
                    Email = model.Email,
                    BirthDate = model.BirthDate,
                    Gender = model.Gender,
                    BloodGroup = model.BloodGroup,
                    PresentAddress = model.PresentAddress,
                    PermanentAddress = model.PermanentAddress,
                    Password = model.Password,
                    IUser = 1,
                    IDate = DateTime.Now

                };

                _personRepository.Add(nwePerson);
                return RedirectToAction("Index");
                //return RedirectToAction("details", new { id = newEmployee.EmpId });
            }

            
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
