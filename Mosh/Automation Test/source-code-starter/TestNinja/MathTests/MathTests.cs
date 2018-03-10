
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
        public void Max_FirstArgumentIsGreater_ReturnFirstArgument()
        {
            var results = _math.Max(2, 1);
            Assert.That(results, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            var results = _math.Max(1, 2);
            Assert.That(results, Is.EqualTo(2));
        }

        [Test]
        public void Max_ArgumentsEqual_ReturnSame()
        {
            var results = _math.Max(1, 1);

            Assert.That(results, Is.EqualTo(1));
        }
    }
}
