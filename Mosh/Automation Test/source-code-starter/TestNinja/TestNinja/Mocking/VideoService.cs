using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoRepository _repository;


        public VideoService(IFileReader reader = null, IVideoRepository repository = null)
        {
            _fileReader = reader ?? new FileReader();
            _repository = repository ?? new VideoRepository();
        }
        public string ReadVideoTitle()
        {
            // var str = File.ReadAllText("video.txt"); //this time here it depend on the other class File
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();


            var videos = _repository.GetUnprocessVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);

        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}