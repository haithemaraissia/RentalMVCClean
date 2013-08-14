using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMobile.Helpers
{
    public static class SocialHelper
    {

        public static string FacebookShare()
        {
            return @"http://www.facebook.com/sharer/sharer.php?s=100&p[url]=http://www.haithem-araissia.com&p[images][0]=customthumbnail&p[title]=customtitle&p[summary]=customsummary";
        }









        public static string TwitterShare()
        {
            //140characater
            return @"http://twitter.com/home?status=CustomTweet";

        }










        public static string GooglePlusShare()
        {
            return @"https://plus.google.com/share?url=CustomURL";
        }










        public static string LinkedInShare()
        {
           // return @"<script src='//platform.linkedin.com/in.js' type='text/javascript'>lang: en_US</script><script type='IN/Share' data-url='customurl'></script>";

            return @"http://www.linkedin.com/shareArticle?mini=true&url=YourURL&title=TheTitleOfYourWebPageGoesHere&summary=TheSummaryOfYourWebPageGoesHere&source=TheNameOfYourSiteGoesHere' rel='nofollow' onclick='NewWindow(this.href,'template_window','550','400','yes','center');return false' onfocus='this.blur()'> <img src='LinkedInShareButton.jpg' title='Share on LinkedIn' alt='Share on LinkedIn' width='100' height='100' border='0'";

        }
    }
}




