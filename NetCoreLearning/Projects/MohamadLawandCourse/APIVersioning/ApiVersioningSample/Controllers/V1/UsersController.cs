using System.Collections.Generic;
using System.Threading.Tasks;
using ApiVersioningSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningSample.Controllers.V1
{
    [ApiController]
    [Route("api/[Controller]")]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        [HttpGet()]
        public IActionResult AllUsers()
        {
            var users = new List<UserV1>()
            {
                new UserV1 {
                    Id = 1,
                    Name = "Ivan"
                },
                 new UserV1 {
                    Id = 2,
                    Name = "Eva"
                }
            };

            return Ok(users);
        }
    }
}