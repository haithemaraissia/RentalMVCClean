using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace RentalMobile.Helpers.Email
{
    class EmailService : IEmailService
    {
        private readonly SmtpClient _client;

        public EmailService()
        {
            _client = new SmtpClient();
            object settings = ConfigurationManager.AppSettings["SMTP"];
            // assign settings to SmtpClient, and set any other behavior you 
            // from SmtpClient in your application, such as ssl, host, credentials, 
            // delivery method, etc
            // https://www.arclab.com/en/kb/email/list-of-smtp-and-pop3-servers-mailserver-list.html 

            var basicAuthenticationInfo = new NetworkCredential("postmaster@haithem-araissia.com", "haithem759163");
            _client.Host = "mail.haithem-araissia.com";
            _client.UseDefaultCredentials = false;
            _client.Credentials = basicAuthenticationInfo;

        }

        public void SendEmail(MailMessage message)
        {
            _client.Send(message);
        }

    }
}
