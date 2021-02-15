using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.modals;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;


        //this is constructor dependency injection IEmployee Repository
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        public string index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
        [Route("details")]
        [HttpGet]
        public JsonResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return Json(model);
          //  return _employeeRepository.GetEmployee(1).Name;
        }
        [Route("addemployee")]
        [HttpPost]
        public string AddEmployee([FromBody] Employee employee)
        {
            _employeeRepository.Add(employee);
            return "OK";

        }
        public ViewResult ShowDetails()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return View(model);

        }
        public IEnumerable<Employee> Get()
        {
            var data = _employeeRepository.GetAllEmployees();
            return data;
        }
    }
}
