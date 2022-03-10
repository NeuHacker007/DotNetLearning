namespace TestNinja.UnitTest.Fundamental
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _controller;
        [SetUp]
        public void SetUp()
        {
            _controller = new CustomerController();
        }


        [Test]
        public void GetCustomer_IDGreaterThanZero_ReturnOKObject()
        {
            var result = _controller.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
        }
        [Test]
        public void GetCustomer_IDEqualToZero_ReturnNotFoundObject()
        {
            var result = _controller.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IDLessThanZero_ReturnOKObject()
        {
            Assert.That(() => _controller.GetCustomer(-1), Throws.ArgumentException);
        }
    }
}
