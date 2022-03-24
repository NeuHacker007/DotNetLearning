using AutoMapper;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.Models;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetPictureListForTouristRoute(Guid touristRouteId)
        {
            if (! await _touristRouteRepository.TouristRouteExistsAsync(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var pictureFromRepo = await _touristRouteRepository.GetPicturesByRouteIdAsync(touristRouteId);

            if (pictureFromRepo == null || pictureFromRepo.Count() <= 0)
            {
                return NotFound($"旅游路线{touristRouteId}的图片不存在");
            }

            return Ok(_mapper.Map<IEnumerable<TouristRoutePicturesDto>>(pictureFromRepo));

        }

        [HttpGet("{pictureId}", Name = "GetPicture")]
        public async Task<IActionResult> GetPicture(Guid touristRouteId, int pictureId)
        {
            //The reason why we want to put touristRouteId as the parameter 
            //the picture depends on the tourist route. We shouldn't direct
            //expose the sub resources to the client directly
            if (! await _touristRouteRepository.TouristRouteExistsAsync(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var picFromRepo = await _touristRouteRepository.GetPictureAsync(pictureId);

            if (picFromRepo == null)
            {
                return NotFound($"图片{pictureId}不存在");
            }

            return Ok(_mapper.Map<TouristRoutePicturesDto>(picFromRepo));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePicture(
            [FromRoute] Guid touristRouteId,
            [FromBody] TouristRoutePictureForCreationDto touristRoutePictureForCreationDto
            )
        {
            if (!await _touristRouteRepository.TouristRouteExistsAsync(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var picModel = _mapper.Map<TouristRoutePicture>(touristRoutePictureForCreationDto);

            _touristRouteRepository.AddTouristRoutePicture(touristRouteId, picModel);

           await _touristRouteRepository.SaveAsync();

            var pictureToReturn = _mapper.Map<TouristRoutePictureForCreationDto>(picModel);

            return CreatedAtRoute(
                "GetPicture",
                new
                {
                    TouristRouteId = picModel.TouristRouteId,
                    PictureId = picModel.Id
                },
                pictureToReturn
                );
        }

        [HttpDelete("{pictureId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePicture(
            [FromRoute] Guid touristRouteId,
            [FromRoute] int pictureId
            )
        {
            if (!await _touristRouteRepository.TouristRouteExistsAsync(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var touristRoutePicture = await _touristRouteRepository.GetPictureAsync(pictureId);

            _touristRouteRepository.DeleteTouristRoutePicture(touristRoutePicture);

            await _touristRouteRepository.SaveAsync();

            return NoContent();

        }
    }
}
