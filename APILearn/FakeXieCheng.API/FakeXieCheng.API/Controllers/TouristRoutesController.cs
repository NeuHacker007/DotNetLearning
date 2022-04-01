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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FakeXieCheng.API.Helper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using FakeXieCheng.API.Extensions;

namespace FakeXieCheng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private readonly ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;
        private readonly IUrlHelper _urlHelper;

        public TouristRoutesController(
            ITouristRouteRepository touristRouteRepository,
            IMapper mapper,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor,
            IPropertyMappingService propertyMappingService)
        {
            _touristRouteRepository = touristRouteRepository;
            this._mapper = mapper;
            this._propertyMappingService = propertyMappingService;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }

        [HttpGet(Name = "GetRouristRoutes")]
        [HttpHead]// only return header info not the body
        public async Task<IActionResult> GetRouristRoutes(
            [FromQuery] TouristRouteResourceParameters parameters,
            [FromQuery] PaginationResourceParameters paginationResourceParameters
            //[FromQuery] string keyword,
            //string rating
            )
        {
            if (!_propertyMappingService
                .IsMappingExists<TouristRouteDto, TouristRoute>
                (parameters.OrderBy))
            {
                return BadRequest($"请输入正确的排序参数");
            }

            if (!_propertyMappingService.IsPropertyExists<TouristRouteDto>(parameters.Fields))
            {
                return BadRequest($"请输入正确的塑形参数");
            }

            var touristRoutesFromRepo = await _touristRouteRepository
                .GetTouristRoutesAsync(
                parameters.Keyword,
                parameters.RatingOperator,
                parameters.RatingValue,
                paginationResourceParameters.PageSize,
                paginationResourceParameters.PageNumber,
                parameters.OrderBy);
            if (touristRoutesFromRepo == null
                || touristRoutesFromRepo.Count() <= 0)
            {
                return NotFound("没有旅游路线");
            }
            var touristRoutesDto = _mapper.Map<IEnumerable<TouristRouteDto>>(touristRoutesFromRepo);
            var previousPageLink = touristRoutesFromRepo.HasPrevious ?
                GenerateTouristRouteResourceUrl(
                    parameters,
                    paginationResourceParameters,
                    ResourceUriType.PreviousPage
                    ) : null;

            var nextPageLink = touristRoutesFromRepo.HasNext ?
                GenerateTouristRouteResourceUrl(
                    parameters,
                    paginationResourceParameters,
                    ResourceUriType.NextPage
                    ) : null;


            var paginationMetadata = new
            {
                previousPageLink,
                nextPageLink,
                totalCount = touristRoutesFromRepo.TotalCount,
                pageSize = touristRoutesFromRepo.PageSize,
                currentPage = touristRoutesFromRepo.CurrentPage,
                totalPages = touristRoutesFromRepo.TotalPages
            };

            Response.Headers.Add("x-pagination", JsonConvert.SerializeObject(paginationMetadata));
            return Ok(touristRoutesDto.ShapeData(parameters.Fields));
        }

        [HttpGet("{touristRouteId:Guid}", Name = "GetTouristRoutesById")]
        [HttpHead] // only return header info not the body
        public async Task<IActionResult> GetTouristRoutesById(
            Guid touristRouteId,
            string fields)
        {
            if (!_propertyMappingService.IsPropertyExists<TouristRouteDto>(fields))
            {
                return BadRequest($"请输入正确的塑形参数");
            }
            var touristRouteFromRepo = await _touristRouteRepository.GetTouristRouteAsync(touristRouteId);
            if (touristRouteFromRepo == null)
            {
                return NotFound($"旅游路线{touristRouteId}找不到");
            }


            var touristRouteDto = _mapper.Map<TouristRouteDto>(touristRouteFromRepo);
            //return Ok(touristRouteDto.ShapeData(fields));

            var linkDtos = CreateLinkForTouristRoute(touristRouteId, fields);

            var result = touristRouteDto.ShapeData(fields) as IDictionary<string, object>;

            result.Add("links", linkDtos);


            return Ok(result);
        }


        [HttpPost]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateTouristRoute(
            [FromBody] TouristRouteForCreationDto touristRouteForCreationDto
            )
        {
            var touristRouteModel = _mapper.Map<TouristRoute>(touristRouteForCreationDto);
            await _touristRouteRepository.AddTouristRouteAsync(touristRouteModel);

            await _touristRouteRepository.SaveAsync();

            var touristRouteToReturn = _mapper.Map<TouristRouteDto>(touristRouteModel);

            var links = CreateLinkForTouristRoute(
                touristRouteModel.Id,null);

            var result = touristRouteToReturn.ShapeData(null) as IDictionary<string, object>;

            result.Add("links", links);

            return CreatedAtRoute(
                "GetTouristRoutesById",
                new
                {
                    touristRouteId = result["id"]
                },
                result
                );
        }

        [HttpPut("{touristRouteId}", Name = "UpdateTouristRoute")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateTouristRoute(
            [FromRoute] Guid touristRouteId,
            [FromBody] TouristRouteForUpdateDto touristRouteForUpdateDto
            )
        {
            if (!await _touristRouteRepository.TouristRouteExistsAsync(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }
            var touristRouteFromRepo = await _touristRouteRepository.GetTouristRouteAsync(touristRouteId);
            _mapper.Map(touristRouteForUpdateDto, touristRouteFromRepo);

            await _touristRouteRepository.SaveAsync();

            var touristRouteToReturn = _mapper.Map<TouristRouteDto>(touristRouteFromRepo);


            return Ok(touristRouteToReturn);
        }

        [HttpPatch("{touristRouteId}", Name = "PartiallyupdateTouristRoute")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> PartiallyupdateTouristRoute(
            [FromRoute] Guid touristRouteId,
            [FromBody] JsonPatchDocument<TouristRouteForUpdateDto> patchDocument
            )
        {
            if (!await _touristRouteRepository.TouristRouteExistsAsync(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var touristRouteFromRepo = await _touristRouteRepository.GetTouristRouteAsync(touristRouteId);

            var touristRouteToPatch = _mapper.Map<TouristRouteForUpdateDto>(touristRouteFromRepo);

            patchDocument.ApplyTo(touristRouteToPatch, ModelState);

            if (!TryValidateModel(touristRouteToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(touristRouteToPatch, touristRouteFromRepo);

            await _touristRouteRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{touristRouteId}", Name = "DeleteTouristRoute")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteTouristRoute(
            [FromRoute] Guid touristRouteId
            )
        {
            if (!await _touristRouteRepository.TouristRouteExistsAsync(touristRouteId))
            {
                return NotFound($"旅游路线{touristRouteId}不存在");
            }

            var touristRouteFromRepo = await _touristRouteRepository.GetTouristRouteAsync(touristRouteId);

            _touristRouteRepository.DeleteTouristRoute(touristRouteFromRepo);

            await _touristRouteRepository.SaveAsync();

            return NoContent();

        }
        [HttpDelete("({touristRouteIds})")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteTouristRoutes(
           [ModelBinder(BinderType = typeof(ArrayModelBinder))]
           [FromRoute] IEnumerable<Guid> touristRouteIds)
        {
            if (touristRouteIds == null)
            {
                return BadRequest();
            }

            var touristRoutesFromRepo = await _touristRouteRepository.GetTouristRouteByIdListAsync(touristRouteIds);

            _touristRouteRepository.DeleteTouristRoutes(touristRoutesFromRepo);

            await _touristRouteRepository.SaveAsync();

            return NoContent();
        }
        private IEnumerable<LinkDto> CreateLinkForTouristRoute(
            Guid touristRouteId,
            string fields)
        {
            var links = new List<LinkDto>();

            links.Add(new LinkDto(

                Url.Link("GetTouristRoutesById", new { touristRouteId, fields }),
                "self",
                "GET"
                ));

            links.Add(new LinkDto(

                Url.Link("UpdateTouristRoute", new { touristRouteId }),
                "update",
                "PUT"
                ));


            links.Add(new LinkDto(

             Url.Link("PartiallyupdateTouristRoute", new { touristRouteId }),
             "partially_update",
             "PATCH"
             ));

            links.Add(new LinkDto(

             Url.Link("DeleteTouristRoute", new { touristRouteId }),
             "delete",
             "DELETE"
             ));

            links.Add(new LinkDto(

              Url.Link("GetPictureListForTouristRoute", new { touristRouteId }),
              "get_picture",
              "GET"
              ));

            links.Add(new LinkDto(

                Url.Link("CreatePicture", new { touristRouteId }),
                "create_picture",
                "POST"
                ));
            return links;
        }
        private string GenerateTouristRouteResourceUrl(
            TouristRouteResourceParameters touristRouteResourceParameters,
            PaginationResourceParameters paginationResourceParameters,
            ResourceUriType type
            )
        {
            return type switch
            {
                ResourceUriType.PreviousPage => _urlHelper.Link(
                "GetRouristRoutes",
                new
                {
                    filds = touristRouteResourceParameters.Fields,
                    orderBy = touristRouteResourceParameters.OrderBy,
                    keyword = touristRouteResourceParameters.Keyword,
                    rating = touristRouteResourceParameters.Rating,
                    pageNumber = paginationResourceParameters.PageNumber - 1,
                    pageSize = paginationResourceParameters.PageSize
                }),
                ResourceUriType.NextPage => _urlHelper.Link(
                "GetRouristRoutes",
                new
                {
                    filds = touristRouteResourceParameters.Fields,
                    orderBy = touristRouteResourceParameters.OrderBy,
                    keyword = touristRouteResourceParameters.Keyword,
                    rating = touristRouteResourceParameters.Rating,
                    pageNumber = paginationResourceParameters.PageNumber + 1,
                    pageSize = paginationResourceParameters.PageSize
                }),
                _ => _urlHelper.Link(
                "GetRouristRoutes",
                new
                {
                    filds = touristRouteResourceParameters.Fields,
                    orderBy = touristRouteResourceParameters.OrderBy,
                    keyword = touristRouteResourceParameters.Keyword,
                    rating = touristRouteResourceParameters.Rating,
                    pageNumber = paginationResourceParameters.PageNumber,
                    pageSize = paginationResourceParameters.PageSize
                }),
            };
        }
    }
}
