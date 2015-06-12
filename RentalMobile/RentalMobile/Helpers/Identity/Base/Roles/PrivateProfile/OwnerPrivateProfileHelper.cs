using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile;
using RentalMobile.Helpers.IO;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile
{
    public class OwnerPrivateProfileHelper : BaseController, IOwnerPrivateProfileHelper
    {
        #region OwnerHelper

        public string OwnerContractUploadPath = "~/Photo/Owner/UploadedContract";
        public string OwnerPropertyPhotoPath = "~/Photo/Owner/Property";
        public string RequestId;
        public string RequestType = "UploadedContract";

        public OwnerPrivateProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
        }

        public string OwnerUsername()
        {
            return new UserIdentity(UnitofWork, MembershipService).GetUserName();
        }

        public Owner GetOwner()
        {
            var ownerId = new UserIdentity(UnitofWork, MembershipService).GetOwnerId();
            return
                UnitofWork.OwnerRepository.FindBy(
                    x => x.OwnerId == ownerId).FirstOrDefault();
        }

        public Owner GetPrivateProfileOwnerByOwnerId(int id)
        {
            var ownerId = new UserIdentity(UnitofWork, MembershipService).GetOwnerId(id);
            return
                UnitofWork.OwnerRepository.FindBy(
                    x => x.OwnerId == ownerId).FirstOrDefault();
        }

        public string OwnerGoogleMap()
        {
            return string.IsNullOrEmpty(GetOwner().Address)
                ? UserHelper.GetFormattedLocation("", "", "USA")
                : UserHelper.GetFormattedLocation(GetOwner().Address, GetOwner().City, GetOwner().CountryCode);
        }


        public void DeleteOwnerRecords(int ownerId)
        {
            //Owner
            UnitofWork.OwnerRepository.Delete(GetPrivateProfileOwnerByOwnerId(ownerId));

            //OwnerShowing
            //var ownerShowings = UnitofWork.ownerShowingRepository.FindBy(x => x.ownerId == ownerId);
            //if (ownerShowings == null) return;
            //foreach (var ownerShowing in tenantShowings)
            //{
            //    UnitofWork.OwnerShowingRepository.Delete(ownerShowing);
            //}
            UnitofWork.Save();
        }

        public void DeleteOwnerMemebership()
        {
            var username = UserHelper.GetUserName();
            if (MembershipService.GetRolesForUser(username).Any())
            {
                MembershipService.RemoveUserFromRoles(username,
                    MembershipService.GetRolesForUser(username));
            }
            MembershipService.DeleteUser(username);
            MembershipService.SignOut();
        }

        #endregion

        #region Unit

        public const string PreviewPathWithHost = @"/Unit/Preview";

        public dynamic ComposeForwardUnitToFriendEmail(string friendname, string friendemailaddress, string message, int id)
        {
            dynamic email = new Email("ForwardtoFriend/Multipart");
            var poster = UserHelper.GetSendtoFriendPoster() ?? UserHelper.PosterHelper.DefaultPoster;
            email.To = friendemailaddress;
            email.FriendName = friendname;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = poster.FirstName;
            email.Title = string.Format("Request From {0}", poster.FirstName);
            email.SubTitle = "Request from ";
            email.Message = message;
            email.InvitationNote = " invite you to see this potential unit.";
            email.FooterNote = "Check out this Property";
            var uri = Request.Url;
            if (uri != null)
            {
                var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                var unitUrl = host + PreviewPathWithHost + id;
                email.UnitUrl = unitUrl;
                var currentunit = UnitofWork.UnitRepository.FindBy(x => x.UnitId == id).FirstOrDefault();
                if (currentunit != null)
                {
                    var unitPicture = currentunit.PrimaryPhoto;
                    unitPicture = unitPicture.Replace("../../", "");
                    string unitTitle;
                    if (String.IsNullOrEmpty(currentunit.Title))
                    {
                        unitTitle = (currentunit.Address + " , " + currentunit.State + " , " + currentunit.City);
                        if (unitTitle.Length >= 50)
                        {
                            unitTitle = unitTitle.Substring(0, 50);
                        }
                    }
                    else
                    {
                        unitTitle = currentunit.Title;
                        if (currentunit.Title.Length >= 50)
                        {
                            unitTitle = currentunit.Title.Substring(0, 50);
                        }
                    }
                    email.UnitTitle = unitTitle;
                    // email.UnitPath = "http://www.haithem-araissia.com/images/property/home12.jpg";
                    email.UnitPath = host + "/" + unitPicture;
                }
            }
            return email;
        }

        #endregion

        #region Application

        public List<OwnerPendingApplication> GetOwnerPendingApplication()
        {
            var ownerId = GetOwner().OwnerId;
            return UnitofWork.OwnerPendingApplicationRepository.
                FindBy(x => x.OwnerId == ownerId).ToList();
        }


        // ReSharper disable once FunctionComplexityOverflow
        public void OwnerAcceptApplicationByApplicationId(int pendingApplicationId)
        {
            var pendingApplication = UnitofWork.OwnerPendingApplicationRepository.
                FirstOrDefault(x => x.ApplicationId == pendingApplicationId);
            if (pendingApplication == null) return;
            var approvedapplication = new OwnerAcceptedApplication
            {
                FirstName = pendingApplication.FirstName,
                LastName = pendingApplication.LastName,
                MiddleName = pendingApplication.MiddleName,
                SocialSecurityNumber = pendingApplication.SocialSecurityNumber,
                DriverLicense = pendingApplication.DriverLicense,
                Phone = pendingApplication.Phone,
                CellPhone = pendingApplication.CellPhone,
                EmailAddress = pendingApplication.EmailAddress,
                CoSignerName = pendingApplication.CoSignerName,
                CoSignerAddress = pendingApplication.CoSignerAddress,
                CoSignerCity = pendingApplication.CoSignerCity,
                CoSignerState = pendingApplication.CoSignerState,
                CoSignerZipcode = pendingApplication.CoSignerZipcode,
                CoSignerPhone = pendingApplication.CoSignerPhone,
                CoSignerRelationShip = pendingApplication.CoSignerRelationShip,
                CoSignerEmailAddress = pendingApplication.CoSignerEmailAddress,
                OtherOccupant1Name = pendingApplication.OtherOccupant1Name,
                IsOccupant1Adult = pendingApplication.IsOccupant1Adult,
                RelationshipOccupant1ToApplicant = pendingApplication.RelationshipOccupant1ToApplicant,
                OtherOccupant2Name = pendingApplication.OtherOccupant2Name,
                IsOccupant2Adult = pendingApplication.IsOccupant2Adult,
                RelationshipOccupant2ToApplicant = pendingApplication.RelationshipOccupant2ToApplicant,
                OtherOccupant3Name = pendingApplication.OtherOccupant3Name,
                IsOccupant3Adult = pendingApplication.IsOccupant3Adult,
                RelationshipOccupant3ToApplicant = pendingApplication.RelationshipOccupant3ToApplicant,
                OtherOccupant4Name = pendingApplication.OtherOccupant4Name,
                IsOccupant4Adult = pendingApplication.IsOccupant4Adult,
                RelationshipOccupant4ToApplicant = pendingApplication.RelationshipOccupant4ToApplicant,
                EmployerName = pendingApplication.EmployerName,
                Income = pendingApplication.Income,
                WorkStartDate = pendingApplication.WorkStartDate,
                WorkEndDate = pendingApplication.WorkEndDate,
                EmployerAddress = pendingApplication.EmployerAddress,
                EmployerCity = pendingApplication.EmployerCity,
                EmployerState = pendingApplication.EmployerState,
                EmployerZipcode = pendingApplication.EmployerZipcode,
                EmployerPhone = pendingApplication.EmployerPhone,
                EmployerFax = pendingApplication.EmployerFax,
                CurrentLandloard = pendingApplication.CurrentLandloard,
                CurrentLandLoardPhone = pendingApplication.CurrentLandLoardPhone,
                CurrentLandLoardFax = pendingApplication.CurrentLandLoardFax,
                CurrentAddress = pendingApplication.CurrentAddress,
                CurrentAddressCity = pendingApplication.CurrentAddressCity,
                CurrentAddressState = pendingApplication.CurrentAddressState,
                CurrentAddressZip = pendingApplication.CurrentAddressZip,
                Rent = pendingApplication.Rent,
                CurrentRentStartDate = pendingApplication.CurrentRentStartDate,
                CurrentRentEndDate = pendingApplication.CurrentRentEndDate,
                PreviousLandloard = pendingApplication.PreviousLandloard,
                PreviousLandLoardPhone = pendingApplication.PreviousLandLoardPhone,
                PreviousLandLoardFax = pendingApplication.PreviousLandLoardFax,
                PreviousAddress = pendingApplication.PreviousAddress,
                PreviousAddressCity = pendingApplication.PreviousAddressCity,
                PreviousAddressState = pendingApplication.PreviousAddressState,
                PreviousAddressZip = pendingApplication.PreviousAddressZip,
                PreviousRent = pendingApplication.PreviousRent,
                PreviousRentStartDate = pendingApplication.PreviousRentStartDate,
                PreviousRentEndDate = pendingApplication.PreviousRentEndDate,
                EmergencyContactName = pendingApplication.EmergencyContactName,
                EmergencyContactRelationShip = pendingApplication.EmergencyContactRelationShip,
                EmergencyContactPhone = pendingApplication.EmergencyContactPhone,
                EmergencyContactAddress = pendingApplication.EmergencyContactAddress,
                EmergencyContactCity = pendingApplication.EmergencyContactCity,
                EmergencyContactState = pendingApplication.EmergencyContactState,
                EmergencyContactZipCode = pendingApplication.EmergencyContactZipCode,
                Pets = pendingApplication.Pets,
                PetsNumber = pendingApplication.PetsNumber,
                Pet1Brand = pendingApplication.Pet1Brand,
                Pet1Age = pendingApplication.Pet1Age,
                Pet1Weight = pendingApplication.Pet1Weight,
                Pet2Brand = pendingApplication.Pet2Brand,
                Pet2Age = pendingApplication.Pet2Age,
                Pet2Weight = pendingApplication.Pet2Weight,
                Vehicle1Make = pendingApplication.Vehicle1Make,
                Vehicle1Model = pendingApplication.Vehicle1Model,
                Vehicle1Year = pendingApplication.Vehicle1Year,
                Vehicle1Color = pendingApplication.Vehicle1Color,
                Vehicle1LicensePlate = pendingApplication.Vehicle1LicensePlate,
                Vehicle2Make = pendingApplication.Vehicle2Make,
                Vehicle2Model = pendingApplication.Vehicle2Model,
                Vehicle2Year = pendingApplication.Vehicle2Year,
                Vehicle2Color = pendingApplication.Vehicle2Color,
                Vehicle2LicensePlate = pendingApplication.Vehicle2LicensePlate,
                Vehicle3Make = pendingApplication.Vehicle3Make,
                Vehicle3Model = pendingApplication.Vehicle3Model,
                Vehicle3Year = pendingApplication.Vehicle3Year,
                Vehicle3Color = pendingApplication.Vehicle3Color,
                Vehicle3LicensePlate = pendingApplication.Vehicle3LicensePlate,
                Vehicle4Make = pendingApplication.Vehicle4Make,
                Vehicle4Model = pendingApplication.Vehicle4Model,
                Vehicle4Year = pendingApplication.Vehicle4Year,
                Vehicle4Color = pendingApplication.Vehicle4Color,
                Vehicle4LicensePlate = pendingApplication.Vehicle4LicensePlate,
                Bankruptcy = pendingApplication.Bankruptcy,
                LeaseDefaulted = pendingApplication.LeaseDefaulted,
                RefusedtoPayRent = pendingApplication.RefusedtoPayRent,
                EvictedFromRental = pendingApplication.EvictedFromRental,
                ConvictedofFelony = pendingApplication.ConvictedofFelony,
                TenantId = pendingApplication.TenantId,
                OwnerId = pendingApplication.OwnerId
            };
            UnitofWork.OwnerAcceptedApplicationRepository.Add(approvedapplication);
            UnitofWork.OwnerPendingApplicationRepository.Delete(pendingApplication);
            UnitofWork.Save();
        }

        // ReSharper disable once FunctionComplexityOverflow
        public void OwnerRejectApplicationByApplicationId(int pendingApplicationId)
        {
            var pendingApplication = UnitofWork.OwnerPendingApplicationRepository.
                FirstOrDefault(x => x.ApplicationId == pendingApplicationId);
            if (pendingApplication == null) return;
            var rejectedapplication = new OwnerRejectedApplication
            {
                FirstName = pendingApplication.FirstName,
                LastName = pendingApplication.LastName,
                MiddleName = pendingApplication.MiddleName,
                SocialSecurityNumber = pendingApplication.SocialSecurityNumber,
                DriverLicense = pendingApplication.DriverLicense,
                Phone = pendingApplication.Phone,
                CellPhone = pendingApplication.CellPhone,
                EmailAddress = pendingApplication.EmailAddress,
                CoSignerName = pendingApplication.CoSignerName,
                CoSignerAddress = pendingApplication.CoSignerAddress,
                CoSignerCity = pendingApplication.CoSignerCity,
                CoSignerState = pendingApplication.CoSignerState,
                CoSignerZipcode = pendingApplication.CoSignerZipcode,
                CoSignerPhone = pendingApplication.CoSignerPhone,
                CoSignerRelationShip = pendingApplication.CoSignerRelationShip,
                CoSignerEmailAddress = pendingApplication.CoSignerEmailAddress,
                OtherOccupant1Name = pendingApplication.OtherOccupant1Name,
                IsOccupant1Adult = pendingApplication.IsOccupant1Adult,
                RelationshipOccupant1ToApplicant = pendingApplication.RelationshipOccupant1ToApplicant,
                OtherOccupant2Name = pendingApplication.OtherOccupant2Name,
                IsOccupant2Adult = pendingApplication.IsOccupant2Adult,
                RelationshipOccupant2ToApplicant = pendingApplication.RelationshipOccupant2ToApplicant,
                OtherOccupant3Name = pendingApplication.OtherOccupant3Name,
                IsOccupant3Adult = pendingApplication.IsOccupant3Adult,
                RelationshipOccupant3ToApplicant = pendingApplication.RelationshipOccupant3ToApplicant,
                OtherOccupant4Name = pendingApplication.OtherOccupant4Name,
                IsOccupant4Adult = pendingApplication.IsOccupant4Adult,
                RelationshipOccupant4ToApplicant = pendingApplication.RelationshipOccupant4ToApplicant,
                EmployerName = pendingApplication.EmployerName,
                Income = pendingApplication.Income,
                WorkStartDate = pendingApplication.WorkStartDate,
                WorkEndDate = pendingApplication.WorkEndDate,
                EmployerAddress = pendingApplication.EmployerAddress,
                EmployerCity = pendingApplication.EmployerCity,
                EmployerState = pendingApplication.EmployerState,
                EmployerZipcode = pendingApplication.EmployerZipcode,
                EmployerPhone = pendingApplication.EmployerPhone,
                EmployerFax = pendingApplication.EmployerFax,
                CurrentLandloard = pendingApplication.CurrentLandloard,
                CurrentLandLoardPhone = pendingApplication.CurrentLandLoardPhone,
                CurrentLandLoardFax = pendingApplication.CurrentLandLoardFax,
                CurrentAddress = pendingApplication.CurrentAddress,
                CurrentAddressCity = pendingApplication.CurrentAddressCity,
                CurrentAddressState = pendingApplication.CurrentAddressState,
                CurrentAddressZip = pendingApplication.CurrentAddressZip,
                Rent = pendingApplication.Rent,
                CurrentRentStartDate = pendingApplication.CurrentRentStartDate,
                CurrentRentEndDate = pendingApplication.CurrentRentEndDate,
                PreviousLandloard = pendingApplication.PreviousLandloard,
                PreviousLandLoardPhone = pendingApplication.PreviousLandLoardPhone,
                PreviousLandLoardFax = pendingApplication.PreviousLandLoardFax,
                PreviousAddress = pendingApplication.PreviousAddress,
                PreviousAddressCity = pendingApplication.PreviousAddressCity,
                PreviousAddressState = pendingApplication.PreviousAddressState,
                PreviousAddressZip = pendingApplication.PreviousAddressZip,
                PreviousRent = pendingApplication.PreviousRent,
                PreviousRentStartDate = pendingApplication.PreviousRentStartDate,
                PreviousRentEndDate = pendingApplication.PreviousRentEndDate,
                EmergencyContactName = pendingApplication.EmergencyContactName,
                EmergencyContactRelationShip = pendingApplication.EmergencyContactRelationShip,
                EmergencyContactPhone = pendingApplication.EmergencyContactPhone,
                EmergencyContactAddress = pendingApplication.EmergencyContactAddress,
                EmergencyContactCity = pendingApplication.EmergencyContactCity,
                EmergencyContactState = pendingApplication.EmergencyContactState,
                EmergencyContactZipCode = pendingApplication.EmergencyContactZipCode,
                Pets = pendingApplication.Pets,
                PetsNumber = pendingApplication.PetsNumber,
                Pet1Brand = pendingApplication.Pet1Brand,
                Pet1Age = pendingApplication.Pet1Age,
                Pet1Weight = pendingApplication.Pet1Weight,
                Pet2Brand = pendingApplication.Pet2Brand,
                Pet2Age = pendingApplication.Pet2Age,
                Pet2Weight = pendingApplication.Pet2Weight,
                Vehicle1Make = pendingApplication.Vehicle1Make,
                Vehicle1Model = pendingApplication.Vehicle1Model,
                Vehicle1Year = pendingApplication.Vehicle1Year,
                Vehicle1Color = pendingApplication.Vehicle1Color,
                Vehicle1LicensePlate = pendingApplication.Vehicle1LicensePlate,
                Vehicle2Make = pendingApplication.Vehicle2Make,
                Vehicle2Model = pendingApplication.Vehicle2Model,
                Vehicle2Year = pendingApplication.Vehicle2Year,
                Vehicle2Color = pendingApplication.Vehicle2Color,
                Vehicle2LicensePlate = pendingApplication.Vehicle2LicensePlate,
                Vehicle3Make = pendingApplication.Vehicle3Make,
                Vehicle3Model = pendingApplication.Vehicle3Model,
                Vehicle3Year = pendingApplication.Vehicle3Year,
                Vehicle3Color = pendingApplication.Vehicle3Color,
                Vehicle3LicensePlate = pendingApplication.Vehicle3LicensePlate,
                Vehicle4Make = pendingApplication.Vehicle4Make,
                Vehicle4Model = pendingApplication.Vehicle4Model,
                Vehicle4Year = pendingApplication.Vehicle4Year,
                Vehicle4Color = pendingApplication.Vehicle4Color,
                Vehicle4LicensePlate = pendingApplication.Vehicle4LicensePlate,
                Bankruptcy = pendingApplication.Bankruptcy,
                LeaseDefaulted = pendingApplication.LeaseDefaulted,
                RefusedtoPayRent = pendingApplication.RefusedtoPayRent,
                EvictedFromRental = pendingApplication.EvictedFromRental,
                ConvictedofFelony = pendingApplication.ConvictedofFelony,
                TenantId = pendingApplication.TenantId,
                OwnerId = pendingApplication.OwnerId
            };
            UnitofWork.OwnerRejectedApplicationRepository.Add(rejectedapplication);
            UnitofWork.OwnerPendingApplicationRepository.Delete(pendingApplication);
            UnitofWork.Save();
        }

        public List<OwnerAcceptedApplication> GetOwnerAcceptedApplication()
        {
            var ownerId = GetOwner().OwnerId;
            return UnitofWork.OwnerAcceptedApplicationRepository.
                FindBy(x => x.OwnerId == ownerId).ToList();
        }

        public List<OwnerRejectedApplication> GetOwnerRejectedApplication()
        {
            var ownerId = GetOwner().OwnerId;
            return UnitofWork.OwnerRejectedApplicationRepository.
                FindBy(x => x.OwnerId == ownerId).ToList();
        }

        #endregion

        #region Contract

        public List<GeneratedRentalContract> GetOwnerGeneratedRentalContract()
        {
             var ownerId = GetOwner().OwnerId;
            var ownercontractcount = UnitofWork.GeneratedRentalContractRepository.
                FindBy(x => x.LandLoradID == ownerId).ToList();
            return ownercontractcount.Any() ? ownercontractcount.ToList() : null;
        }

        public List<UploadedContract> GetUploadedOwnerRentalContract()
        {
            var ownerId = GetOwner().OwnerId;
            var uploadedOwnercontractcount = UnitofWork.UploadedContractRepository.
                   FindBy(x => x.UploaderId == ownerId
                   && x.UploaderRole == "Owner").ToList();
            return uploadedOwnercontractcount.Any() ? uploadedOwnercontractcount.ToList() : null;
        }

        #endregion

        #region Showing

        public IQueryable<OwnerPendingShowingCalendarModelView> GetOwnerPendingShowingCalendar()
        {
            var ownerId = GetOwner().OwnerId;
            var showingrequest = (from opsc in
                                      UnitofWork.OwnerPendingShowingCalendarRepository.
                                      FindBy(x => x.OwnerId == ownerId)
                                  join unit in UnitofWork.UnitRepository.All
                                      on opsc.UnitId equals unit.UnitId
                                  select new OwnerPendingShowingCalendarModelView
                                  {
                                      Unit = unit,
                                      OwnerPendingShowingCalendar = opsc
                                  }).AsQueryable();

            return showingrequest;
        }

        public void OwnerDenyShowingRequest(int eventId)
        {
            var pendingrequest = UnitofWork.OwnerPendingShowingCalendarRepository.FirstOrDefault(x => x.EventID == eventId);
            if (pendingrequest != null)
            {
                UnitofWork.OwnerPendingShowingCalendarRepository.Delete(pendingrequest);
                UnitofWork.Save();
            }
        }


        public void OwnerAcceptShowingRequest(int eventId)
        {
            var pendingrequest = UnitofWork.OwnerPendingShowingCalendarRepository.FirstOrDefault(x => x.EventID == eventId);
            if (pendingrequest != null)
            {
                var newownershowingcalender = new OwnerShowingCalendar
                {
                    EventTitle = GetOwner().FirstName + " " + GetOwner().LastName + " has confirmed the scheduling",
                    StartDate = pendingrequest.StartDate,
                    EndDate = pendingrequest.EndDate,
                    IsAllDay = pendingrequest.IsAllDay,
                    OwnerId = pendingrequest.OwnerId,
                    UnitId = pendingrequest.UnitId,
                    RequesterEmail = pendingrequest.RequesterEmail,
                    RequesterName = pendingrequest.RequesterName,
                    RequesterTelephone = pendingrequest.RequesterTelephone

                };
                UnitofWork.OwnerShowingCalendarRepository.Add(newownershowingcalender);
                UnitofWork.OwnerPendingShowingCalendarRepository.Delete(pendingrequest);
                UnitofWork.Save();
            }
            //TODO Insert into OwnerShowingCalendars
            //TODO Send Email Confirmation to both parties

        }

        public JsonResult GetOwnerCalendar()
        {
            var ownerId = GetOwner().OwnerId;
            var calendar = from e in UnitofWork.OwnerShowingCalendarRepository
                                .FindBy(x => x.OwnerId == ownerId)
                           select e;
            var calendarList = calendar.ToArray();
            var eventList = from e in calendarList
                            let startDate = e.StartDate
                            where startDate != null
                            let endDate = e.EndDate
                            where endDate != null
                            select new
                            {
                                id = e.EventID,
                                title = e.EventTitle,
                                start = startDate.Value.ToUnixTimestamp(),
                                end = endDate.Value.ToUnixTimestamp(),
                                allDay = e.IsAllDay
                            };

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region TODO
        //TODO
        //ONCE YOU IMPLEMENTED, UNCOMMENT FOR IOwnerPrivateProfileHelper

        #region RSS

        //TODO CHANGE 2 to OwnerId

        /// <summary>
        /// RSS FEED WITH RSS AND ATOM CONFIGURED
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public FileResult Syndicate(string format)
        {

            var feed = new SyndicationFeed("Compiled Experience", "Silverlight Development",
                                           new Uri("http://compiledexperience.com"));
            var ownerId = GetOwner().OwnerId;
            var calendar = from e in UnitofWork.OwnerShowingCalendarRepository
                          .FindBy(x => x.OwnerId == ownerId)
                           where (e.OwnerId == ownerId)
                           select e;
            var calendarList = calendar.ToArray();
            var eventList = from e in calendarList
                            let startDate = e.StartDate
                            where startDate != null
                            let endDate = e.EndDate
                            where endDate != null
                            select
                            new SyndicationItem
                                (
                                e.EventID.ToString(CultureInfo.InvariantCulture),
                                e.EventTitle,
                                new Uri(String.Format("/blog/posts/{0}", e.EventTitle),
                                    UriKind.Relative));

            feed.Items = eventList.ToList();

            if (format.Equals("rss", StringComparison.InvariantCultureIgnoreCase))

                return new FeedResult(feed, FeedResult.FeedType.Rss);

            //You need to return Atom Syndicator
            return new FeedResult(feed, FeedResult.FeedType.Atom);

            //return new Rss20FeedFormater(feed);
            //http://localhost:56224/Owner/Syndicate/?format=rss
        }
        #endregion

        #region Project
        //Still in Design Phase
        #endregion

        #region Picture

        //TODO TO COMPLETE AND VERIFY: IT DOESN"T FOLLOW THE STANADRDS
        public void SaveUnitPictures(Model.Models.Unit unit)
        {
            var imageStoragePath = HttpContext.Server.MapPath("~/UploadedImages");
            //var photoPath = Server.MapPath(OwnerPropertyPhotoPath);
            var directory = @"\" + UserHelper.UserIdentity.GetUserName() + @"\" + "Property" + @"\" + TempData["UserID"] + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);
            var newdirectory = OwnerPropertyPhotoPath + directory;
            if (!Directory.Exists(path))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(path);
            }
            var files = uploadDirectory.GetFiles();
            directory = @"\" + UserHelper.UserIdentity.GetUserName() + @"\" + TempData["UserID"] + @"\";
            if (!Directory.Exists(path))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(newdirectory);
            }
            int counter = 0;
            var virtualdestinationdirectoryvirtualmapping = HttpContext.Server.MapPath("~/Photo");
            virtualdestinationdirectoryvirtualmapping += @"\Owner\Property" + directory;
            if (!Directory.Exists(virtualdestinationdirectoryvirtualmapping))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(virtualdestinationdirectoryvirtualmapping);
            }

            foreach (var f in files)
            {
                //TO COMPLETE
                virtualdestinationdirectoryvirtualmapping += f.Name;
                //TO COMPLETE
                if (!System.IO.File.Exists(virtualdestinationdirectoryvirtualmapping))
                {
                    //sSystem.IO.File.Move(f.FullName, destinationFile);
                    System.IO.File.Move(f.FullName, virtualdestinationdirectoryvirtualmapping);
                    AddUnitGalleryPicture(unit, Convert.ToInt32(TempData["UserID"]), virtualdestinationdirectoryvirtualmapping,
                               counter);
                    counter++;
                }
                if (System.IO.File.Exists(f.Name))
                    System.IO.File.Delete(f.Name);
            }
            new DirectoryHelper().DeleteDirectoryIfExist(path);
            AddUnitGalleryPictureorDefaultUnitPicture(unit, files, newdirectory, virtualdestinationdirectoryvirtualmapping, directory);
        }

        public void AddUnitGalleryPictureorDefaultUnitPicture(Model.Models.Unit unit, FileInfo[] files, string newdirectory,
                                 string virtualdestinationdirectoryvirtualmapping, string directory)
        {
            if (!files.Any()) return;
            var defaultpropertyphoto = HttpContext.Server.MapPath("~/UploadedImages/Default/Property/coming_soon.png");
            var defaultpropertyphotodestination = newdirectory + @"\" + "coming_soon.png";
            var defaultvirtualpropertyphotodestination = virtualdestinationdirectoryvirtualmapping + @"\Owner\Property" +
                                                         directory + "coming_soon.png";
            System.IO.File.Copy(defaultpropertyphoto, defaultpropertyphotodestination);
            AddUnitGalleryPicture(unit, Convert.ToInt32(TempData["UserID"]), defaultvirtualpropertyphotodestination, 0);
        }

        public void AddUnitGalleryPicture(Model.Models.Unit unit, int uploaderid, string photoPath, int rank)
        {
            var unitgallery = new UnitGallery
            {
                Path = photoPath,
                Caption = "",
                Rank = rank,
                Unit = unit
            };
            if (!ModelState.IsValid) return;
            UnitofWork.UnitGalleryRepository.Add(unitgallery);
            UnitofWork.Save();
        }

        #endregion

        #region Contract

        //Not Used Yet
        public void AddOwnerContractPictures(string key)
        {
            var imageStoragePath = HttpContext.Server.MapPath("~/UploadedImages");
            var photoPath = HttpContext.Server.MapPath(OwnerContractUploadPath);
            var directory = @"\" + OwnerUsername() + @"\" + "UploadedContract" + @"\" + TempData[key] + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);
            var newdirectory = photoPath + directory;
            if (Directory.Exists(path))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(newdirectory);
            }
            var files = uploadDirectory.GetFiles();
            foreach (var f in files)
            {
                var destinationFile = newdirectory + @"\" + f.Name;
                var virtualdestinationFile = OwnerContractUploadPath + directory + f.Name;
                if (!System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Move(f.FullName, destinationFile);
                    AddContractPhotoByOwner(Convert.ToInt32(TempData[key]), virtualdestinationFile);
                }
                if (System.IO.File.Exists(f.Name))
                    System.IO.File.Delete(f.Name);
            }
            new DirectoryHelper().DeleteDirectoryIfExist(path);
        }

        public void AddContractPhotoByOwner(int uploaderid, string photoPath)
        {
            var uploadedcontractphoto = new UploadedContract
            {
                UploadedImagePath = photoPath,
                UploaderId = uploaderid,
                UploaderRole = "Owner"
            };
            if (!ModelState.IsValid) return;
            UnitofWork.UploadedContractRepository.Add(uploadedcontractphoto);
            UnitofWork.Save();
        }

        #endregion

        #endregion

    }


    #region DateHelper Extension
    public static class DateExtension
    {
        public static long ToUnixTimestamp(this DateTime target)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            var unixTimestamp = Convert.ToInt64((target - date).TotalSeconds);

            return unixTimestamp;
        }

        public static DateTime ToDateTime(this DateTime target, long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);

            return dateTime.AddSeconds(timestamp);
        }
    }
    #endregion

}