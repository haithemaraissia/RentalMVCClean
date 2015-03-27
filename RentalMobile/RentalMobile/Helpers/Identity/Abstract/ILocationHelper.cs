using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMobile.Helpers.Identity.Abstract
{
    public interface ILocationHelper
    {
        bool ValidateLocation(string location);
        string GetFormattedAdress(string location);
        string GetFormattedLocation(string address, string city, string country);
    }
}
