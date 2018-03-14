using NUnit.Framework;
using System;
/**
* @Project Name: $projectname$ ： ErrorLoggerTests
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Tests
* @Creation Time:  3/13/2018 9:37:05 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/13/2018 9:37:05 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class ErrorLoggerTests
    {
        private ErrorLogger _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }
        [Test]
        [TestCase("a", "a")]
        public void Log_WhenCalled_LastErrorPropertyChanged(string msg, string expectedmsg)
        {
            _logger.Log(msg);
            Assert.That(_logger.LastError, Is.EqualTo(expectedmsg));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string msg)
        {
            Assert.That(() => _logger.Log(msg), Throws.ArgumentNullException);
            //Assert.That(()=> _logger.Log(msg), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Log_ValidLog_RaiseErrorLogEvent()
        {
            var id = Guid.Empty;

            _logger.ErrorLogged += (sender, args) => { id = args; };
            _logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
