/**
* @Project Name: $projectname$ ： BookingRepository
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Mocking
* @Creation Time:  3/15/2018 9:14:20 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/15/2018 9:14:20 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);
    }

    class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings = unitOfWork
                           .Query<Booking>()
                           .Where(b => b.Status != "Cancelled");
            if (excludedBookingId.HasValue)
            {
                bookings = unitOfWork
                           .Query<Booking>()
                           .Where(b => b.Id != excludedBookingId.Value);
            }
            return bookings;
        }
    }
}
