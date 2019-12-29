using HospitalMS.Models.AccountModels;
using HospitalMS.Models.PositionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.EmployeeModels
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        ApplicationUser GetPerson(string personid);
        Position GetPosition(int id);
        IEnumerable<Employee> GetAllEmployees();
        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
       
        Employee Delete(int id);
    }
}
