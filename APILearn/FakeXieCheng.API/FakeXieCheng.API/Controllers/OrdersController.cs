using AutoMapper;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.ResourceParameters;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        public OrdersController(
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            ITouristRouteRepository touristRouteRepository,
            IHttpClientFactory httpClientFactory,
            IConfiguration config,
            ILogger logger
            )
        {
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._touristRouteRepository = touristRouteRepository;
            this._httpClientFactory = httpClientFactory;
            this._config = config;
            this._logger = logger;
        }
        [HttpGet(Name = "GetOrders")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetOrders(
            [FromQuery] PaginationResourceParameters paginationResourceParameters
            )
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
            var ordersFromRepo = await _touristRouteRepository.GetOrdersByUserIdAsync(
                currentUserId,
                paginationResourceParameters.PageSize,
                paginationResourceParameters.PageNumber);
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

        [HttpPost("{orderId}/placeOrder")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public async Task<IActionResult> PlaceOrder(
            [FromRoute] Guid orderId

            )
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

            var order = await _touristRouteRepository.GetOrderByIdAsync(orderId);
            try
            {
                order.PaymentProcessing();
            }
            catch (Exception e)
            {
                order.PaymentRollBackToPending();
                _logger.LogError(e.Message);
                throw;
            }
            finally
            {
                await _touristRouteRepository.SaveAsync();
            }


            var httpClient = _httpClientFactory.CreateClient();
            string url = _config["ThirdPartyPayment:PaymentUrl"];

            var response = await httpClient.PostAsync(
                 string.Format(url, _config["ThirdPartyPayment:SecretCode"], order.Id, false),
                 null
                 );

            bool isApproved = false;
            string transactionMetaData = "";

            if (response.IsSuccessStatusCode == true)
            {
                transactionMetaData = await response.Content.ReadAsStringAsync();
                var jsonObject = (JObject)JsonConvert.DeserializeObject(transactionMetaData);
                isApproved = jsonObject["approved"].Value<bool>();
            }


            if (isApproved)
            {
                order.PaymentApprove();
            }
            else
            {
                order.PaymentReject();
            }

            order.TransactionMetaData = transactionMetaData;
            await _touristRouteRepository.SaveAsync();

            return Ok(_mapper.Map<OrderDto>(order));
        }
    }
}
