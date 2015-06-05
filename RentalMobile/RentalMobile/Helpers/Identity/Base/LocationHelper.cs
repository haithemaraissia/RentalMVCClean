using System;
using System.Net;
using Newtonsoft.Json;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base
{
    public class LocationHelper : BaseController, ILocationHelper
    {
        private readonly IGenericUnitofWork _unitOfWork;

        public LocationHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            _unitOfWork = uow;
        }

        public bool ValidateLocation(string location)
        {
            var address = String.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false", location.Replace(" ", "+"));
            var result = new WebClient().DownloadString(address);
            var test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result);
            return test.status == "OK";
        }

        public string GetFormattedAdress(string location)
        {
            var address = String.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false", location.Replace(" ", "+"));
            var result = new WebClient().DownloadString(address);
            var test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result);
            return test.results[0].formatted_address;
        }

        public string GetFormattedLocation(string address, string city, string country)
        {
            if (ValidateLocation(address))
            {
                return GetFormattedAdress(address);
            }

            address = city;
            if (ValidateLocation(address))
            {
                return GetFormattedAdress(address);
            }

            address = country;
            return GetFormattedAdress(ValidateLocation(address) ? address : "USA");
        }
    }
}