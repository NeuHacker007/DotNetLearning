using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using FakeXieCheng.API.Dtos;

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
            var touristRouteDto = new TouristRouteDto()
            {
                Id= touristRouteFromRepo.Id,
                Title = touristRouteFromRepo.Title,
                Description = touristRouteFromRepo.Title,
                Price = touristRouteFromRepo.OriginalPrice * (decimal) (touristRouteFromRepo.DiscountPresent ?? 1d),
                CreateTime = touristRouteFromRepo.CreateTime,
                UpdateTime = touristRouteFromRepo.UpdateTime,
                Features = touristRouteFromRepo.Features,
                Fees = touristRouteFromRepo.Fees,
                Notes = touristRouteFromRepo.Notes,
                Rating = touristRouteFromRepo.Rating,
                TravelDays = touristRouteFromRepo.TravelDays.ToString(),
                TripType = touristRouteFromRepo.TripType.ToString(),
                DepartureCity = touristRouteFromRepo.DepartureCity.ToString()
            };
            return Ok(touristRouteDto);
        }
    }
}
