using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SOA.WebAPI.Unity.Interface;

namespace SOA.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService _userService = null;

        public UsersController(IUserService userService){
            _userService = userService;
        }
        // GET api/<controller>
        public string Get()
        {
            var users = this._userService.GetList();
            return JsonConvert.SerializeObject(users);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}