using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Net;
using Facebook;


namespace RentalMobile.Helpers
{
    public static class Facebook
    {
        public static void CheckAuthorization()
        {

            const string appId = "491313520953187";

            const string appSecret = "3d057585b000c1b1830b9de8ec7fb8f5";

            const string scope = "publish_stream,manage_pages";


            if (HttpContext.Current.Request["code"] == null)
            {

                HttpContext.Current.Response.Redirect(string.Format(

                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",

                    appId, HttpContext.Current.Request.Url.AbsoluteUri, scope));

            }

            else
            {

                var tokens = new Dictionary<string, string>();

                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",

                    appId, HttpContext.Current.Request.Url.AbsoluteUri, scope, HttpContext.Current.Request["code"], appSecret);

                var request = WebRequest.Create(url) as HttpWebRequest;

                if (request != null)
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response != null)
                        {
                            var reader = new StreamReader(response.GetResponseStream());
                            var vals = reader.ReadToEnd();

                            foreach (string token in vals.Split('&'))
                            {

                                //meh.aspx?token1=steve&token2=jake&...

                                tokens.Add(token.Substring(0, token.IndexOf("=", StringComparison.Ordinal)),

                                           token.Substring(token.IndexOf("=", StringComparison.Ordinal) + 1, token.Length - token.IndexOf("=", StringComparison.Ordinal) - 1));

                            }
                        }
                    }
                var accessToken = tokens["access_token"];



                var client = new FacebookClient(accessToken);
                client.Post("/me/feed", new { message = "test 101" });

            }

        }

    }

}


