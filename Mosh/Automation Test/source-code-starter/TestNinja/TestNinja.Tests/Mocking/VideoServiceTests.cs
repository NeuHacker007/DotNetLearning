using Moq;
using NUnit.Framework;
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

using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.Tests
{
    [TestFixture]
    class VideoServiceTests
    {
        private VideoService _vs;
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _vs = new VideoService(new FileReaderForTest());
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repository.Object);
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

        [Test]
        public void GetUnprocessedVideoAsCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessVideos()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo(""));

        }

        [Test]
        public void GetUnprocessedVideoAsCsv_AFewUnprocessedVideo_ReturnsUnprocessedVideoIds()
        {
            _repository.Setup(r => r.GetUnprocessVideos()).Returns(new List<Video>()
            {
                new Video() {Id = 1 },
                new Video() {Id = 2 },
                new Video() {Id = 3 }

            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
