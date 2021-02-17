using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.modals
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
            context.Employees.Add(employee);
            var res = context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if(employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {


            /* var entity = db.Users.Attach(updatedUser);
             entity.Entry(updatedUser).State = EntityState.Modified;
             entity.SaveChanges();
             return updatedUser;*/
            var result = context.Employees.SingleOrDefault(b => b.Id == employeeChanges.Id);
            if (result != null)
            {
                result.Name = employeeChanges.Name;
                result.Email = employeeChanges.Email;
                result.Department = employeeChanges.Department;
                context.SaveChanges();
            }
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
