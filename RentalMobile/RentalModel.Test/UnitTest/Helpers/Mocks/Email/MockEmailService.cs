using System.Net.Mail;
using RentalMobile.Helpers.Email;

namespace TestProject.UnitTest.Helpers.Mocks.Email
{
    public class MockEmailService : IEmailService
    {
        private MailMessage sentMessage;

        public MailMessage SentMailMessage { get { return sentMessage; } }

        public void SendEmail(MailMessage message)
        {
            sentMessage = message;
        }
    }
}
