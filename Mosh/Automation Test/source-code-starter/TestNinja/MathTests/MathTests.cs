
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace MathTests
{


    [TestFixture]
    public class MathTests
    {
        private TestNinja.Fundamentals.Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCalled_ReturnGreterArgument(int a, int b, int expectedresults)
        {
            var results = _math.Max(a, b);
            Assert.That(results, Is.EqualTo(expectedresults));
        }
    }
}
