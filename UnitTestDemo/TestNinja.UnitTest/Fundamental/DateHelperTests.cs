namespace TestNinja.UnitTest.Fundamental
{
    [TestFixture]
    public class DateHelperTests
    {
        [Test]
        public void FirstOfNextMonth_DateMonthIs12_ShouldReturnTheFirstDayOfNextYear()
        {
            var inputDateTime = new DateTime(2021, 12, 1);
            var expectedResult = new DateTime(2022, 1, 1);
            var result = DateHelper.FirstOfNextMonth(inputDateTime);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [Test]
        public void FirstOfNextMonth_DateMonthIsNot12_ShouldReturnTheNextMonthDateWithinTheSameYearAndSameDay()
        {
            var inputDateTime = new DateTime(2021, 11, 1);
            var expectedResult = new DateTime(2021, 12, 1);
            var result = DateHelper.FirstOfNextMonth(inputDateTime);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
