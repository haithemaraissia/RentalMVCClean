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

            string app_id = "491313520953187";

            string app_secret = "3d057585b000c1b1830b9de8ec7fb8f5";

            string scope = "publish_stream,manage_pages";



            if (HttpContext.Current.Request["code"] == null)
            {

                HttpContext.Current.Response.Redirect(string.Format(

                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",

                    app_id, HttpContext.Current.Request.Url.AbsoluteUri, scope));

            }

            else
            {

                Dictionary<string, string> tokens = new Dictionary<string, string>();



                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",

                    app_id, HttpContext.Current.Request.Url.AbsoluteUri, scope, HttpContext.Current.Request["code"].ToString(), app_secret);



                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;



                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    StreamReader reader = new StreamReader(response.GetResponseStream());



                    string vals = reader.ReadToEnd();



                    foreach (string token in vals.Split('&'))
                    {

                        //meh.aspx?token1=steve&token2=jake&...

                        tokens.Add(token.Substring(0, token.IndexOf("=")),

                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));

                    }

                }



                string access_token = tokens["access_token"];



                var client = new FacebookClient(access_token);



                client.Post("/me/feed", new { message = "test 101" });

            }

        }

    }

}


