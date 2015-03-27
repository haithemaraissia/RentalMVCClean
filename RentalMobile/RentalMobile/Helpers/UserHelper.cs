using System;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RentalMobile.Helpers.Identity.Correct;
using RentalMobile.Model.Models;
using System.Web.Security;

namespace RentalMobile.Helpers
{
    public static class UserHelper
    {
        public static readonly RentalContext Db = new RentalContext();
        public static string DefaultAvatarPlaceholderImagePath = "../../images/dotimages/avatar-placeholder.png";
        public static string DefaultSpecialistName = "Specialist";
        public static string TenantPhotoPath = "~/Photo/Tenant/Property";
        public static string OwnerPhotoPath = "~/Photo/Owner/Property";
        public static string AgentPhotoPath = "~/Photo/Agent/Property";
        public static string ProviderPhotoPath = "~/Photo/Provider/Property";
        public static string SpecialistPhotoPath = "~/Photo/Specialist/Property";

        public static PosterAttributes DefaultPoster = new PosterAttributes("A Friend", "Friend", "#", "../../images/dotimages/single-property/agent-480x350.png", "none@yahoo.com", "notauthenticated", 0);

        public static string Login()
        {
            return "~/NotAuthenticated/SignIn.aspx?ReturnUrl={0}" + HttpContext.Current.Request.Url.AbsoluteUri;

        }

        public static string GetUserName()
        {
            var currentuser = System.Web.Security.Membership.GetUser(HttpContext.Current.User.Identity.Name);
            return currentuser != null ? currentuser.UserName : Login();
        }

