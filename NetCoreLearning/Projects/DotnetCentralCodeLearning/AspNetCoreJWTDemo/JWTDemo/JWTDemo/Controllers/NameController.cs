using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly ICustomerAuthenticationManager _customerAuthenticationManager;

        public NameController(ICustomerAuthenticationManager customerAuthenticationManager)
        {
            _customerAuthenticationManager = customerAuthenticationManager;
        }

        // GET: api/<NameController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "New Jersy", "Maryland" };
        }

        // GET api/<NameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredential userCredential)
        {
            var token = _customerAuthenticationManager.Authenticate(userCredential.UserName, userCredential.Password);
            if (string.IsNullOrWhiteSpace(token)) return Unauthorized();
            return Ok(token);
        }
    }
}