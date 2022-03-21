using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace FakeXieCheng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private readonly ITouristRouteRepository _touristRouteRepository;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            _touristRouteRepository = touristRouteRepository;
        }

        [HttpGet]
        public IActionResult GetRouristRoutes()
        {
            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRoutes();
            if (touristRoutesFromRepo == null 
                || touristRoutesFromRepo.Count() <= 0 )
            {
                return NotFound("没有旅游路线");
            }
            return Ok(touristRoutesFromRepo);
        }

        [HttpGet("{touristRouteId:Guid}")]
        public IActionResult GetTouristRoutesById(Guid touristRouteId)
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (touristRouteFromRepo == null)
            {
                return NotFound($"旅游路线{touristRouteId}找不到");
            }
            return Ok(touristRouteFromRepo);
        }
    }
}
