﻿using System;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Postal;
using RentalMobile.Helpers.Social;
using RentalMobile.Helpers.Visitor;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PublicProfile
{
    public class SpecialistPublicProfileHelper : BaseController, ISpecialistPublicProfileHelper
    {
        public string DefaultAvatarPlaceholderImagePath = "../../images/dotimages/avatar-placeholder.png";
        public string DefaultSpecialistName = "Specialist";


        public SpecialistPublicProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
            UserHelper = userHelper;
        }

        public SpecialistProfileViewVisitor GetSpecialistProfileViewVisitorProperties()
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
                    return new SpecialistProfileViewVisitor
                    {
                        EmailAddress = visitorEmail,
                        Name = HttpContext.User.Identity.Name
                    };
                }
            }
            return null;
        }

        public string GetTeamPrimaryPhoto(int id)
        {
            var maintenanceProvider = UnitofWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == id).FirstOrDefault();
            return maintenanceProvider != null ? maintenanceProvider.Photo.ToString(CultureInfo.InvariantCulture) : DefaultAvatarPlaceholderImagePath;
        }

        public string GetSpecialistPrimaryPhoto(int id)
        {
            var specialist = UnitofWork.SpecialistRepository.FindBy(x => x.SpecialistId == id).FirstOrDefault();
            return specialist != null ? specialist.FirstName + " " + specialist.LastName : DefaultSpecialistName;
        }

        public string GetSpecialistName(int id)
        {
            var specialist = UnitofWork.SpecialistRepository.FindBy(x => x.SpecialistId == id).FirstOrDefault();
            return specialist != null ? specialist.FirstName + " " + specialist.LastName : DefaultSpecialistName;
        }

        public int GetTotalAvailableZoneSpotForProvider(int providerId)
        {
           // For each member, you get an extra 1 zone
                //Plus Provider Own zone From Company Zone
            return UnitofWork.MaintenanceTeamAssociationRepository.All.Count(x => x.MaintenanceProviderId == providerId) * 2 + 1;
        }

        public Specialist GetPublicProfileSpecialistBySpecialistId(int id)
        {
            var specialistId = new UserIdentity(UnitofWork, MembershipService).GetSpecialistId(id);
           return  UnitofWork.SpecialistRepository.FindBy(x => x.SpecialistId == specialistId).FirstOrDefault();
        }


        public CommonSharedSocialLinks ShareSpecialist(Specialist s)
        {
            if (HttpContext.Request == null || HttpContext.Request.Url == null) return null;
            var url = HttpContext.Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture);
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
            return new  CommonSharedSocialLinks
            {
                FaceBook = new SocialHelper().FacebookShareOnlyUrl(sitename),
                Twitter = new SocialHelper().TwitterShare(tweet),
                GooglePlusShare = new SocialHelper().GooglePlusShare(url),
                LinkedIn = new SocialHelper().LinkedInShare(url, title, summary, sitename)
            };
        }

        public string SocialTitleBuilding(Specialist s)
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

        public string GetSpecialistCommentCount(int id)
        {
            if (id != 0)
            {
                var specialistPublicProfileComment =
                    UnitofWork.SpecialistProfileCommentRepository.FindBy(x => x.SpecialistId == id).ToList();
                return specialistPublicProfileComment.Any() ? "( " + specialistPublicProfileComment.Count() + " )" : "";
            }
            return "";
        }

        public string GetSpecialistPrimaryWorkPhoto(int id)
        {
            var specialistwork = UnitofWork.SpecialistWorkRepository.FindBy(x => x.SpecialistId == id).FirstOrDefault();
            return (specialistwork == null || specialistwork.PhotoPath == null) ? "./../images/dotimages/home-handyman-projects.jpg" : specialistwork.PhotoPath;
        }

        public dynamic SpecialPublicProfileComposeForwardToFriendEmail(string friendname, string friendemailaddress, string message, int id)
        {
            dynamic email = new Postal.Email("ForwardtoFriend/Multipart");
            var newposter = new PosterHelper(UnitofWork, MembershipService);
            var poster = newposter.GetSendtoFriendPoster(HttpContext.Request.Url);
            email.To = friendemailaddress;
            email.FriendName = friendname;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = poster.FirstName;
            email.Title = string.Format("Request From {0}", poster.FirstName);
            email.SubTitle = "Request from ";
            email.Message = message;
            email.InvitationNote = " invite you to see this skilled professional.";
            email.FooterNote = "Check out this Professional";
            var uri = HttpContext.Request.Url;
            if (uri != null)
            {
                var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                email.ProfileUrl = host + uri.AbsolutePath.Replace("ForwardtoFriend", "");
                var currentSpecialist = UserHelper.SpecialistPublicProfileHelper.GetPublicProfileSpecialistBySpecialistId(id);
                if (currentSpecialist != null)
                {
                    var specialistTitle = currentSpecialist.FirstName + " , " + currentSpecialist.LastName;
                    if (specialistTitle.Length >= 50)
                    {
                        specialistTitle = specialistTitle.Substring(0, 50);
                    }
                    email.CustomTitle = specialistTitle;
                }
                if (currentSpecialist != null)
                {
                    email.PhotoPath = host + "/" + GetSpecialistPrimaryWorkPhoto(id).Replace("../../", "");
                }
            }
            return email;
        }
    }


}