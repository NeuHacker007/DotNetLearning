using FakeXieCheng.API.Database;
using FakeXieCheng.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeXieCheng.API.Services
{
    public class TouristRoutesRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _context;

        public TouristRoutesRepository(AppDbContext context)
        {
            this._context = context;
        }
        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return _context.TouristRoutes.FirstOrDefault(tr => tr.Id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _context.TouristRoutes;
        }
    }
}
