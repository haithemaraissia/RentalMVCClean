﻿using System;
using System.Globalization;
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

        public static string DefaultAvatarPlaceholderImagePath = "../../images/dotimages/avatar-placeholder.png";

        public static PosterAttributes DefaultPoster = new PosterAttributes("Friend", "Friend", "#", "../../images/dotimages/single-property/agent-480x350.png", "none@yahoo.com", null, 0);

        public static string Login()
        {
            return "~/NotAuthenticated/SignIn.aspx?ReturnUrl={0}" + HttpContext.Current.Request.Url.AbsoluteUri;

        }

        public static string GetUserName()
        {
            var currentuser = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            return currentuser != null ? currentuser.ToString() : Login();
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

        public static string TenantPhotoPath = "~/Photo/Tenant/Property";
        public static string OwnerPhotoPath = "~/Photo/Owner/Property";
        public static string AgentPhotoPath = "~/Photo/Agent/Property";
        public static string ProviderPhotoPath = "~/Photo/Provider/Property";
        public static string SpecialistPhotoPath = "~/Photo/Specialist/Property";
        public static string GetCurrentRole(out string photoPath)
        {
            var user = System.Web.HttpContext.Current.User;
            if (user.IsInRole("Tenant"))
            {
                photoPath = HttpContext.Current.Server.MapPath(TenantPhotoPath);
                return "Tenant";
            }
            if (user.IsInRole("Owner"))
            {
                photoPath = HttpContext.Current.Server.MapPath(OwnerPhotoPath);
                return "Owner";
            }
            if (user.IsInRole("Agent"))
            {
                photoPath = HttpContext.Current.Server.MapPath(AgentPhotoPath);
            }
            if (user.IsInRole("Provider"))
            {
                photoPath = HttpContext.Current.Server.MapPath(ProviderPhotoPath);
                return "Provider";
            }

            photoPath = HttpContext.Current.Server.MapPath(SpecialistPhotoPath);
            return user.IsInRole("Specialist") ? "Specialist" : null;
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




        //This is used to send To Friend for Profiles
        public static PosterAttributes GetSendtoFriendPoster()
        {
            var uri = HttpContext.Current.Request.Url;
            var currenturl = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Not Authenticated
                return DefaultPoster;
            }
            string photoPath;
            var role = GetCurrentRole(out photoPath);
            if (role == "Tenant")
            {
                var tenant = DB.Tenants.Find(GetTenantID());
                if (tenant != null)
                {
                    return new PosterAttributes(tenant.FirstName, tenant.LastName,
                                                currenturl + "/tenantprofile/index/" + tenant.TenantId, tenant.Photo,
                                                tenant.EmailAddress, "tenant", tenant.TenantId);
                }
            }
            if (role == "Owner")
            {
                var owner = DB.Owners.Find(GetOwnerID());
                if (owner != null)
                {
                    return new PosterAttributes(owner.FirstName, owner.LastName,
                                                currenturl + "/ownerprofile/index/" + owner.OwnerId, owner.Photo,
                                                owner.EmailAddress, "owner", owner.OwnerId);
                }
            }
            if (role == "Agent")
            {
                var agent = DB.Agents.Find(GetAgentID());
                if (agent != null)
                {
                    return new PosterAttributes(agent.FirstName, agent.LastName,
                                                currenturl + "/agentprofile/index/" + agent.AgentId, agent.Photo,
                                                agent.EmailAddress, "tenant", agent.AgentId);
                }
            }

            if (role == "Specialist")
            {
                var specialist = DB.Specialists.Find(GetSpecialistID());
                if (specialist != null)
                {
                    return new PosterAttributes(specialist.FirstName, specialist.LastName,
                                                currenturl + "/professionals/" + specialist.SpecialistId, specialist.Photo,
                                                specialist.EmailAddress, "specialist", specialist.SpecialistId);
                }
            }


            if (role == "Provider")
            {
                var provider = DB.MaintenanceProviders.Find(GetProviderID());
                if (provider != null)
                {
                    return new PosterAttributes(provider.FirstName, provider.LastName,
                                                currenturl + "/providerprofile/index/" + provider.MaintenanceProviderId, provider.Photo,
                                                provider.EmailAddress, "provider", provider.MaintenanceProviderId);
                }
            }

            return DefaultPoster;
        }



        public static PosterAttributes GetCommentPoster()
        {
            var uri = HttpContext.Current.Request.Url;
            var currenturl = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Not Authenticated
                return DefaultPoster;
            }
            string photoPath;
            var role = GetCurrentRole(out photoPath);
            if (role == "Tenant")
            {
                var tenant = DB.Tenants.Find(GetTenantID());
                if (tenant != null)
                {
                    return new PosterAttributes(tenant.FirstName, tenant.LastName,
                                                currenturl + "/tenantprofile/index/" + tenant.TenantId, tenant.Photo,
                                                tenant.EmailAddress, "tenant", tenant.TenantId);
                }
            }
            if (role == "Owner")
            {
                var owner = DB.Owners.Find(GetOwnerID());
                if (owner != null)
                {
                    return new PosterAttributes(owner.FirstName, owner.LastName,
                                                currenturl + "/ownerprofile/index/" + owner.OwnerId, owner.Photo,
                                                owner.EmailAddress, "owner", owner.OwnerId);
                }
            }
            if (role == "Agent")
            {
                var agent = DB.Agents.Find(GetAgentID());
                if (agent != null)
                {
                    return new PosterAttributes(agent.FirstName, agent.LastName,
                                                currenturl + "/agentprofile/index/" + agent.AgentId, agent.Photo,
                                                agent.EmailAddress, "tenant", agent.AgentId);
                }
            }

            if (role == "Specialist")
            {
                var specialist = DB.Specialists.Find(GetSpecialistID());
                if (specialist != null)
                {
                    return new PosterAttributes(specialist.FirstName, specialist.LastName,
                                                currenturl + "/professionals/" + specialist.SpecialistId, specialist.Photo,
                                                specialist.EmailAddress, "specialist", specialist.SpecialistId);
                }
            }


            if (role == "Provider")
            {
                var provider = DB.MaintenanceProviders.Find(GetProviderID());
                if (provider != null)
                {
                    return new PosterAttributes(provider.FirstName, provider.LastName,
                                                currenturl + "/providerprofile/index/" + provider.MaintenanceProviderId, provider.Photo,
                                                provider.EmailAddress, "provider", provider.MaintenanceProviderId);
                }
            }

            return DefaultPoster;
        }

        public static int GetRoleId(string chosenRole)
        {
           switch (chosenRole.ToLower())
           {
               case "tenant":
                   return 1;
               case "owner":
                   return 2;
               case "agent":
                   return 3;
               case "specialist":
                   return 4;
               case "provider":
                   return 5;
               default:
                   return 6;
           }
        }

        public static string GetTeamPrimaryPhoto(int id)
        {
            var maintenanceProvider = DB.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
            return maintenanceProvider != null ? maintenanceProvider.Photo.ToString(CultureInfo.InvariantCulture) : DefaultAvatarPlaceholderImagePath;
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



