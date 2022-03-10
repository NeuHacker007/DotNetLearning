namespace TestNinja.UnitTest.Fundamental
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calc;
        [SetUp]
        public void SetUp()
        {
            _calc = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedLessThanZeroOrOverMaxSpeed_ShouldThrowArgumentOutOfRangeException(int speed)
        {
            Assert.That(() => _calc.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(65, 0)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void CalculateDemeritPoints_SpeedLessThanOrEqualToSpeedLimit_ReturnZero(int speed, int ExpectedResult)
        {
            var result = _calc.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(ExpectedResult));
        }

        [Test]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(300, 47)]
        public void CalculateDemeritPoints_SpeedGreaterThanSpeedLimitAndLessThanOrEqualToMaxSpeed_ReturnDemeritPoints(int speed, int ExpectedResult)
        {
            var result = _calc.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(ExpectedResult));
        }
    }
}
