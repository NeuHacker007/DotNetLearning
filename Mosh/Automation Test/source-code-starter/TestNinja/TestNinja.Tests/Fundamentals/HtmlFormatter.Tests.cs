/**
* @Project Name: $projectname$ ： HtmlFormatter
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Tests
* @Creation Time:  3/13/2018 8:43:14 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/13/2018 8:43:14 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using NUnit.Framework;


namespace TestNinja.Tests
{
    [TestFixture]
    class HtmlFormatter
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseStringWithStrongElement()
        {
            var formatter = new TestNinja.Fundamentals.HtmlFormatter();
            var result = formatter.FormatAsBold("bcd");

            //Assert.That(result, Is.EqualTo("<strong>abc</strong>")); //this assertion is too specific which can be easily break

            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain("bcd").IgnoreCase);

        }
    }
}
