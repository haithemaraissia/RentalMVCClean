using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using RentalMobile.Helpers;


namespace RentalMobile.Helpers
{
    public static class Email
    {

           //public static void SendEmail(string userEmail, string userName, int lcid, string templateUrl,Message messageType)


        public static void SendEmail(string fromsender, string toreceiver,  string templateUrl )
        {
            var url = "";
            url = templateUrl;
            string subject = "Forward to friend";
            //switch (messageType)
            //{
            //    case Message.NewOption:
            //        url = templateUrl + "?&l=" + Utility.GetLanguage(lcid) + "&prid=" + ProjectID + "&pid=" + BidderID;
            //        break;

            //    case Message.NewOpportunity:
            //        url = templateUrl + "?&l=" + Utility.GetLanguage(lcid) + "&prid=" + ProjectID + "&pid=" + BidderID;
            //        break;
            //}

            //const string strFrom = "postmaster@my-side-job.com";


            var mailMsg = MailMessageInline(fromsender, toreceiver, url, subject);


            /////http://stackoverflow.com/questions/5034503/adding-an-attachment-to-email-using-c-sharp

            ////Attache a file
            //var attachment = new Attachment("your attachment file");
            //mailMsg.Attachments.Add(attachment);
            try
            {
                //smtpMail.Send(mailMsg);

                var client = new SmtpClient();
                client.Send(mailMsg);
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
                throw;
            }
        }

        public static MailMessage MailMessageInline(string fromsender, string toreceiver, string url, string subject)
        {
            var mailMsg = new MailMessage(new MailAddress(fromsender), new MailAddress(toreceiver))
                              {
                                  BodyEncoding = Encoding.Default,
                                  Subject = subject,
                                  //Subject = Resources.Resource.Notification,
                                  Body = GetHtmlFrom(url),
                                  Priority = MailPriority.High,
                                  IsBodyHtml = true
                              };
            var smtpMail = new SmtpClient();
            var basicAuthenticationInfo = new NetworkCredential("postmaster@my-side-job.com", "haithem759163");
            smtpMail.Host = "mail.my-side-job.com";
            smtpMail.UseDefaultCredentials = false;
            smtpMail.Credentials = basicAuthenticationInfo;
            smtpMail.Port = 587;
            return mailMsg;
        }

        public static string GetHtmlFrom(string url)
        {
            dynamic wc = new WebClient();
            dynamic resStream = wc.OpenRead(url);
            if (resStream != null)
            {
                dynamic sr = new StreamReader(resStream, Encoding.Default);
                return sr.ReadToEnd();
            }
            return "null";
        }

    }
}
