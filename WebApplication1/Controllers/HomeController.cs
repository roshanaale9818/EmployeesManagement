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
        public JsonResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return Json(model);
          //  return _employeeRepository.GetEmployee(1).Name;
        }
        public ViewResult ShowDetails()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return View(model);

        }
    }
}
