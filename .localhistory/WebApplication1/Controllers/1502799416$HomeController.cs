﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoLibrary;
using NReco.VideoConverter;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string url = "https://www.youtube.com/watch?v=7TxEZvkjwhk";
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(url); // gets a Video object with info about the video

           // System.IO.File.WriteAllBytes(@"C:\Downloads\" + video.FullName, video.GetBytes());
            var videoName = @"C:\Downloads\" + video.FullName;
            var ffmpeg = new NReco.VideoConverter.FFMpegConverter();
            System.IO.Stream stream = new System.IO.MemoryStream(video.GetBytes(),0,video.GetBytes().Length);

            // ffmpeg.ConvertMedia(videoName, null, @"C:\Downloads\result.gif", null, new ConvertSettings() { VideoFrameRate = 1, MaxDuration = 10 });
            ffmpeg.ConvertLiveMedia(stream,, @"C:\Downloads\result.gif", null, new ConvertSettings() { VideoFrameRate = 1, MaxDuration = 10 });
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}