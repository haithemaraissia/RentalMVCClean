using System;

namespace RentalMobile.Helpers.Social
{
    public  class SocialHelper
    {
        public string FacebookShare(string url, string primaryimagethumbnail, string title, string summary)
        {

            return String.Format(@"http://www.facebook.com/sharer/sharer.php?s=100&p[url]={0}&p[images][0]={1}&p[title]={2}&p[summary]={3}", url, primaryimagethumbnail, title, summary);

        }
        
        public  string FacebookShareOnlyUrl(string url)
        {

            return String.Format(@"http://www.facebook.com/sharer/sharer.php?s=100&p[url]={0}", url);

        }

        public  string TwitterShare(string tweet)
        {

            return String.Format(@"http://twitter.com/home?status={0}", tweet);

        }

        public  string GooglePlusShare(string url)
        {

            return String.Format(@"https://plus.google.com/share?url={0}", url);
        }

        public  string LinkedInShare(string url, string title, string summary, string sitename)
        {
            return String.Format(@"http://www.linkedin.com/shareArticle?mini=true&url={0}&title={1}&summary={2}&source={3}", url, title, summary, sitename);

        }
    }
}




