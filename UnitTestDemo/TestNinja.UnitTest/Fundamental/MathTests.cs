namespace TestNinja.UnitTest.Fundamental
{
    [TestFixture]
    public class MathTests
    {
        private fundamental.Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Fundamentals.Math();
        }
        [Test]
        [TestCase(1, 3, 4)]
        public void Add_WhenCalled_ReturnTheSumOfArgs(int a, int b, int expectedResult)
        {
            var result = _math.Add(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(1, 1, 1)]
        [TestCase(1, 3, 3)]
        [TestCase(2, 1, 2)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            Assert.That(result, Is.EquivalentTo(new int[] { 1, 3, 5 }));
        }

        [Test]
        public void GetOddNumbers_LimitIsLessThanZero_ReturnEmpty()
        {
            var result = _math.GetOddNumbers(-5);

            Assert.That(result, Is.Empty);
        }
    }
}
