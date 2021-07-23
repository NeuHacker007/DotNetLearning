using System;
using System.Collections.Generic;
using ApiVersioningSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningSample.Controllers.V2
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiVersion("2.0")]
    public class UsersController : ControllerBase
    {
        [HttpGet()]
        public IActionResult AllUsers()
        {
            var users = new List<UserV2>()
            {
                new UserV2 {
                    Id = Guid.NewGuid(),
                    Name = "Ivan"
                },
                 new UserV2 {
                    Id = Guid.NewGuid(),
                    Name = "Eva"
                }
            };

            return Ok(users);
        }
    }
}