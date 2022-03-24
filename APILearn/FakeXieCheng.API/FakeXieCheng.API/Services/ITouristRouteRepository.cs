using FakeXieCheng.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Services
{
    public interface ITouristRouteRepository
    {
        Task<IEnumerable<TouristRoute>> GetTouristRoutesAsync(string keyword, string operatorType, int? ratingValue);
        Task<TouristRoute> GetTouristRouteAsync(Guid touristRouteId);

        Task<bool> TouristRouteExistsAsync(Guid touristRouteId);
        Task<IEnumerable<TouristRoute>> GetTouristRouteByIdListAsync(IEnumerable<Guid> ids);

        Task<IEnumerable<TouristRoutePicture>> GetPicturesByRouteIdAsync(Guid touristRouteId);

        Task<TouristRoutePicture> GetPictureAsync(int pictureId);

        Task<bool> SaveAsync();
        
        void AddTouristRoute(TouristRoute touristRoute);
        void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoute(TouristRoute touristRoute);
        void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes);

        Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId);
        Task CreateShoppingCartAsync(ShoppingCart shoppingCart);
        
    }
}
