using FakeXieCheng.API.Models;
using System;
using System.Collections.Generic;

namespace FakeXieCheng.API.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes();
        TouristRoute GetTouristRoute(Guid touristRouteId);

        bool TouristRouteExists(Guid touristRouteId);

        IEnumerable<TouristRoutePicture> GetPicturesByRouteId(Guid touristRouteId);

        TouristRoutePicture GetPicture(int pictureId);
        
    }
}
