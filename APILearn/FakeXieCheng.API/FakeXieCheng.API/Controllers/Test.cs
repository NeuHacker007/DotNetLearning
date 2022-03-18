
using Microsoft.AspNetCore.Mvc;

namespace FakeXieCheng.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Test: ControllerBase
    {

        public string Test1()
        {
            return "Hello";
        }

    }
}
