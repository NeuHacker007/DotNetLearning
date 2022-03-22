using FakeXieCheng.API.Database;
using FakeXieCheng.API.Models;
using Microsoft.EntityFrameworkCore;
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

        public TouristRoutePicture GetPicture(int pictureId)
        {
            return _context.TouristRoutePictures.Where(tr => tr.Id == pictureId).FirstOrDefault();
        }

        public IEnumerable<TouristRoutePicture> GetPicturesByRouteId(Guid touristRouteId)
        {
            return _context.TouristRoutePictures
                .Where(p => p.TouristRouteId == touristRouteId)
                .ToList();
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return _context.TouristRoutes.Include(t => t.TouristRoutePictures).FirstOrDefault(tr => tr.Id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword)
        {
            IQueryable<TouristRoute> result = _context
                .TouristRoutes
                .Include(t => t.TouristRoutePictures);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(t => t.Title.Contains(keyword));
            }

            //include vs join --> eager load
            return result.ToList();
        }

        public bool TouristRouteExists(Guid touristRouteId)
        {
            return _context.TouristRoutes.Any(t => t.Id == touristRouteId);
        }
    }
}
