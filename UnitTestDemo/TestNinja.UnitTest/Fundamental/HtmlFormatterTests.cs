
namespace TestNinja.UnitTest.Fundamental
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        [TestCase("<strong>abc</strong>")]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement(string content)
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold(content);

            Assert.That(result, Is.EqualTo($"<strong>{content}</strong>"));
        }

    }
}
