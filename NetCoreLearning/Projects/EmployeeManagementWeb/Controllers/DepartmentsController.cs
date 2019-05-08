using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementWeb.Controllers
{
    public class DepartmentsController : Controller
    {
        public string List() {
            return "list of department controller";
        }

        public string Details() {
            return "Details of departmentscontroller";
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}