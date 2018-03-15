/**
* @Project Name: $projectname$ ： VideoServiceTests
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Tests
* @Creation Time:  3/14/2018 5:41:49 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/14/2018 5:41:49 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/

using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.Tests
{
    [TestFixture]
    class VideoServiceTests
    {
        private VideoService _vs;
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void SetUp()
        {
            _vs = new VideoService(new FileReaderForTest());
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMsg()
        {
            //_vs.FileReader = new FileReaderForTest();
            var result = _vs.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
