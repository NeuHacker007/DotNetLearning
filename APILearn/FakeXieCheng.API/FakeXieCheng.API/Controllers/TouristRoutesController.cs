using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using FakeXieCheng.API.Dtos;
using AutoMapper;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FakeXieCheng.API.ResourceParameters;
using FakeXieCheng.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using FakeXieCheng.API.ModelBinder;

namespace FakeXieCheng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private readonly ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            _touristRouteRepository = touristRouteRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [HttpHead]// only return header info not the body
        public IActionResult GetRouristRoutes(
            [FromQuery] TouristRouteResourceParameters parameters
            //[FromQuery] string keyword,
            //string rating
            )
        {
            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRoutes(parameters.Keyword, parameters.RatingOperator, parameters.RatingValue);
            if (touristRoutesFromRepo == null
                || touristRoutesFromRepo.Count() <= 0)
            {
                return NotFound("没有旅游路线");
            }
            var touristRoutesDto = _mapper.Map<IEnumerable<TouristRouteDto>>(touristRoutesFromRepo);
            return Ok(touristRoutesDto);
        }

        [HttpGet("{touristRouteId:Guid}", Name = "GetTouristRoutesById")]
        [HttpHead] // only return header info not the body
        public IActionResult GetTouristRoutesById(Guid touristRouteId)
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (touristRouteFromRepo == null)
            {
                return NotFound($"旅游路线{touristRouteId}找不到");
            }
            //var touristRouteDto = new TouristRouteDto()
            //{
            //    Id= touristRouteFromRepo.Id,
            //    Title = touristRouteFromRepo.Title,
            //    Description = touristRouteFromRepo.Title,
            //    Price = touristRouteFromRepo.OriginalPrice * (decimal) (touristRouteFromRepo.DiscountPresent ?? 1d),
            //    CreateTime = touristRouteFromRepo.CreateTime,
            //    UpdateTime = touristRouteFromRepo.UpdateTime,
            //    Features = touristRouteFromRepo.Features,
            //    Fees = touristRouteFromRepo.Fees,
            //    Notes = touristRouteFromRepo.Notes,
            //    Rating = touristRouteFromRepo.Rating,
            //    TravelDays = touristRouteFromRepo.TravelDays.ToString(),
            //    TripType = touristRouteFromRepo.TripType.ToString(),
            //    DepartureCity = touristRouteFromRepo.DepartureCity.ToString()
            //};
            var touristRouteDto = _mapper.Map<TouristRouteDto>(touristRouteFromRepo);
            return Ok(touristRouteDto);
        }


        [HttpPost]
        public IActionResult CreateTouristRoute(
            [FromBody] TouristRouteForCreationDto touristRouteForCreationDto
            )
        {
            var touristRouteModel = _mapper.Map<TouristRoute>(touristRouteForCreationDto);
            _touristRouteRepository.AddTouristRoute(touristRouteModel);

            _touristRouteRepository.Save();

            var touristRouteToReturn = _mapper.Map<TouristRouteDto>(touristRouteModel);

            return CreatedAtRoute(
                "GetTouristRoutesById",
                new
                {
                    touristRouteId = touristRouteToReturn.Id
                },
                touristRouteToReturn
                );
        }

        [HttpPut("{touristRouteId}")]
        public IActionResult UpdateTouristRoute(
            [FromRoute] Guid touristRouteId,
            [FromBody] TouristRouteForUpdateDto touristRouteForUpdateDto
            )
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            _mapper.Map(touristRouteForUpdateDto, touristRouteFromRepo);

            _touristRouteRepository.Save();

            var touristRouteToReturn = _mapper.Map<TouristRouteDto>(touristRouteFromRepo);


            return Ok(touristRouteToReturn);
        }

        [HttpPatch("{touristRouteId}")]
        public IActionResult PartiallyupdateTouristRoute(
            [FromRoute] Guid touristRouteId,
            [FromBody] JsonPatchDocument<TouristRouteForUpdateDto> patchDocument
            )
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);

            var touristRouteToPatch = _mapper.Map<TouristRouteForUpdateDto>(touristRouteFromRepo);

            patchDocument.ApplyTo(touristRouteToPatch, ModelState);

            if (!TryValidateModel(touristRouteToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(touristRouteToPatch, touristRouteFromRepo);

            _touristRouteRepository.Save();

            return NoContent();
        }

        [HttpDelete("{touristRouteId}")]
        public IActionResult DeleteTouristRoute(
            [FromRoute] Guid touristRouteId
            )
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);

            _touristRouteRepository.DeleteTouristRoute(touristRouteFromRepo);

            _touristRouteRepository.Save();

            return NoContent();

        }
        [HttpDelete("({touristRouteIds})")]
        public IActionResult DeleteTouristRoutes(
           [ModelBinder(BinderType = typeof(ArrayModelBinder))]
           [FromRoute] IEnumerable<Guid> touristRouteIds)
        {
            if (touristRouteIds == null)
            {
                return BadRequest();
            }

            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRouteByIdList(touristRouteIds);

            _touristRouteRepository.DeleteTouristRoutes(touristRoutesFromRepo);

            _touristRouteRepository.Save();

            return NoContent();
        }
    }
}
