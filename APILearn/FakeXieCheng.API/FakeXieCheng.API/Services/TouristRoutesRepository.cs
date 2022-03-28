using FakeXieCheng.API.Database;
using FakeXieCheng.API.Helper;
using FakeXieCheng.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Services
{
    /*
     我们使用的orm框架是entity framework core，在旧版的ef框架中add添加与remove删除都没有对应的异步接口，也就是说没有AddAsync与RemoveAsync。

     不过，自从ef6开始，数据的添加操作也有异步操作了，AddAsync函数也有了，我们使用的ef是最新版，所以add添加也将会支持异步操作。
     我也会对视频内容做一个勘误。下面简单聊一下为什么没有remove的异步操作。
     
     与数据库的读取数据操作不一样（比如GetTouristRoutesAsync函数），不管是add还是remove都不会在被调用后直接向数据库写入数据，
     而是先把数据放在DbContext中，由一个叫做“ChangeTracker”的东西管理（暂时理解为内存），直到调用 _context.SaveChangesAsync()以后，
     数据才会被真正写入数据库中。
     
     数据存入ChangeTracker（DbContext）的时候进行的是内存操作，并不是真正的IO操作，所有没有必要进行异步操作，
     这就是为什么add与delete不需要对应的异步函数。

     那么，为什么最新版的ef又提供了add的异步操作AddAsync呢？

     因为，有时候在添加数据的时候，可能会需要与数据库提前沟通一下，比如说如果一个模型的主键id，是整数类型、而且是由数据库控制的自增数字，
     那么我们在添加数据的时候必须得先问问数据库这个新数据的id是什么啊，得到id以后再把数据存入ChangeTracker里面，
     最后，直到调用 _context.SaveChangesAsync()以后，数据才会被真正写入数据库中。
     而问数据库取得id的过程实际上就是一个IO操作，既然是IO，那么异步操作就在所难免了，
     这就是为什么新版的ef加入了AddAsync这个函数，提供了这个异步操作。
     
     */
    public class TouristRoutesRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _context;

        public TouristRoutesRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task AddShoppingCartItemAsync(LineItem lineItem)
        {
            await _context.LineItems.AddAsync(lineItem);
        }

        public async Task AddTouristRouteAsync(TouristRoute touristRoute)
        {
            if (touristRoute == null)
            {
                throw new ArgumentNullException(nameof(touristRoute));
            }

            await _context.TouristRoutes.AddAsync(touristRoute);

        }

        public async Task AddTouristRoutePictureAsync(Guid touristRouteId, TouristRoutePicture touristRoutePicture)
        {
            if (touristRouteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(touristRouteId));
            }
            if (touristRoutePicture == null)
            {
                throw new ArgumentNullException(nameof(touristRoutePicture));
            }

            touristRoutePicture.TouristRouteId = touristRouteId;

            await _context.TouristRoutePictures.AddAsync(touristRoutePicture);

        }

        public async Task CreateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            await _context.ShoppingCarts.AddAsync(shoppingCart);
        }

        public void DeleteShoppingCartItem(LineItem lineItem)
        {
            _context.LineItems.Remove(lineItem);
        }

        public void DeleteShoppingCartItems(IEnumerable<LineItem> lineItems)
        {
            _context.RemoveRange(lineItems);
        }

        public void DeleteTouristRoute(TouristRoute touristRoute)
        {
            _context.TouristRoutes.Remove(touristRoute);
        }

        public void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture)
        {
            _context.TouristRoutePictures.Remove(touristRoutePicture);
        }

        public void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes)
        {
            _context.TouristRoutes.RemoveRange(touristRoutes);
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.TouristRoute)
                .Where(o => o.Id == orderId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task<TouristRoutePicture> GetPictureAsync(int pictureId)
        {
            return await _context.TouristRoutePictures.Where(tr => tr.Id == pictureId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TouristRoutePicture>> GetPicturesByRouteIdAsync(Guid touristRouteId)
        {
            return await _context.TouristRoutePictures
                .Where(p => p.TouristRouteId == touristRouteId)
                .ToListAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId)
        {
            return await _context.ShoppingCarts
                 .Include(s => s.User)
                 .Include(s => s.ShoppingCartItems)
                 .ThenInclude(li => li.TouristRoute)
                 .Where(s => s.UserId == userId)
                 .FirstOrDefaultAsync();
        }

        public async Task<LineItem> GetShoppingCartItemByItemIdAsync(int lineItemId)
        {
            return await _context.LineItems.Where(li => li.Id == lineItemId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LineItem>> GetShoppingCartsByIdListAsync(IEnumerable<int> ids)
        {
            return await _context.LineItems.Where(li => ids.Contains(li.Id)).ToListAsync();
        }

        public async Task<TouristRoute> GetTouristRouteAsync(Guid touristRouteId)
        {
            return await _context.TouristRoutes.Include(t => t.TouristRoutePictures).FirstOrDefaultAsync(tr => tr.Id == touristRouteId);
        }

        public async Task<IEnumerable<TouristRoute>> GetTouristRouteByIdListAsync(IEnumerable<Guid> ids)
        {
            return await _context.TouristRoutes.Where(t => ids.Contains(t.Id)).ToListAsync();
        }

        public async Task<PaginationList<TouristRoute>> GetTouristRoutesAsync(
            string keyword,
            string operatorType,
            int? ratingValue,
            int pageSize,
            int pageNumber)
        {
            IQueryable<TouristRoute> result = _context
                .TouristRoutes
                .Include(t => t.TouristRoutePictures);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(t => t.Title.Contains(keyword));
            }

            if (ratingValue >= 0)
            {
                result = operatorType switch
                {
                    "largerThan" => result.Where(t => t.Rating >= ratingValue),
                    "lessThan" => result.Where(t => t.Rating < ratingValue),
                    _ => result.Where(t => t.Rating == ratingValue),
                };
            }
            //var skip = (pageNumber -1) * pageSize;
            //result = result.Skip(skip);

            //result = result.Take(pageSize);
            //include vs join --> eager load

            return await PaginationList<TouristRoute>.CreateAsync(
                pageNumber,
                pageSize,
                result);
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result >= 0;
        }

        public async Task<bool> TouristRouteExistsAsync(Guid touristRouteId)
        {
            return await _context.TouristRoutes.AnyAsync(t => t.Id == touristRouteId);
        }
    }
}
