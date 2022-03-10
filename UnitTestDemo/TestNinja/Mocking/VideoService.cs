

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoRepository _repository;

        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _repository = repository ?? new VideoRepository();
        }
        
        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            //var video = JsonConvert.DeserializeObject<Video>(str);
            var video = JsonSerializer.Deserialize<Video>(str); 
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = _repository.GetUnprocessedVideos();                            
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