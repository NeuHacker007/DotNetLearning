using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementWeb.Models;
using EmployeeManagementWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            return View(this._employeeRepository.GetEmployees());
        }

        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel() {
                Employee = model,
                PageTitle="HelloWorld"
            };

            return View(viewModel);
        }
    }
}