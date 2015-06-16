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





    public class FeedResult : FileResult
    {
        public enum FeedType
        {
            Rss,
            Atom
        }

        private readonly SyndicationFeed _feed;
        private FeedType type;

        public FeedResult(SyndicationFeed feed, FeedType type)
            : base("application/rss+xml")
        {
            this._feed = feed;
            this.type = type;
        }



        //private static void WriteToAtomFormatter(ControllerContext context, SyndicationFeed feed)
        //{
        //    var atomFormatter = new Atom10FeedFormatter(feed);
        //    using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
        //    {
        //        atomFormatter.WriteTo(writer);
        //    }
        //}

        //private static void WriteToRssFormatter(ControllerContext context, SyndicationFeed feed)
        //{
        //    var rssFormatter = new Rss20FeedFormatter(feed);
        //    using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
        //    {
        //        rssFormatter.WriteTo(writer);
        //    }
        //}

        //public override void ExecuteResult(ControllerContext context)
        //{

        //    using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.OutputStream))
        //    {
        //        switch (this.type)
        //        {
        //            case FeedType.Rss:
        //                this._feed.GetRss20Formatter().WriteTo(writer);
        //                break;
        //            case FeedType.Atom:
        //                this._feed.GetAtom10Formatter().WriteTo(writer);
        //                break;
        //        }
        //    }

        //}

        protected override void WriteFile(HttpResponseBase response)
        {
            using (XmlWriter writer = XmlWriter.Create(response.OutputStream))
            {
                switch (this.type)
                {
                    case FeedType.Rss:
                        this._feed.GetRss20Formatter().WriteTo(writer);
                        break;
                    case FeedType.Atom:
                        this._feed.GetAtom10Formatter().WriteTo(writer);
                        break;
                }
            }
        }
    }

}