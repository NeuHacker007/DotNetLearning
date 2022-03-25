using AutoMapper;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.ModelBinder;
using FakeXieCheng.API.Models;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [Authorize(AuthenticationSchemes = "Bearer")]
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

        [HttpPost("items")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> AddShoppingCartItem(
            [FromBody] AddShoppingCartItemDto addShoppingCartItemDto)
        {
            var currentUserId = _httpContextAccessor
                .HttpContext
                .User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value;

            var shoppingCart = await _touristRouteRepository
                .GetShoppingCartByUserIdAsync(currentUserId);

            var touristRoute = await _touristRouteRepository
                .GetTouristRouteAsync(addShoppingCartItemDto.TouristRouteId);

            if (touristRoute == null)
            {
                return NotFound($"旅游路线{addShoppingCartItemDto.TouristRouteId}不存在");
            }

            var lineItem = new LineItem()
            {
                TouristRouteId = addShoppingCartItemDto.TouristRouteId,
                ShoppingCartId = shoppingCart.Id,
                OriginalPrice = touristRoute.OriginalPrice,
                DiscountPresent = touristRoute.DiscountPresent
            };

            await _touristRouteRepository.AddShoppingCartItemAsync(lineItem);
            await _touristRouteRepository.SaveAsync();


            return Ok(_mapper.Map<ShoppingCartDto>(shoppingCart));

        }


        [HttpDelete("items/{itemId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteShoppingCartItemAsync(
            [FromRoute] int itemId
            )
        {
            var lineItem = await _touristRouteRepository
                .GetShoppingCartItemByItemIdAsync(itemId);

            if (lineItem == null)
            {
                return NotFound("购物车商品找不到");
            }

            _touristRouteRepository.DeleteShoppingCartItem(lineItem);

            await _touristRouteRepository.SaveAsync();

            return NoContent();
        }


        [HttpDelete("items/({itemId})")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public async Task<IActionResult> RemoveShoppingCartItems(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))]
            [FromRoute] IEnumerable<int> itemIds)
        {
            var lineItems = await _touristRouteRepository.GetShoppingCartsByIdListAsync(itemIds);

            if (lineItems == null || lineItems.Count() <=0)
            {
                return BadRequest("购物车商品找不到");
            }

            _touristRouteRepository.DeleteShoppingCartItems(lineItems);
            await _touristRouteRepository.SaveAsync();

            return NoContent();
        }
    }
}
