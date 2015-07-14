using System.Net.Mail;

namespace RentalMobile.Helpers.Email
{
    public interface IEmailService
    {
        void SendEmail(MailMessage message);
    }
}
