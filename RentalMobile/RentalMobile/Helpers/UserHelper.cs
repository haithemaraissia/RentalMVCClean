using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using Newtonsoft.Json;
using RentalMobile.Models;


namespace RentalMobile.Helpers
{
    public static class UserHelper
    {
        private static readonly DB_33736_rentalEntities DB = new DB_33736_rentalEntities();

        public static PosterAttributes DefaultPoster = new PosterAttributes("Unkown", "Unknow", "#", "../../images/dotimages/single-property/agent-480x350.png","none@yahoo.com",null,0);

        public static string Login()
        {
            return "~/NotAuthenticated/SignIn.aspx?ReturnUrl={0}" + HttpContext.Current.Request.Url.AbsoluteUri;

        }

        public static Guid? GetUserGUID()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                if (user != null && user.ProviderUserKey != null)
                {
                    return (Guid)user.ProviderUserKey;
                }
            }
            return null;
        }

        public static int? GetTenantID(Guid userID)
        {
            var tenant = DB.Tenants.FirstOrDefault(x => x.GUID == userID);
            if (tenant != null) return tenant.TenantId;
            return null;
        }

        public  static int? GetTenantID()
        {
            var userID = GetUserGUID();
            var tenant = DB.Tenants.FirstOrDefault(x => x.GUID == userID);
            if (tenant != null) return tenant.TenantId;
            return null;
        }

        public static int? GetTenantID(int id)
        {
            var userID = DB.Tenants.FirstOrDefault(x => x.TenantId == id);
            if (userID != null)
            {
                var Tenant = DB.Tenants.FirstOrDefault(x => x.GUID == userID.GUID);
                if (Tenant != null) return Tenant.TenantId;
            }
            return null;
        }

        public static int? GetAgentID()
        {
            var userID = GetUserGUID();
            var agent = DB.Agents.FirstOrDefault(x => x.GUID == userID);
            if (agent != null) return agent.AgentId;
            return null;
        }

        public static int? GetAgentID(int id)
        {
            var userID = DB.Agents.FirstOrDefault(x => x.AgentId == id);
            if (userID != null)
            {
                var Agent = DB.Agents.FirstOrDefault(x => x.GUID == userID.GUID);
                if (Agent != null) return Agent.AgentId;
            }
            return null;
        }

        public static int? GetOwnerID()
        {
            var userID = GetUserGUID();
            var owner = DB.Owners.FirstOrDefault(x => x.GUID == userID);
            if (owner != null) return owner.OwnerId;
            return null;
        }

        public static int? GetOwnerID(int id)
        {
            var userID = DB.Owners.FirstOrDefault(x => x.OwnerId == id);
            if (userID != null)
            {
                var owner = DB.Owners.FirstOrDefault(x => x.GUID == userID.GUID);
                if (owner != null) return owner.OwnerId;
            }
            return null;
        }

        public static int? GetSpecialistID()
        {
            var userID = GetUserGUID();
            var specialist = DB.Specialists.FirstOrDefault(x => x.GUID == userID);
            if (specialist != null) return specialist.SpecialistId;
            return null;
        }

        public static int? GetSpecialistID(int id)
        {
            var userID = DB.Specialists.FirstOrDefault(x => x.SpecialistId == id);
            if (userID != null)
            {
            var specialist = DB.Specialists.FirstOrDefault(x => x.GUID == userID.GUID);
            if (specialist != null) return specialist.SpecialistId; 
            }
            return null;
        }

        public static int? GetProviderID()
        {
            var userID = GetUserGUID();
            var Provider = DB.MaintenanceProviders.FirstOrDefault(x => x.GUID == userID);
            if (Provider != null) return Provider.MaintenanceProviderId;
            return null;
        }

        public static int? GetProviderID(int id)
        {
            var userID = DB.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
            if (userID != null)
            {
                var Provider = DB.MaintenanceProviders.FirstOrDefault(x => x.GUID == userID.GUID);
                if (Provider != null) return Provider.MaintenanceProviderId;
            }
            return null;
        }

        public static bool ValidateLocation(string location)
        {
            var address = String.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false", location.Replace(" ", "+"));
            var result = new System.Net.WebClient().DownloadString(address);
            var test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result);
            return test.status == "OK";
        }

        public static string GetFormattedAdress(string location)
        {
            var address = String.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false", location.Replace(" ", "+"));
            var result = new System.Net.WebClient().DownloadString(address);
            var test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result);
            return test.results[0].formatted_address;
        }

        public static string GetFormattedLocation(string address, string city, string country)
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



        public static class UrlHelperExtension
        {
            public static string ContentFullPath(UrlHelper url, string virtualPath)
            {
                var requestUrl = url.RequestContext.HttpContext.Request.Url;

                var result = string.Format("{0}://{1}{2}",
                                              requestUrl.Scheme,
                                              requestUrl.Authority,
                                              VirtualPathUtility.ToAbsolute(virtualPath));
                return result;
            }
        }



        public static string ResolveImageUrl(string relativeUrl)
        {

            return new Uri(HttpContext.Current.Request.Url, relativeUrl).AbsoluteUri;


            //if (VirtualPathUtility.IsAppRelative(relativeUrl))
            //{
            //    return VirtualPathUtility.ToAbsolute(relativeUrl);
            //}
            //else
            //{

 

            //    var curPath = WebPageContext.Current.Page.TemplateInfo.VirtualPath;
            //    var curDir = VirtualPathUtility.GetDirectory(curPath);
            //    return VirtualPathUtility.ToAbsolute(VirtualPathUtility.Combine(curDir, relativeUrl));

          


        }


        public static PosterAttributes GetPoster(int uniId)
        {
            var uri = HttpContext.Current.Request.Url;
            var currenturl = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

            var unit = DB.Units.FirstOrDefault(x => x.UnitId == uniId);
            if (unit != null && unit.PosterRole != null)
            {
                switch (unit.PosterRole.Trim().ToLower())
                {
                    case "owner":
                        var owner = DB.Owners.Find(unit.PosterID);
                        if (owner != null)
                        {
                            return new PosterAttributes(owner.FirstName, owner.LastName, currenturl + "/ownerprofile/index/" + unit.PosterID, owner.Photo, owner.EmailAddress,"owner", owner.OwnerId);
                        }
                        break;
                         case "agent":
                        var agent = DB.Agents.Find(unit.PosterID);
                        if (agent != null)
                        {
                            return new PosterAttributes(agent.FirstName, agent.LastName, currenturl + "/agentprofile/index/" + unit.PosterID, agent.Photo, agent.EmailAddress,"agent", agent.AgentId);
                        }
                        break;
                    default:
                        {
                            return DefaultPoster;
                        }
                }
            }
            return DefaultPoster;
        }


        public static string GetCurrencyValue( int? currencyId)
        {
            var currency = DB.Currencies.FirstOrDefault(x => x.CurrencyID == currencyId);
            if (currency != null)
                return currency.CurrencyValue;
            return DB.Currencies.First().CurrencyValue;
        }




    }


    public class PosterAttributes

{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileLink { get; set; }
        public string ProfilePicturePath { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public int PosterID { get; set; }

        public PosterAttributes(string f, string l, string pl, string pp, string e, string r, int pid)
        {
            FirstName = f;
            LastName = l;
            ProfileLink = pl;
            ProfilePicturePath = pp;
            EmailAddress = e;
            Role = r;
            PosterID = pid;
        }
}
}



