using Moq;
using NUnit.Framework;
/**
* @Project Name: $projectname$ ： BookingHelperTests
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Tests.Mocking
* @Creation Time:  3/15/2018 9:26:27 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/15/2018 9:26:27 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    class BookingHelperTests
    {
        //TODO: Write an Set UP to initial mock
        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishedBeforeBooking_ReturnEmpty()
        {
            var repository = new Mock<IBookingRepository>();

            repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>()
            {
                //TODO: refactor this as an private field
                new Booking()
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2017,1,15,14,0,0),
                    DepartureDate = new DateTime(2017,1,20,10,0,0),
                    Reference = "a"

                }
            }.AsQueryable);

            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = new DateTime(2017, 1, 10, 14, 0, 0),
                DepartureDate = new DateTime(2017, 1, 14, 10, 0, 0),
                Reference = "a"

            }, repository.Object);

            Assert.That(result, Is.Empty);
        }

        //TODO: Implement two private method to get Arrival and Departure date

        
    }
}
