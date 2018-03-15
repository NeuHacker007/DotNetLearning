/**
* @Project Name: $projectname$ ： VideoRepository
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Mocking
* @Creation Time:  3/15/2018 9:50:19 AM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/15/2018 9:50:19 AM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessVideos();
    }

    class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessVideos()
        {
            using (var context = new VideoContext())
            {
                var videos = (from video in context.Videos
                              where !video.IsProcessed
                              select video).ToList();
                return videos;
            }
        }

    }
}
