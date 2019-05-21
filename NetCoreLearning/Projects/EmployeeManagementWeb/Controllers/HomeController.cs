using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementWeb.Models;
using EmployeeManagementWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementWeb.Controllers
{
    
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [Route("")]
        [Route("~/")]
        public ViewResult Index()
        {
            return View(this._employeeRepository.GetEmployees());
        }
        [Route("{id?}")]
        public ViewResult Details(int? Id)
        {
            // ?? null coalescing operation if ID is null use 1, otherwise use the id value
            Employee model = _employeeRepository.GetEmployee(Id??1);
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel() {
                Employee = model,
                PageTitle="Details"
            };

            return View(viewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new { Id = newEmployee.ID });
            }
            else
            {
                return View();
            }
        }
    }
}