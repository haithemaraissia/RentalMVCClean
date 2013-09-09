using System;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;


namespace RentalMobile.Helpers
{


    public class RssResult : ActionResult
    {

        private readonly SyndicationFeed _feed;

        public RssResult(SyndicationFeed feed)
        {

            this._feed = feed;

        }



        private static void WriteToAtomFormatter(ControllerContext context, SyndicationFeed feed)
        {
            var atomFormatter = new Atom10FeedFormatter(feed);
            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                atomFormatter.WriteTo(writer);
            }
        }

        private static void WriteToRssFormatter(ControllerContext context, SyndicationFeed feed)
        {
            var rssFormatter = new Rss20FeedFormatter(feed);
            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                rssFormatter.WriteTo(writer);
            }
        }

        public override void ExecuteResult(ControllerContext context)
        {

            context.HttpContext.Response.ContentType = "application/rss+xml";

            var formatter = new Rss20FeedFormatter(_feed);

            using (var writer = new XmlTextWriter(context.HttpContext.Response.OutputStream, Encoding.UTF8))
            {

                formatter.WriteTo(writer);

            }

        }


    }




}