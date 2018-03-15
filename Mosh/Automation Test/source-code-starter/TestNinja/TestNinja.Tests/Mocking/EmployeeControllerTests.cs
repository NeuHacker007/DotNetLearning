/**
* @Project Name: $projectname$ ： EmployeeControllerTests
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Tests.Mocking
* @Creation Time:  3/15/2018 3:55:48 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/15/2018 3:55:48 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IEmployeeStorage>();
        }
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            var controller = new EmployeeController(_storage.Object);
            controller.DeleteEmployee(1);

            _storage.Verify(s => s.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmployee_AfterDeleted_ReturnRedirectResultObject()
        {
            var controller = new EmployeeController(_storage.Object);
            var result = controller.DeleteEmployee(1);

            _storage.Verify(s => s.DeleteEmployee(1));
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}
