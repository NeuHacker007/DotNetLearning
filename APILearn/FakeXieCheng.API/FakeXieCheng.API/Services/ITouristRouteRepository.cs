using FakeXieCheng.API.Models;
using System;
using System.Collections.Generic;

namespace FakeXieCheng.API.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string operatorType, int? ratingValue);
        TouristRoute GetTouristRoute(Guid touristRouteId);

        bool TouristRouteExists(Guid touristRouteId);
        IEnumerable<TouristRoute> GetTouristRouteByIdList(IEnumerable<Guid> ids);

        IEnumerable<TouristRoutePicture> GetPicturesByRouteId(Guid touristRouteId);

        TouristRoutePicture GetPicture(int pictureId);

        void AddTouristRoute(TouristRoute touristRoute);

        bool Save();

        void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoute(TouristRoute touristRoute);
        void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes);
        
    }
}
