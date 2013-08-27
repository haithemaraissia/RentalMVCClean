using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMobile.Helpers
{
    public static class SocialHelper
    {

        public static string FacebookShare(string url, string primaryimagethumbnail, string title, string summary )
        {


            return String.Format(@"http://www.facebook.com/sharer/sharer.php?s=100&p[url]={0}&p[images][0]={1}&p[title]={2}&p[summary]={3}", url, primaryimagethumbnail, title, summary);




          //  return @"http://www.facebook.com/sharer/sharer.php?s=100&p[url]=http://www.haithem-araissia.com&p[images][0]=customthumbnail&p[title]=customtitle&p[summary]=customsummary";
        }




        public static string TwitterShare(string tweet)
        {
            //140characater
          //  return @"http://twitter.com/home?status=CustomTweet";


            return String.Format(@"http://twitter.com/home?status={0}",tweet);

        }






        public static string GooglePlusShare(string url)
        {
            //return @"https://plus.google.com/share?url=CustomURL";


            return String.Format(@"https://plus.google.com/share?url={0}",url);
        }







        public static string LinkedInShare(string url, string title, string summary, string sitename)
        {
           // return @"<script src='//platform.linkedin.com/in.js' type='text/javascript'>lang: en_US</script><script type='IN/Share' data-url='customurl'></script>";



            //return @"http://www.linkedin.com/shareArticle?mini=true&url=YourURL&title=TheTitleOfYourWebPageGoesHere&summary=TheSummaryOfYourWebPageGoesHere&source=TheNameOfYourSiteGoesHere' rel='nofollow' onclick='NewWindow(this.href,'template_window','550','400','yes','center');return false' onfocus='this.blur()'> <img src='LinkedInShareButton.jpg' title='Share on LinkedIn' alt='Share on LinkedIn' width='100' height='100' border='0'";





            return String.Format(@"http://www.linkedin.com/shareArticle?mini=true&url={0}&title={1}&summary={2}&source={3}' rel='nofollow' onclick='NewWindow(this.href,'template_window','550','400','yes','center');return false' onfocus='this.blur()'> <img src='LinkedInShareButton.jpg' title='Share on LinkedIn' alt='Share on LinkedIn' width='100' height='100' border='0'", url,  title,  summary,  sitename);

        }
    }
}




