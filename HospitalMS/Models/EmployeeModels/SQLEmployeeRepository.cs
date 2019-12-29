using HospitalMS.Data;
using HospitalMS.Models.AccountModels;
using HospitalMS.Models.PositionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.EmployeeModels
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee employee)
        {
            context.Employee.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employee.Find(id);
            if (employee != null)
            {
                context.Employee.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {

            return context.Employee;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employee.Find(id);
        }

        public ApplicationUser GetPerson(string personid)
        {
            return context.AspNetUsers.Find(personid);
        }

        public Position GetPosition(int id)
        {
            return context.Position.Find(id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employee.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }

        
    }
}
