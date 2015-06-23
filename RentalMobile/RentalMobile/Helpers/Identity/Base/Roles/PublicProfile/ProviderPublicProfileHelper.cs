using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Social;
using RentalMobile.Helpers.Team;
using RentalMobile.Helpers.Visitor;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PublicProfile
{
    public class ProviderPublicProfileHelper : BaseController , IProviderPublicProfileHelper
    {
        public ProviderPublicProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ProviderProfileViewVisitor GetProviderProfileViewVisitorProperties()
        {
            string visitorEmail = null;
            if (HttpContext.Request.IsAuthenticated)
            {
                var user = MembershipService.GetUser(HttpContext.User.Identity.Name);
                if (user != null)
                {
                    if (user.Email != null)
                    {
                        visitorEmail = user.Email;
                    }
                    return new ProviderProfileViewVisitor
                    {
                        EmailAddress = visitorEmail,
                        Name = HttpContext.User.Identity.Name
                    };
                }
            }
            return null;
        }

        public string TeamName(int maintenanceProviderId)
        {
            var teamAssociation =
                            UnitofWork
                            .MaintenanceTeamAssociationRepository.FirstOrDefault(x => x.MaintenanceProviderId == maintenanceProviderId);

            if (teamAssociation != null)
            {
                return teamAssociation.TeamName;
            }
           return null;
        }

        public List<Teammember> GetTeamByProviderId(int maintenanceProviderId)
        {
            var providerId = UserHelper.GetProviderId(maintenanceProviderId);
            if (maintenanceProviderId != 0)
            {
                var provider = UnitofWork.MaintenanceProviderRepository.
                    FindBy(x => x.MaintenanceProviderId == providerId).FirstOrDefault();

                if (provider != null)
                {
                    var teamAssociationCount =
                            UnitofWork
                            .MaintenanceTeamAssociationRepository.Count(x => x.MaintenanceProviderId == provider.MaintenanceProviderId);
                    if (teamAssociationCount > 0)
                    {
                        var teamAssociation =
                            UnitofWork
                            .MaintenanceTeamAssociationRepository.FindBy(x => x.MaintenanceProviderId == provider.MaintenanceProviderId);

                        return GetTeamByTeamAssociation(teamAssociation);
                    }
              
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public List<Teammember> GetTeamByTeamAssociation(IEnumerable<MaintenanceTeamAssociation> team)
        {
            var myTeam = 
            (
             from i in team
                let currentSpecialist = UnitofWork.SpecialistRepository.First(x => x.SpecialistId == i.SpecialistId)
                let specialistDescription = currentSpecialist.Description
                let description = (currentSpecialist != null && specialistDescription != null) ? specialistDescription.Length : 0
                    select new Teammember
                        {
                            SpecialistId = i.SpecialistId,
                            SpecialistName = currentSpecialist.FirstName + currentSpecialist.LastName,
                            YearofExperience = GetSpecialistYearofExperience(i.SpecialistId),
                            SpecialistDescription = description < 200 ? specialistDescription : specialistDescription.Substring(0, 200),
                            SpecialistImageProfile = currentSpecialist.Photo
                        }).ToList();
            return myTeam;
        }

        public int GetSpecialistYearofExperience(int specialistId)
        {
            const int specialistrole = 1;
            var lookUp =
               UnitofWork.MaintenanceCompanyLookUpRepository.FindBy(x => x.Role == specialistrole && x.UserId == specialistId).FirstOrDefault();
            if (lookUp != null)
            {
                var companyId = lookUp.CompanyId;
                var maintenanceCompanySpecialization = UnitofWork.MaintenanceCompanySpecializationRepository.FindBy(x => x.CompanyId == companyId).FirstOrDefault();
                if (maintenanceCompanySpecialization != null)
                    return lookUp == null
                        ? 0
                        : maintenanceCompanySpecialization
                            .Years_Experience;
            }
            return 0;
        }

        public MaintenanceProvider GetPublicProfileProviderByProviderId(int id)
        {
            return UnitofWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId ==  id).FirstOrDefault();
        }

        public void ShareProvider(MaintenanceProvider s)
        {
            if (Request == null || Request.Url == null) return;
            var url = Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture);
            var title = SocialTitleBuilding(s);
            var summary = s.Description;
            if (!String.IsNullOrEmpty(summary))
            {
                if (summary.Length >= 140)
                {
                    summary = summary.Substring(0, 140);
                }
            }
            var tweet = title;
            if (tweet != null && title.Length >= 1)
            {
                tweet += "--";
            }
            tweet += url;
            if (!String.IsNullOrEmpty(tweet))
            {
                if (tweet.Length >= 140)
                {
                    tweet = tweet.Substring(0, 140);
                }
            }

            //TODO UPDATE BEFORE RELEASE
            const string sitename = "http://www.haithem-araissia.com";
            //This is the correct one for production because facebook require active url present. after you Register your domain
            //ViewBag.FaceBook = SocialHelper.FacebookShareOnlyUrl(url);
            //TOD UPDATE BEFORE RELEASE
            ViewBag.FaceBook = new SocialHelper().FacebookShareOnlyUrl(sitename);
            ViewBag.Twitter = new SocialHelper().TwitterShare(tweet);
            ViewBag.GooglePlusShare = new SocialHelper().GooglePlusShare(url);
            ViewBag.LinkedIn = new SocialHelper().LinkedInShare(url, title, summary, sitename);
        }

        public string SocialTitleBuilding(MaintenanceProvider s)
        {
            var title = s.FirstName;
            if (title != null)
            {
                title += " , ";
            }

            title += s.LastName;
            if (title.Length >= 1)
            {
                title += " , ";
            }

            title += s.Address;
            if (title.Length >= 1)
            {
                title += " , ";
            }

            title += s.Region;
            if (title.Length >= 1)
            {
                title += " , ";
            }
            title += s.City;
            if (title.Length >= 1)
            {
                title += " , ";
            }

            if (title.Length >= 50)
            {
                title = title.Substring(0, 50);
            }
            return title;
        }

        public string GetProviderCommentCount(int id)
        {
            if (id != 0)
            {
                var providerPublicProfileComment =
                    UnitofWork.ProviderProfileCommentRepository.FindBy(x => x.ProviderId == id).ToList();
                return providerPublicProfileComment.Any() ? "( " + providerPublicProfileComment.Count() + " )" : "";
            }
            return "";
        }

        public string GetProviderPrimaryWorkPhoto(int id)
        {
            var providerwork = UnitofWork.ProviderWorkRepository.FindBy(x => x.ProviderId == id).FirstOrDefault();
            return (providerwork == null || providerwork.PhotoPath == null) ? "./../images/dotimages/home-handyman-projects.jpg" : providerwork.PhotoPath;

        }

        public dynamic ProviderPublicComposeForwardToFriendEmail(string friendname, string friendemailaddress, string message, int id)
        {
            dynamic email = new Email("ForwardtoFriend/Multipart");
            var poster = UserHelper.GetSendtoFriendPoster(HttpContext.Request.Url) ?? UserHelper.PosterHelper.DefaultPoster;
            email.To = friendemailaddress;
            email.FriendName = friendname;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = poster.FirstName;
            email.Title = string.Format("Request From {0}", poster.FirstName);
            email.SubTitle = "Request from ";
            email.Message = message;
            email.InvitationNote = " invite you to see this skilled provider.";
            email.FooterNote = "Check out this Provider";
            var uri = Request.Url;
            if (uri != null)
            {
                var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                email.ProfileUrl = host + uri.AbsolutePath.Replace("ForwardtoFriend", "");
                var currentProvider = UserHelper.GetPublicProfileProviderByProviderId(id);
                if (currentProvider != null)
                {
                    var specialistTitle = currentProvider.FirstName + " , " + currentProvider.LastName;
                    if (specialistTitle.Length >= 50)
                    {
                        specialistTitle = specialistTitle.Substring(0, 50);
                    }
                    email.CustomTitle = specialistTitle;
                }
                if (currentProvider != null)
                {
                    email.PhotoPath = host + "/" + GetProviderPrimaryWorkPhoto(id).Replace("../../", "");
                }
            }
            return email;
        }

    }
}