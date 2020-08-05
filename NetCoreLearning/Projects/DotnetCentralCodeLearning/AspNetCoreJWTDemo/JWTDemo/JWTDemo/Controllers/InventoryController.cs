using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        // GET: api/<InventoryController>
        [Authorize(Roles = "Administrator, User")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<InventoryController>
        [Authorize(Policy = "AdminAndPowerUser")]
        [HttpPost]
        public void Post([FromBody] Inventory inventory)
        {
        }
        // POST api/<InventoryController>
        [Authorize(Policy = "EmployeeWithMoreThan20Years")]
        [HttpDelete]
        public void Delete([FromBody] Inventory inventory)
        {
        }
    }
}
