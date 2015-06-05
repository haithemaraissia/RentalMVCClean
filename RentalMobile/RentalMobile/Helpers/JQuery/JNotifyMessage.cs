using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalMobile.Helpers.JQuery
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