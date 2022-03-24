using AutoMapper;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Controllers
{
    [ApiController]
    [Route("api/shoppingCart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;

        public ShoppingCartController(
            IHttpContextAccessor httpContextAccessor,
            ITouristRouteRepository touristRouteRepository,
            IMapper mapper
            )
        {
            this._httpContextAccessor = httpContextAccessor;
            this._touristRouteRepository = touristRouteRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetShoppingCart()
        {
            //1. Get user
            var currentUserId = _httpContextAccessor
                .HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)
                .Value;
            var shoppingCart = await _touristRouteRepository
                .GetShoppingCartByUserIdAsync(currentUserId);

            return Ok(_mapper.Map<ShoppingCartDto>(shoppingCart));

        } 
    }
}
