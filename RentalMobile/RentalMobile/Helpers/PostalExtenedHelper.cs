using System;
using System.Web;
using System.Web.Mvc;
using Postal;

namespace RentalMobile.Helpers
{
    public static class HtmlExtensions
    {
        public static IHtmlString EmbedImageExtended(this HtmlHelper html, string pathOrUrl, string alt = "", string height = "200px",  string width = "200px")
        {
            if (string.IsNullOrWhiteSpace(pathOrUrl))
                throw new ArgumentException("Path or URL required", "pathOrUrl");
            if (IsFileName(pathOrUrl))
                pathOrUrl = html.ViewContext.HttpContext.Server.MapPath(pathOrUrl);
            return new HtmlString(string.Format("<img src=\"cid:{0}\" alt=\"{1}\"/>", (object)((ImageEmbedder)html.ViewData["Postal.ImageEmbedder"]).AddImage(pathOrUrl, (string)null).ContentId, (object)html.AttributeEncode(alt)));
        }

        private static bool IsFileName(string pathOrUrl)
        {
            if (!pathOrUrl.StartsWith("http:", StringComparison.OrdinalIgnoreCase))
                return !pathOrUrl.StartsWith("https:", StringComparison.OrdinalIgnoreCase);
            else
                return false;
        }
    }
}
