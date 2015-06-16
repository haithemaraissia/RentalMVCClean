namespace RentalMobile.Helpers.JQuery.JNotify
{
    public class JNotifyMessage
    {
        public string Message { get; set; }
        public string RedirectUrl { get; set; }

        public JNotifyMessage(string message, string redirectUrl)
        {
            Message = message;
            RedirectUrl = redirectUrl;
        }
    }
}