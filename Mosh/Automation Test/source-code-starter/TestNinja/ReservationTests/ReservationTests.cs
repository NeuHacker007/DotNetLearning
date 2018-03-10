using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace ReservationTests
{
    [TestClass]
    public class ReservationTest
    {
        [TestMethod]
        public void CanBeCancelledBy_isAdmin_ReturensTrue()
        {
            var reservation = new Reservation();

            var results = reservation.CanBeCancelledBy(new User() { IsAdmin = true });

            Assert.IsTrue(results);
        }
    }
}
