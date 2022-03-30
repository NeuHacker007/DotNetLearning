using FakeXieCheng.API.Helper;
using FakeXieCheng.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Services
{
    public interface ITouristRouteRepository
    {
        Task<PaginationList<TouristRoute>> GetTouristRoutesAsync(
            string keyword, 
            string operatorType, 
            int? ratingValue,
            int pageSize,
            int pageNumber, 
            string orderBy);
        Task<TouristRoute> GetTouristRouteAsync(Guid touristRouteId);

        Task<bool> TouristRouteExistsAsync(Guid touristRouteId);
        Task<IEnumerable<TouristRoute>> GetTouristRouteByIdListAsync(IEnumerable<Guid> ids);

        Task<IEnumerable<TouristRoutePicture>> GetPicturesByRouteIdAsync(Guid touristRouteId);

        Task<TouristRoutePicture> GetPictureAsync(int pictureId);

        Task<bool> SaveAsync();
        
        Task AddTouristRouteAsync(TouristRoute touristRoute);
        Task AddTouristRoutePictureAsync(Guid touristRouteId, TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoute(TouristRoute touristRoute);
        void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes);

        Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId);
        Task CreateShoppingCartAsync(ShoppingCart shoppingCart);
        Task AddShoppingCartItemAsync(LineItem lineItem);

        Task<LineItem> GetShoppingCartItemByItemIdAsync(int lineItemId);
        void DeleteShoppingCartItem(LineItem lineItem);
        Task<IEnumerable<LineItem>> GetShoppingCartsByIdListAsync(IEnumerable<int> ids);
        void DeleteShoppingCartItems(IEnumerable<LineItem> lineItems);

        Task AddOrderAsync(Order order);

        Task<PaginationList<Order>> GetOrdersByUserIdAsync(
            string userId,
            int pageSize,
            int PageNumber);
        Task<Order> GetOrderByIdAsync(Guid orderId);
    }
}
