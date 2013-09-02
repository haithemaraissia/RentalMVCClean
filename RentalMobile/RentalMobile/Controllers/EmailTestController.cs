using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Postal;

namespace RentalMobile.Controllers
{
    public class EmailTestController : Controller
    {
        //
        // GET: /EmailTest/
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }


        public ActionResult Send(string @from, string to, string subject, string message, HttpPostedFileBase file)
        {

            //Regular sending
          //  Helpers.Email.SendEmail(@from,to, "http://localhost:56224/Emails/SendToFriend/SendToFriend.aspx");




            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment("your attachment file");
            //email.Attachments.Add(attachment);



            // This will look for a view in "~/Views/Emails/Example.cshtml".
            dynamic email = new Email("SendtoFriend/Multipart");
            // Assign any view data to pass to the view.
            // It's dynamic, so you can put whatever you want here.
            email.To = to;
            email.From = @from;
            email.Title = "Custom Title";
            email.Subject = subject;
            email.Message = message;
            email.Date = DateTime.UtcNow;
            ViewBag.Poster = "sdfgsdg@yhaoo.com";
            
            if (file != null)
            {
                email.Attach(new Attachment(file.InputStream, file.FileName));
            }

            // Send the email via a default Postal.EmailService object.
            // This will use the web.config smtp settings.
            try
            {
                email.SendAsync();

            }
            catch (Exception e)
            {
                //Write To Database Error
                //Output Message
                throw;
            }

            return RedirectToAction("Sent");
        }



        //public  void WorkingEmail()
        //{


        //    //Working

        //    var mailMessage = EmailService.CreateMailMessage(email);

        //    var mailMsg = new MailMessage(new MailAddress(email.From), new MailAddress(email.To))
        //    {
        //        BodyEncoding = Encoding.Default,
        //        Subject = "From " + email.To,
        //        Body = email.Message,
        //        Priority = MailPriority.High,
        //        IsBodyHtml = true
        //    };

        //    //Smtp Client to Send the Mail Message
        //    var smtpMail = new SmtpClient();
        //    var basicAuthenticationInfo = new NetworkCredential("postmaster@haithem-araissia.com", "haithem759163");
        //    smtpMail.Host = "mail.haithem-araissia.com";
        //    smtpMail.UseDefaultCredentials = false;
        //    smtpMail.Credentials = basicAuthenticationInfo;
        //    smtpMail.Port = 587;
        //    try
        //    {
        //        smtpMail.Send(mailMsg);
        //        smtpMail.Send(mailMessage);
        //    }
        //    catch (Exception)
        //    {
        //        Response.Redirect(Request.Url.ToString());
        //        throw;
        //    }
        //}














        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }





        //protected void SendEmail()
        //{
        //    Response.Write(@"<script language='javascript'>alert('Thank you for your email. I will contact you shortly.'); window.location = 'http://www.haithem-araissia.com/CSS/';</script>");
        //    string strTo = "postmaster@haithem-araissia.com";
        //    MailMessage MailMsg = new MailMessage(new MailAddress(EmailTextBox.Text.ToString()), new MailAddress(strTo));
        //    MailMsg.BodyEncoding = Encoding.Default;
        //    MailMsg.Subject = "From " + NameTextBox.Text.ToString();
        //    MailMsg.Body = Editor1.Content.ToString();
        //    MailMsg.Priority = MailPriority.High;
        //    MailMsg.IsBodyHtml = true;
        //    //Smtp Client to Send the Mail Message
        //    SmtpClient SmtpMail = new SmtpClient();
        //    System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("postmaster@haithem-araissia.com", "haithem759163");
        //    SmtpMail.Host = "mail.haithem-araissia.com";
        //    SmtpMail.UseDefaultCredentials = false;
        //    SmtpMail.Credentials = basicAuthenticationInfo;
        //    try
        //    {
        //        SmtpMail.Send(MailMsg);
        //    }
        //    catch (Exception)
        //    {
        //        Response.Redirect(Request.Url.ToString());
        //        throw;
        //    }
        //}

    }
}
