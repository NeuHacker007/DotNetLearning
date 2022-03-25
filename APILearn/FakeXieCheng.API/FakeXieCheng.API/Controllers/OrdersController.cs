using AutoMapper;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ITouristRouteRepository _touristRouteRepository;

        public OrdersController(
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            ITouristRouteRepository touristRouteRepository
            )
        {
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._touristRouteRepository = touristRouteRepository;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetOrders()
        {
            var currentUserId = _httpContextAccessor
                .HttpContext
                .User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value;
            if (string.IsNullOrWhiteSpace(currentUserId))
            {
                return NotFound($"User {currentUserId} 不存在");
            }
            var ordersFromRepo = await _touristRouteRepository.GetOrdersByUserIdAsync(currentUserId);
            if (ordersFromRepo == null || ordersFromRepo.Count() <= 0)
            {
                return NotFound($"订单不存在");
            }
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(ordersFromRepo));
        }


        [HttpGet("{orderId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public async Task<IActionResult> GetOrderById(
            [FromRoute] Guid orderId)
        {
            var currentUserId = _httpContextAccessor
                .HttpContext
                .User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value;

            if (string.IsNullOrWhiteSpace(currentUserId))
            {
                return NotFound($"User {currentUserId} 不存在");
            }

            var orderFromRepo = await _touristRouteRepository.GetOrderByIdAsync(orderId);

            if (orderFromRepo == null)
            {
                return NotFound($"订单{orderId}不存在");
            }

            return Ok(_mapper.Map<OrderDto>(orderFromRepo));
        }


    }
}
