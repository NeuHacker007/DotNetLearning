using AutoMapper;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeXieCheng.API.Controllers
{
    [Route("api/touristRoutes/{touristRouteId}/pictures")]
    [ApiController]
    public class TouristRoutePicturesController : ControllerBase
    {
        private readonly ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;

        public TouristRoutePicturesController(
            ITouristRouteRepository touristRouteRepository,
            IMapper mapper)
        {
            this._touristRouteRepository = touristRouteRepository ?? 
                throw new ArgumentNullException(nameof(touristRouteRepository)); 
            this._mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetPictureListForTouristRoute(Guid touristRouteId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var pictureFromRepo = _touristRouteRepository.GetPicturesByRouteId(touristRouteId);

            if (pictureFromRepo == null || pictureFromRepo.Count() <= 0)
            {
                return NotFound($"旅游路线{touristRouteId}的图片不存在");
            }

            return Ok(_mapper.Map<IEnumerable<TouristRoutePicturesDto>>(pictureFromRepo));

        }

        [HttpGet("{pictureId}")]
        public IActionResult GetPicture(Guid touristRouteId, int pictureId)
        {
            //The reason why we want to put touristRouteId as the parameter 
            //the picture depends on the tourist route. We shouldn't direct
            //expose the sub resources to the client directly
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var picFromRepo = _touristRouteRepository.GetPicture(pictureId);

            if (picFromRepo == null)
            {
                return NotFound($"图片{pictureId}不存在");
            }

            return Ok(_mapper.Map<TouristRoutePicturesDto>(picFromRepo));
        }
    }
}