        public static Guid? GetUserGuid()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var user = System.Web.Security.Membership.GetUser(HttpContext.Current.User.Identity.Name);
                if (user != null && user.ProviderUserKey != null)
                {
                    return (Guid)user.ProviderUserKey;
                }
            }
            return null;
        }

        public static int? GetTenantId(Guid userId)
        {
            var tenant = Db.Tenants.FirstOrDefault(x => x.GUID == userId);
            if (tenant != null) return tenant.TenantId;
            return null;
        }

        public static int? GetTenantId()
        {
            var userId = GetUserGuid();
            var tenant = Db.Tenants.FirstOrDefault(x => x.GUID == userId);
            if (tenant != null) return tenant.TenantId;
            return null;
        }

        public static int? GetTenantId(int id)
        {
            var userId = Db.Tenants.FirstOrDefault(x => x.TenantId == id);
            if (userId != null)
            {
                var tenant = Db.Tenants.FirstOrDefault(x => x.GUID == userId.GUID);
                if (tenant != null) return tenant.TenantId;
            }
            return null;
        }

        public static int? GetAgentId()
        {
            var userId = GetUserGuid();
            var agent = Db.Agents.FirstOrDefault(x => x.GUID == userId);
            if (agent != null) return agent.AgentId;
            return null;
        }

        public static int? GetAgentId(int id)
        {
            var userId = Db.Agents.FirstOrDefault(x => x.AgentId == id);
            if (userId != null)
            {
                var agent = Db.Agents.FirstOrDefault(x => x.GUID == userId.GUID);
                if (agent != null) return agent.AgentId;
            }
            return null;
        }

        public static int? GetOwnerId()
        {
            var userId = GetUserGuid();
            var owner = Db.Owners.FirstOrDefault(x => x.GUID == userId);
            if (owner != null) return owner.OwnerId;
            return null;
        }

        public static int? GetOwnerId(int id)
        {
            var userId = Db.Owners.FirstOrDefault(x => x.OwnerId == id);
            if (userId != null)
            {
                var owner = Db.Owners.FirstOrDefault(x => x.GUID == userId.GUID);
                if (owner != null) return owner.OwnerId;
            }
            return null;
        }

        public static int? GetSpecialistId()
        {
            var userId = GetUserGuid();
            var specialist = Db.Specialists.FirstOrDefault(x => x.GUID == userId);
            if (specialist != null) return specialist.SpecialistId;
            return null;
        }

        public static int? GetSpecialistId(int id)
        {
            var userId = Db.Specialists.FirstOrDefault(x => x.SpecialistId == id);
            if (userId != null)
            {
                var specialist = Db.Specialists.FirstOrDefault(x => x.GUID == userId.GUID);
                if (specialist != null) return specialist.SpecialistId;
            }
            return null;
        }

        public static int? GetProviderId()
        {
            var userId = GetUserGuid();
            var provider = Db.MaintenanceProviders.FirstOrDefault(x => x.GUID == userId);
            if (provider != null) return provider.MaintenanceProviderId;
            return null;
        }

        public static int? GetProviderId(int id)
        {
            var userId = Db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
            if (userId != null)
            {
                var provider = Db.MaintenanceProviders.FirstOrDefault(x => x.GUID == userId.GUID);
                if (provider != null) return provider.MaintenanceProviderId;
            }
            return null;
        }

        ////TODO ASynchrnous 
        //public static string GetFormattedAdress(string location)
        //{
        //    var address = String.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false", location.Replace(" ", "+"));
        //    byte[] result = null;
        //    var client = new WebClient();
        //    client.DownloadDataCompleted +=
        //        (sender, e) => result = e.Result;
        //    client.DownloadDataAsync(new Uri(address));
        //    if (result != null)
        //    {
        //        var test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(Encoding.ASCII.GetString(result));
        //        return test.results[0].formatted_address;
        //    }
        //    return GetFormattedAdress(ValidateLocation(address) ? address : "USA");
        //}

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



        public static string GetCurrentRole(out string photoPath)
        {
            var user = HttpContext.Current.User;
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
                return "Agent";
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

                if (requestUrl != null)
                {
                    var result = string.Format("{0}://{1}{2}",
                                               requestUrl.Scheme,
                                               requestUrl.Authority,
                                               VirtualPathUtility.ToAbsolute(virtualPath));
                    return result;
                }
                return null;
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

            var unit = Db.Units.FirstOrDefault(x => x.UnitId == uniId);
            if (unit != null && unit.PosterRole != null)
            {
                switch (unit.PosterRole.Trim().ToLower())
                {
                    case "owner":
                        var owner = Db.Owners.Find(unit.PosterID);
                        if (owner != null)
                        {
                            return new PosterAttributes(owner.FirstName, owner.LastName, currenturl + "/ownerprofile/index/" + unit.PosterID, owner.Photo, owner.EmailAddress, "owner", owner.OwnerId);
                        }
                        break;
                    case "agent":
                        var agent = Db.Agents.Find(unit.PosterID);
                        if (agent != null)
                        {
                            return new PosterAttributes(agent.FirstName, agent.LastName, currenturl + "/agentprofile/index/" + unit.PosterID, agent.Photo, agent.EmailAddress, "agent", agent.AgentId);
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

        public static string GetCurrencyValue(int? currencyId)
        {
            var currency = Db.Currencies.FirstOrDefault(x => x.CurrencyID == currencyId);
            if (currency != null)
                return currency.CurrencyValue;
            return Db.Currencies.First().CurrencyValue;
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
                var tenant = Db.Tenants.Find(GetTenantId());
                if (tenant != null)
                {
                    return new PosterAttributes(tenant.FirstName, tenant.LastName,
                                                currenturl + "/tenantprofile/index/" + tenant.TenantId, tenant.Photo,
                                                tenant.EmailAddress, "tenant", tenant.TenantId);
                }
            }
            if (role == "Owner")
            {
                var owner = Db.Owners.Find(GetOwnerId());
                if (owner != null)
                {
                    return new PosterAttributes(owner.FirstName, owner.LastName,
                                                currenturl + "/ownerprofile/index/" + owner.OwnerId, owner.Photo,
                                                owner.EmailAddress, "owner", owner.OwnerId);
                }
            }
            if (role == "Agent")
            {
                var agent = Db.Agents.Find(GetAgentId());
                if (agent != null)
                {
                    return new PosterAttributes(agent.FirstName, agent.LastName,
                                                currenturl + "/agentprofile/index/" + agent.AgentId, agent.Photo,
                                                agent.EmailAddress, "tenant", agent.AgentId);
                }
            }

            if (role == "Specialist")
            {
                //For Testing Before Rewritting this piece
                var specialist2 = Db.Agents.Find(new UserIdentity().GetSpecialistId());
                //For Testing Before Rewritting this piece
                var specialist = Db.Specialists.Find(GetSpecialistId());
                if (specialist != null)
                {
                    return new PosterAttributes(specialist.FirstName, specialist.LastName,
                                                currenturl + "/professionals/" + specialist.SpecialistId, specialist.Photo,
                                                specialist.EmailAddress, "specialist", specialist.SpecialistId);
                }
            }


            if (role == "Provider")
            {
                var provider = Db.MaintenanceProviders.Find(GetProviderId());
                if (provider != null)
                {
                    return new PosterAttributes(provider.FirstName, provider.LastName,
                                                currenturl + "/providers/" + provider.MaintenanceProviderId, provider.Photo,
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
                var tenant = Db.Tenants.Find(GetTenantId());
                if (tenant != null)
                {
                    return new PosterAttributes(tenant.FirstName, tenant.LastName,
                                                currenturl + "/tenantprofile/index/" + tenant.TenantId, tenant.Photo,
                                                tenant.EmailAddress, "tenant", tenant.TenantId);
                }
            }
            if (role == "Owner")
            {
                var owner = Db.Owners.Find(GetOwnerId());
                if (owner != null)
                {
                    return new PosterAttributes(owner.FirstName, owner.LastName,
                                                currenturl + "/ownerprofile/index/" + owner.OwnerId, owner.Photo,
                                                owner.EmailAddress, "owner", owner.OwnerId);
                }
            }
            if (role == "Agent")
            {
                var agent = Db.Agents.Find(GetAgentId());
                if (agent != null)
                {
                    return new PosterAttributes(agent.FirstName, agent.LastName,
                                                currenturl + "/agentprofile/index/" + agent.AgentId, agent.Photo,
                                                agent.EmailAddress, "tenant", agent.AgentId);
                }
            }

            if (role == "Specialist")
            {
                var specialist = Db.Specialists.Find(GetSpecialistId());
                if (specialist != null)
                {
                    return new PosterAttributes(specialist.FirstName, specialist.LastName,
                                                currenturl + "/professionals/" + specialist.SpecialistId, specialist.Photo,
                                                specialist.EmailAddress, "specialist", specialist.SpecialistId);
                }
            }


            if (role == "Provider")
            {
                var provider = Db.MaintenanceProviders.Find(GetProviderId());
                if (provider != null)
                {
                    return new PosterAttributes(provider.FirstName, provider.LastName,
                                                currenturl + "/providers/" + provider.MaintenanceProviderId, provider.Photo,
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
                case "notauthenticated":
                    return 6;
                default:
                    return 6;
            }
        }

        public static string GetTeamPrimaryPhoto(int id)
        {
            var maintenanceProvider = Db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
            return maintenanceProvider != null ? maintenanceProvider.Photo.ToString(CultureInfo.InvariantCulture) : DefaultAvatarPlaceholderImagePath;
        }

        public static string GetSpecialistPrimaryPhoto(int id)
        {
            var specialist = Db.Specialists.FirstOrDefault(x => x.SpecialistId == id);
            return specialist != null ? specialist.Photo.ToString(CultureInfo.InvariantCulture) : DefaultAvatarPlaceholderImagePath;
        }

        public static string GetSpecialistName(int id)
        {
            var specialist = Db.Specialists.FirstOrDefault(x => x.SpecialistId == id);
            return specialist != null ? specialist.FirstName + " " + specialist.LastName : DefaultSpecialistName;
        }

        public static int GetTotalAvailableZoneSpotForProvider(int providerId)
        {
            //For each member, you get an extra 1 zone
            //Plus Provider Own zone From Company Zone
            return Db.MaintenanceTeamAssociations.Count(x => x.MaintenanceProviderId == providerId) * 2 + 1;
        }

    }
}



