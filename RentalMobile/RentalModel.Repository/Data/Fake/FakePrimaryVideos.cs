using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakePrimaryVideo
    { 
       public List<PrimaryVideo> MyPrimaryVideos;

       public FakePrimaryVideo()
        {
            InitializePrimaryVideoList();
        }

       public void InitializePrimaryVideoList()
        {
            MyPrimaryVideos = new List<PrimaryVideo> {
                FirstPrimaryVideo(), 
                SecondPrimaryVideo(),
                ThirdPrimaryVideo()
            };
        }

       public PrimaryVideo FirstPrimaryVideo()
        {

            var firstPrimaryVideo = new PrimaryVideo {

                 YouTubeVideo = new Boolean()
,
                 YouTubeVideoUrl = null,
                 VimeoVideo = new Boolean()
,
                 VimeoVideoUrl = null
         
 };

            return firstPrimaryVideo;
        }

       public PrimaryVideo SecondPrimaryVideo()
        {

            var secondPrimaryVideo = new PrimaryVideo {

                 YouTubeVideo = new Boolean()
,
                 YouTubeVideoUrl = null,
                 VimeoVideo = new Boolean()
,
                 VimeoVideoUrl = null
        
 };

            return secondPrimaryVideo;
        }

       public PrimaryVideo ThirdPrimaryVideo()
        {

            var thirdPrimaryVideo = new PrimaryVideo {

                 YouTubeVideo = new Boolean()
,
                 YouTubeVideoUrl = null,
                 VimeoVideo = new Boolean()
,
                 VimeoVideoUrl = null
 
 };

            return thirdPrimaryVideo;
        }

        ~FakePrimaryVideo()
        {
            MyPrimaryVideos = null;
        }
    }
}


    