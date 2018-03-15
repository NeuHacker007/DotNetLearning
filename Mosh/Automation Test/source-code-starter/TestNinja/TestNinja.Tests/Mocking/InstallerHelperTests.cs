using Moq;
using NUnit.Framework;
/**
* @Project Name: $projectname$ ： InstallerHelperTests
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Tests
* @Creation Time:  3/15/2018 3:04:39 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/15/2018 3:04:39 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }
        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            //_fileDownloader.Setup(fd => fd.DownloadFile("http://example.com/customer/installer", null)).Throws<WebException>();
            _fileDownloader
                .Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.False);
        }

        [Test]
        public void DoloadInstaller_DownloadSuccess_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.True);

        }
    }
}
