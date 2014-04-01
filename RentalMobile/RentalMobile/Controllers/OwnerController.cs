using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.ModelViews;
using RentalMobile.Models;
using Email = Postal.Email;

namespace RentalMobile.Controllers
{
    public class OwnerController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();
        private static bool _confirmationRequest;

        // GET: /Owner/

        public ViewResult Index()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }

        // GET: /Owner/Edit/5

        public ActionResult Edit(int id)
        {
            Owner owner = db.Owners.Find(id);
            return View(owner);
        }

        //
        // POST: /Owner/Edit/5

        [HttpPost]
        public ActionResult Edit(Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(owner);
        }


        // GET: /Owner/ChangeAddress/5

        public ActionResult ChangeAddress(int id)
        {
            Owner owner = db.Owners.Find(id);
            return View(owner);
        }

        //
        // POST: /Owner/ChangeAddress/5

        [HttpPost]
        public ActionResult ChangeAddress(Owner Owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Owner).State = EntityState.Modified;
                Owner.GoogleMap = string.IsNullOrEmpty(Owner.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(Owner.Address, Owner.City, Owner.CountryCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Owner);
        }

        // GET: /Owner/Delete/5

        public ActionResult Delete(int id)
        {
            Owner owner = db.Owners.Find(id);
            return View(owner);
        }

        //
        // POST: /Owner/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner owner = db.Owners.Find(id);
            db.Owners.Remove(owner);
            db.SaveChanges();


            //// Delete All associated records

            //var Ownershowing = db.OwnerShowings.Where(x => x.OwnerId == id).ToList();
            //foreach (var x in Ownershowing)
            //{
            //    db.OwnerShowings.Remove(x);
            //}
            //db.SaveChanges();




            //Delete from Membership

            if (Roles.GetRolesForUser(User.Identity.Name).Any())
            {
                Roles.RemoveUserFromRoles(User.Identity.Name, Roles.GetRolesForUser(User.Identity.Name));
            }
            Membership.DeleteUser(User.Identity.Name);
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload", "Account", new { id });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }







        //Handling the application
        //Should be the same for Agent

        public ActionResult PendingApplication()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());

            return View(db.OwnerPendingApplications.Where(x => x.OwnerId == owner.OwnerId).ToList());
        }

        public ActionResult AcceptApplication(int id)
        {
            var pa = db.OwnerPendingApplications.Find(id);
            if (pa != null)
            {
                var approvedapplication = new OwnerAcceptedApplication
                    {
                        FirstName = pa.FirstName,
                        LastName = pa.LastName,
                        MiddleName = pa.MiddleName,
                        SocialSecurityNumber = pa.SocialSecurityNumber,
                        DriverLicense = pa.DriverLicense,
                        Phone = pa.Phone,
                        CellPhone = pa.CellPhone,
                        EmailAddress = pa.EmailAddress,
                        CoSignerName = pa.CoSignerName,
                        CoSignerAddress = pa.CoSignerAddress,
                        CoSignerCity = pa.CoSignerCity,
                        CoSignerState = pa.CoSignerState,
                        CoSignerZipcode = pa.CoSignerZipcode,
                        CoSignerPhone = pa.CoSignerPhone,
                        CoSignerRelationShip = pa.CoSignerRelationShip,
                        CoSignerEmailAddress = pa.CoSignerEmailAddress,
                        OtherOccupant1Name = pa.OtherOccupant1Name,
                        IsOccupant1Adult = pa.IsOccupant1Adult,
                        RelationshipOccupant1ToApplicant = pa.RelationshipOccupant1ToApplicant,
                        OtherOccupant2Name = pa.OtherOccupant2Name,
                        IsOccupant2Adult = pa.IsOccupant2Adult,
                        RelationshipOccupant2ToApplicant = pa.RelationshipOccupant2ToApplicant,
                        OtherOccupant3Name = pa.OtherOccupant3Name,
                        IsOccupant3Adult = pa.IsOccupant3Adult,
                        RelationshipOccupant3ToApplicant = pa.RelationshipOccupant3ToApplicant,
                        OtherOccupant4Name = pa.OtherOccupant4Name,
                        IsOccupant4Adult = pa.IsOccupant4Adult,
                        RelationshipOccupant4ToApplicant = pa.RelationshipOccupant4ToApplicant,
                        EmployerName = pa.EmployerName,
                        Income = pa.Income,
                        WorkStartDate = pa.WorkStartDate,
                        WorkEndDate = pa.WorkEndDate,
                        EmployerAddress = pa.EmployerAddress,
                        EmployerCity = pa.EmployerCity,
                        EmployerState = pa.EmployerState,
                        EmployerZipcode = pa.EmployerZipcode,
                        EmployerPhone = pa.EmployerPhone,
                        EmployerFax = pa.EmployerFax,
                        CurrentLandloard = pa.CurrentLandloard,
                        CurrentLandLoardPhone = pa.CurrentLandLoardPhone,
                        CurrentLandLoardFax = pa.CurrentLandLoardFax,
                        CurrentAddress = pa.CurrentAddress,
                        CurrentAddressCity = pa.CurrentAddressCity,
                        CurrentAddressState = pa.CurrentAddressState,
                        CurrentAddressZip = pa.CurrentAddressZip,
                        Rent = pa.Rent,
                        CurrentRentStartDate = pa.CurrentRentStartDate,
                        CurrentRentEndDate = pa.CurrentRentEndDate,
                        PreviousLandloard = pa.PreviousLandloard,
                        PreviousLandLoardPhone = pa.PreviousLandLoardPhone,
                        PreviousLandLoardFax = pa.PreviousLandLoardFax,
                        PreviousAddress = pa.PreviousAddress,
                        PreviousAddressCity = pa.PreviousAddressCity,
                        PreviousAddressState = pa.PreviousAddressState,
                        PreviousAddressZip = pa.PreviousAddressZip,
                        PreviousRent = pa.PreviousRent,
                        PreviousRentStartDate = pa.PreviousRentStartDate,
                        PreviousRentEndDate = pa.PreviousRentEndDate,
                        EmergencyContactName = pa.EmergencyContactName,
                        EmergencyContactRelationShip = pa.EmergencyContactRelationShip,
                        EmergencyContactPhone = pa.EmergencyContactPhone,
                        EmergencyContactAddress = pa.EmergencyContactAddress,
                        EmergencyContactCity = pa.EmergencyContactCity,
                        EmergencyContactState = pa.EmergencyContactState,
                        EmergencyContactZipCode = pa.EmergencyContactZipCode,
                        Pets = pa.Pets,
                        PetsNumber = pa.PetsNumber,
                        Pet1Brand = pa.Pet1Brand,
                        Pet1Age = pa.Pet1Age,
                        Pet1Weight = pa.Pet1Weight,
                        Pet2Brand = pa.Pet2Brand,
                        Pet2Age = pa.Pet2Age,
                        Pet2Weight = pa.Pet2Weight,
                        Vehicle1Make = pa.Vehicle1Make,
                        Vehicle1Model = pa.Vehicle1Model,
                        Vehicle1Year = pa.Vehicle1Year,
                        Vehicle1Color = pa.Vehicle1Color,
                        Vehicle1LicensePlate = pa.Vehicle1LicensePlate,
                        Vehicle2Make = pa.Vehicle2Make,
                        Vehicle2Model = pa.Vehicle2Model,
                        Vehicle2Year = pa.Vehicle2Year,
                        Vehicle2Color = pa.Vehicle2Color,
                        Vehicle2LicensePlate = pa.Vehicle2LicensePlate,
                        Vehicle3Make = pa.Vehicle3Make,
                        Vehicle3Model = pa.Vehicle3Model,
                        Vehicle3Year = pa.Vehicle3Year,
                        Vehicle3Color = pa.Vehicle3Color,
                        Vehicle3LicensePlate = pa.Vehicle3LicensePlate,
                        Vehicle4Make = pa.Vehicle4Make,
                        Vehicle4Model = pa.Vehicle4Model,
                        Vehicle4Year = pa.Vehicle4Year,
                        Vehicle4Color = pa.Vehicle4Color,
                        Vehicle4LicensePlate = pa.Vehicle4LicensePlate,
                        Bankruptcy = pa.Bankruptcy,
                        LeaseDefaulted = pa.LeaseDefaulted,
                        RefusedtoPayRent = pa.RefusedtoPayRent,
                        EvictedFromRental = pa.EvictedFromRental,
                        ConvictedofFelony = pa.ConvictedofFelony,
                        TenantId = pa.TenantId,
                        OwnerId = pa.OwnerId
                    };

                db.OwnerAcceptedApplications.Add(approvedapplication);
                db.OwnerPendingApplications.Remove(pa);
                db.SaveChanges();
            }
            return RedirectToAction("PendingApplication");
        }

        public ActionResult AcceptedApplication()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());

            return View(db.OwnerAcceptedApplications.Where(x => x.OwnerId == owner.OwnerId).ToList());
        }

        public ActionResult RejectApplication(int id)
        {
            var pa = db.OwnerPendingApplications.Find(id);
            if (pa != null)
            {
                var rejectedapplication = new OwnerRejectedApplication
                {
                    FirstName = pa.FirstName,
                    LastName = pa.LastName,
                    MiddleName = pa.MiddleName,
                    SocialSecurityNumber = pa.SocialSecurityNumber,
                    DriverLicense = pa.DriverLicense,
                    Phone = pa.Phone,
                    CellPhone = pa.CellPhone,
                    EmailAddress = pa.EmailAddress,
                    CoSignerName = pa.CoSignerName,
                    CoSignerAddress = pa.CoSignerAddress,
                    CoSignerCity = pa.CoSignerCity,
                    CoSignerState = pa.CoSignerState,
                    CoSignerZipcode = pa.CoSignerZipcode,
                    CoSignerPhone = pa.CoSignerPhone,
                    CoSignerRelationShip = pa.CoSignerRelationShip,
                    CoSignerEmailAddress = pa.CoSignerEmailAddress,
                    OtherOccupant1Name = pa.OtherOccupant1Name,
                    IsOccupant1Adult = pa.IsOccupant1Adult,
                    RelationshipOccupant1ToApplicant = pa.RelationshipOccupant1ToApplicant,
                    OtherOccupant2Name = pa.OtherOccupant2Name,
                    IsOccupant2Adult = pa.IsOccupant2Adult,
                    RelationshipOccupant2ToApplicant = pa.RelationshipOccupant2ToApplicant,
                    OtherOccupant3Name = pa.OtherOccupant3Name,
                    IsOccupant3Adult = pa.IsOccupant3Adult,
                    RelationshipOccupant3ToApplicant = pa.RelationshipOccupant3ToApplicant,
                    OtherOccupant4Name = pa.OtherOccupant4Name,
                    IsOccupant4Adult = pa.IsOccupant4Adult,
                    RelationshipOccupant4ToApplicant = pa.RelationshipOccupant4ToApplicant,
                    EmployerName = pa.EmployerName,
                    Income = pa.Income,
                    WorkStartDate = pa.WorkStartDate,
                    WorkEndDate = pa.WorkEndDate,
                    EmployerAddress = pa.EmployerAddress,
                    EmployerCity = pa.EmployerCity,
                    EmployerState = pa.EmployerState,
                    EmployerZipcode = pa.EmployerZipcode,
                    EmployerPhone = pa.EmployerPhone,
                    EmployerFax = pa.EmployerFax,
                    CurrentLandloard = pa.CurrentLandloard,
                    CurrentLandLoardPhone = pa.CurrentLandLoardPhone,
                    CurrentLandLoardFax = pa.CurrentLandLoardFax,
                    CurrentAddress = pa.CurrentAddress,
                    CurrentAddressCity = pa.CurrentAddressCity,
                    CurrentAddressState = pa.CurrentAddressState,
                    CurrentAddressZip = pa.CurrentAddressZip,
                    Rent = pa.Rent,
                    CurrentRentStartDate = pa.CurrentRentStartDate,
                    CurrentRentEndDate = pa.CurrentRentEndDate,
                    PreviousLandloard = pa.PreviousLandloard,
                    PreviousLandLoardPhone = pa.PreviousLandLoardPhone,
                    PreviousLandLoardFax = pa.PreviousLandLoardFax,
                    PreviousAddress = pa.PreviousAddress,
                    PreviousAddressCity = pa.PreviousAddressCity,
                    PreviousAddressState = pa.PreviousAddressState,
                    PreviousAddressZip = pa.PreviousAddressZip,
                    PreviousRent = pa.PreviousRent,
                    PreviousRentStartDate = pa.PreviousRentStartDate,
                    PreviousRentEndDate = pa.PreviousRentEndDate,
                    EmergencyContactName = pa.EmergencyContactName,
                    EmergencyContactRelationShip = pa.EmergencyContactRelationShip,
                    EmergencyContactPhone = pa.EmergencyContactPhone,
                    EmergencyContactAddress = pa.EmergencyContactAddress,
                    EmergencyContactCity = pa.EmergencyContactCity,
                    EmergencyContactState = pa.EmergencyContactState,
                    EmergencyContactZipCode = pa.EmergencyContactZipCode,
                    Pets = pa.Pets,
                    PetsNumber = pa.PetsNumber,
                    Pet1Brand = pa.Pet1Brand,
                    Pet1Age = pa.Pet1Age,
                    Pet1Weight = pa.Pet1Weight,
                    Pet2Brand = pa.Pet2Brand,
                    Pet2Age = pa.Pet2Age,
                    Pet2Weight = pa.Pet2Weight,
                    Vehicle1Make = pa.Vehicle1Make,
                    Vehicle1Model = pa.Vehicle1Model,
                    Vehicle1Year = pa.Vehicle1Year,
                    Vehicle1Color = pa.Vehicle1Color,
                    Vehicle1LicensePlate = pa.Vehicle1LicensePlate,
                    Vehicle2Make = pa.Vehicle2Make,
                    Vehicle2Model = pa.Vehicle2Model,
                    Vehicle2Year = pa.Vehicle2Year,
                    Vehicle2Color = pa.Vehicle2Color,
                    Vehicle2LicensePlate = pa.Vehicle2LicensePlate,
                    Vehicle3Make = pa.Vehicle3Make,
                    Vehicle3Model = pa.Vehicle3Model,
                    Vehicle3Year = pa.Vehicle3Year,
                    Vehicle3Color = pa.Vehicle3Color,
                    Vehicle3LicensePlate = pa.Vehicle3LicensePlate,
                    Vehicle4Make = pa.Vehicle4Make,
                    Vehicle4Model = pa.Vehicle4Model,
                    Vehicle4Year = pa.Vehicle4Year,
                    Vehicle4Color = pa.Vehicle4Color,
                    Vehicle4LicensePlate = pa.Vehicle4LicensePlate,
                    Bankruptcy = pa.Bankruptcy,
                    LeaseDefaulted = pa.LeaseDefaulted,
                    RefusedtoPayRent = pa.RefusedtoPayRent,
                    EvictedFromRental = pa.EvictedFromRental,
                    ConvictedofFelony = pa.ConvictedofFelony,
                    TenantId = pa.TenantId,
                    OwnerId = pa.OwnerId
                };

                db.OwnerRejectedApplications.Add(rejectedapplication);
                db.OwnerPendingApplications.Remove(pa);
                db.SaveChanges();
            }
            return RedirectToAction("PendingApplication");
        }

        public ActionResult RejectedApplication()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());

            return View(db.OwnerRejectedApplications.Where(x => x.OwnerId == owner.OwnerId).ToList());
        }


        //










        //same as index to get the same look and fell
        public ViewResult GeneratedContract()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);

        }

        public ViewResult GeneratedRentalAgreement()
        {
            if (UserHelper.GetOwnerId() != null)
            {
                var id = UserHelper.GetOwnerId();
                if (id != null)
                {
                    var ownerId = (int)id;

                    var result = db.GeneratedRentalContracts.Count(x => x.LandLoradID == ownerId);
                    if (result != 0)
                    {
                        return View(db.GeneratedRentalContracts.Where(x => x.LandLoradID == UserHelper.GetOwnerId()).ToList());
                    }
                }
            }

            return db.GeneratedRentalContracts != null ? View(db.GeneratedRentalContracts.ToList()) : null;
        }




        public ViewResult UploadedAgreement()
        {
            if (UserHelper.GetOwnerId() != null)
            {
                var id = UserHelper.GetOwnerId();
                if (id != null)
                {
                    var ownerId = (int)id;

                    var result = db.UploadedContracts.Count(x => x.UploaderId == ownerId && x.UploaderRole == "Owner");
                    if (result != 0)
                    {
                        return
                            View(db.UploadedContracts.Where(x => x.UploaderId == ownerId && x.UploaderRole == "Owner").ToList());
                    }
                }
            }

            return db.GeneratedRentalContracts != null ? View(db.UploadedContracts.ToList()) : null;
        }























        public ActionResult ShowingSchedule()
        {
            return View();
        }




        public ActionResult NewShowingRequest( bool? requestshowing)
        {

            if (requestshowing == true)
            {
                ViewBag.ConfirmationRequest = true;
                ViewBag.ConfirmationScript = JNotifyConfirmationSharingEmail();
            }
            var owner = UserHelper.GetOwnerId();
            if (owner != null)
            {
                var ownerId = (int)owner;
                var showingrequest = (from opsc in db.OwnerPendingShowingCalendars.Where(x => x.OwnerId == ownerId)
                                      join unit in db.Units
                                          on opsc.UnitId equals unit.UnitId
                                      select new OwnerPendingShowingCalendarModelView
                                          {
                                              Unit = unit,
                                              OwnerPendingShowingCalendar = opsc
                                          }).AsQueryable();

                return View(showingrequest);
            }

            return null;
        }


        public ActionResult ShowingRequestDeny(int id)
        {
            var pendingrequest = db.OwnerPendingShowingCalendars.FirstOrDefault(x => x.EventID == id);
            if (pendingrequest != null)
            {
                db.OwnerPendingShowingCalendars.Remove(pendingrequest);
                db.SaveChanges();
            }



            return RedirectToAction("NewShowingRequest");
        }




        public ActionResult ShowingRequestConfirm(int id)
        {

            
//            Insert into OwnerShowingCalendars

            var pendingrequest = db.OwnerPendingShowingCalendars.FirstOrDefault(x => x.EventID == id) ;
            if (pendingrequest != null)
            {
                var newownershowingcalender = new OwnerShowingCalendar
                                                  {
                                                      EventTitle = "Owner X has confirmed the scheduling",
                                                      StartDate = pendingrequest.StartDate,
                                                      EndDate = pendingrequest.EndDate,
                                                      IsAllDay = pendingrequest.IsAllDay,
                                                      OwnerId = pendingrequest.OwnerId,
                                                      UnitId = pendingrequest.UnitId,
                                                      RequesterEmail = pendingrequest.RequesterEmail,
                                                      RequesterName = pendingrequest.RequesterName,
                                                      RequesterTelephone = pendingrequest.RequesterTelephone

                                                  };
                db.OwnerShowingCalendars.Add(newownershowingcalender);
                db.OwnerPendingShowingCalendars.Remove(pendingrequest);
                db.SaveChanges();
            }


            //Send Email Confirmation to both parties

            return RedirectToAction("NewShowingRequest", new { id, requestshowing = true });
        }



        public string JNotifyConfirmationSharingEmail()
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your appointement confirmation was successful.")
                                            +
                                            @"',{
	                        autoHide : true, // added in v2.0
	  	                        clickOverlay : false, // added in v2.0
	  	                        MinWidth : 300,
	  	                        TimeShown : 3000,
	  	                        ShowTimeEffect : 200,
	  	                        HideTimeEffect : 200,
	  	                        LongTrip :10,
	  	                        HorizontalPosition : 'center',
	  	                        VerticalPosition : 'center',
	  	                        ShowOverlay : true,
  		  	                        ColorOverlay : '#000',
	  	                        OpacityOverlay : 0.3,
	  	                        onClosed : function(){ // added in v2.0
	   
	  	                        },
	  	                         onCompleted : function(){ // added in v2.0
	  	                        

	   
	  	                }
		             });

";
            return jNotifyConfirmationScript;
        }






        public JsonResult GetOwnerCalendar()
        {
            var owner = UserHelper.GetOwnerId();
            if (owner != null)
            {
                var ownerId = (int) owner;

                var calendar = from e in db.OwnerShowingCalendars
                               where (e.OwnerId == ownerId)
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
                                               allDay = e.IsAllDay,
                                           };

                var rows = eventList.ToArray();
                return Json(rows, JsonRequestBehavior.AllowGet);
                
            }
            return null;
        }












        /// <summary>
        /// RSS FEED WITH RSS AND ATOM CONFIGURED
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public FileResult Syndicate(string format)
        {

            var feed = new SyndicationFeed("Compiled Experience", "Silverlight Development",
                                           new Uri("http://compiledexperience.com"));

            var calendar = from e in db.OwnerShowingCalendars
                           where (e.OwnerId == 2)
                           select e;
            var calendarList = calendar.ToArray();
            var eventList = from e in calendarList
                            let startDate = e.StartDate
                            where startDate != null
                            let endDate = e.EndDate
                            where endDate != null
                            select new SyndicationItem(e.EventID.ToString(CultureInfo.InvariantCulture), e.EventTitle, new Uri(String.Format("/blog/posts/{0}", e.EventTitle), UriKind.Relative));


            feed.Items = eventList.ToList();




            if (format.Equals("rss", StringComparison.InvariantCultureIgnoreCase))

                return new FeedResult(feed, FeedResult.FeedType.Rss);



            //You need to return Atom Syndicator
            return new FeedResult(feed, FeedResult.FeedType.Atom);

            //   return new Rss20FeedFormater(feed);




            //    http://localhost:56224/Owner/Syndicate/?format=rss
        }



















        //Project
        public ActionResult ActiveProject()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }


        public ActionResult ViewActiveProject()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }

















        public ActionResult NewProject()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }

        public ActionResult CreateNewProject()
        {
            return View();
        }


















        public ActionResult SavedProject()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }



        public ActionResult EditSavedProject()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }

               public ActionResult DeleteSavedProject()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }












        public ActionResult ArchivedProject()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerId());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }

        public ActionResult ViewArchivedProject()
        {
            return View();
        }
        public ActionResult ViewArchivedProject(int id)
        {
            return View();
        }

        public ActionResult DeleteArchivedProject()
        {
            return View();
        }
        //public ActionResult DeleteArchivedProject(int id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult DeleteArchivedProject(int id)
        //{
        //    return View();
        //}

















        [HttpPost]
        public ActionResult NewProject(UnitModelView u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Units.Add(u.Unit);
                    db.UnitPricings.Add(u.UnitPricing);
                    db.UnitFeatures.Add(u.UnitFeature);
                    db.UnitCommunityAmenities.Add(u.UnitCommunityAmenity);
                    db.UnitAppliances.Add(u.UnitAppliance);
                    db.UnitInteriorAmenities.Add(u.UnitInteriorAmenity);
                    db.UnitExteriorAmenities.Add(u.UnitExteriorAmenity);
                    db.UnitLuxuryAmenities.Add(u.UnitLuxuryAmenity);
                    ViewBag.CurrencyCode = u.Unit.CurrencyCode;
                    db.SaveChanges();
                  //  SavePictures(u.Unit);
                    return RedirectToAction("Index");
                }
                return View(u);
            }


            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                      eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                          ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }



        }


        public ActionResult ProjectPreview(int id, bool? shareproperty, bool? requestshowing)
        {
            var u = new UnitModelView
            {
                Unit = db.Units.Find(id),
                UnitFeature = db.UnitFeatures.Find(id),
                UnitAppliance = db.UnitAppliances.Find(id),
                UnitCommunityAmenity = db.UnitCommunityAmenities.Find(id),
                UnitPricing = db.UnitPricings.Find(id),
                UnitInteriorAmenity = db.UnitInteriorAmenities.Find(id),
                UnitExteriorAmenity = db.UnitExteriorAmenities.Find(id),
                UnitLuxuryAmenity = db.UnitLuxuryAmenities.Find(id)
            };

            if (Request.Url != null)
            {
                var url = Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture);
                var primaryimagethumbnail = UserHelper.ResolveImageUrl(u.Unit.PrimaryPhoto);
                string title;
                if (String.IsNullOrEmpty(u.Unit.Title))
                {
                    title = (u.Unit.Address + " , " + u.Unit.State + " , " + u.Unit.City);
                    if (title.Length >= 50)
                    {
                        title = title.Substring(0, 50);
                    }
                }
                else
                {
                    title = u.Unit.Title;
                    if (u.Unit.Title.Length >= 50)
                    {
                        title = u.Unit.Title.Substring(0, 50);
                    }
                }

                var summary = u.Unit.Description;
                if (!String.IsNullOrEmpty(summary))
                {
                    if (summary.Length >= 140)
                    {
                        summary = summary.Substring(0, 140);
                    }
                }

                var unitrentprice = u.UnitPricing.Rent == null
                                        ? ""
                                        : u.UnitPricing.Rent.Value.ToString(CultureInfo.InvariantCulture) + " ";
                unitrentprice += UserHelper.GetCurrencyValue(u.Unit.CurrencyCode);
                var tweet = u.Unit.Title + ": " + unitrentprice + "--" + url;
                if (!String.IsNullOrEmpty(tweet))
                {
                    if (tweet.Length >= 140)
                    {
                        tweet = tweet.Substring(0, 140);
                    }
                }

                const string sitename = "http://www.haithem-araissia.com";
                ViewBag.FaceBook = SocialHelper.FacebookShare(url, primaryimagethumbnail, title, summary);
                ViewBag.Twitter = SocialHelper.TwitterShare(tweet);
                ViewBag.GooglePlusShare = SocialHelper.GooglePlusShare(url);
                ViewBag.LinkedIn = SocialHelper.LinkedInShare(url, title, summary, sitename);
            }

            ViewBag.UnitGoogleMap = string.IsNullOrEmpty(u.Unit.Address)
                                        ? UserHelper.GetFormattedLocation("", "", "USA")
                                        : UserHelper.GetFormattedLocation(u.Unit.Address, u.Unit.City, "US");
            var poster = UserHelper.GetPoster(id) ?? UserHelper.DefaultPoster;
            ViewBag.PosterFirstName = poster.FirstName;
            ViewBag.PosterLastName = poster.LastName;
            ViewBag.PosterPictureProfile = poster.ProfilePicturePath;
            ViewBag.PosterProfileLink = poster.ProfileLink;


            if (shareproperty != null && shareproperty == true)
            {
                ViewBag.EmailSharedwithFriend = true;
                ViewBag.EmailSucessSharedwithFriend = JNotifyConfirmationSharingEmail();
            }

            return View(u);
        }


        public ActionResult ForwardtoFriend(string friendname, string friendemailaddress, string message, int id)
        {
            dynamic email = new Email("SendtoFriend/Multipart");
            var poster = UserHelper.GetPoster(id) ?? UserHelper.DefaultPoster;
            var currentunit = db.Units.Find(id);
            const string previewPathWithHost = @"/Unit/Preview";
            var unitPicture = currentunit.PrimaryPhoto;
            unitPicture = unitPicture.Replace("../../", "");


            //../../Photo/Owner/Property/carrie/2/img_walle - Copy.jpg

            // Assign any view data to pass to the view.
            // It's dynamic, so you can put whatever you want here.

            email.To = friendemailaddress;
            email.FriendName = friendname;
            email.From = "postmaster@haithem-araissia.com";
            email.SenderFirstName = poster.FirstName;
            email.Title = string.Format("Request From {0}", poster.FirstName);
            email.Message = message;
            var uri = Request.Url;
            if (uri != null)
            {
                var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                var unitUrl = host + previewPathWithHost + id;
                email.UnitUrl = unitUrl;

                string title;
                if (String.IsNullOrEmpty(currentunit.Title))
                {
                    title = (currentunit.Address + " , " + currentunit.State + " , " + currentunit.City);
                    if (title.Length >= 50)
                    {
                        title = title.Substring(0, 50);
                    }
                }
                else
                {
                    title = currentunit.Title;
                    if (currentunit.Title.Length >= 50)
                    {
                        title = currentunit.Title.Substring(0, 50);
                    }
                }

                email.UnitTitle = title;
                // email.UnitPath = "http://www.haithem-araissia.com/images/property/home12.jpg";
                email.UnitPath = host + "/" + unitPicture;
            }

            try
            {
                email.SendAsync();

            }
            catch (Exception e)
            {
                //Write To Database Error

                //Output Message
                throw;
            }

            //     return Content(string.Format("<script language='javascript' type='text/javascript'>{0}</script>", JNotifyConfirmation("Sharing Property")));



            // return Content(string.Format("<script language='javascript' type='text/javascript'>{0}</script>", "alert('dgdf'); return false;"));


            return RedirectToAction("ProjectPreview", new { id });


        }




        private readonly DB_33736_rentalEntities _db = new DB_33736_rentalEntities();

        //MAKE SURE THAT USER ARE AUTHENTICATED
        public string Username = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();
        //MAKE SURE THAT USER ARE AUTHENTICATED

        public string TenantPhotoPath = "~/Photo/Tenant/Property";
        public string OwnerPhotoPath = "~/Photo/Owner/Property";
        public string AgentPhotoPath = "~/Photo/Agent/Property";
        public string ProviderPhotoPath = "~/Photo/Provider/Property";
        public string SpecialistPhotoPath = "~/Photo/Specialist/Property";
        public string RequestId;
        public string PhotoPath;


        public ActionResult Partial2(UnitModelView unitModelView)
        {


            var role = GetCurrentRole();
            if (role == "Tenant")
            {
                ViewBag.Id = UserHelper.GetTenantId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetTenantId();
            }

            if (role == "Owner")
            {
                ViewBag.Id = UserHelper.GetOwnerId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetOwnerId();
            }

            if (role == "Agent")
            {
                ViewBag.Id = UserHelper.GetAgentId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetAgentId();
            }

            if (role == "Specialist")
            {
                ViewBag.Id = UserHelper.GetSpecialistId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetSpecialistId();
            }
            if (role == "Provider")
            {
                ViewBag.Id = UserHelper.GetProviderId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "Property";
                TempData["UserID"] = UserHelper.GetProviderId();
            }



            //RequestID = "5";
            //ViewBag.UserName = "Test";
            //ViewBag.Id = "10";
            //ViewBag.Type = "Requests";
            //TempData["Id"] = "5";

            // SavePictures(unitModelView.Unit);
            //ViewBag.Sript = FancyBox.Fancy(unitModelView.Unit.UnitId);
            return PartialView("_Partial2", unitModelView.UnitGallery);
        }

        public string GetCurrentRole()
        {
            var user = System.Web.HttpContext.Current.User;
            if (user.IsInRole("Tenant"))
            {
                PhotoPath = Server.MapPath(TenantPhotoPath);
                return "Tenant";
            }
            if (user.IsInRole("Owner"))
            {
                PhotoPath = Server.MapPath(OwnerPhotoPath);
                return "Owner";
            }
            if (user.IsInRole("Agent"))
            {
                PhotoPath = Server.MapPath(AgentPhotoPath);
            }
            if (user.IsInRole("Provider"))
            {
                PhotoPath = Server.MapPath(ProviderPhotoPath);
                return "Provider";
            }

            PhotoPath = Server.MapPath(SpecialistPhotoPath);
            return user.IsInRole("Specialist") ? "Specialist" : null;
        }

        public void SavePictures(Unit unit)
        {
            var imageStoragePath = Server.MapPath("~/UploadedImages");
            var directory = @"\" + Username + @"\" + "Property" + @"\" + TempData["UserID"] + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);


            if (!Directory.Exists(path))
            {
                UploadHelper.CreateDirectoryIfNotExist(path);
            }


            var files = uploadDirectory.GetFiles();

            directory = @"\" + Username + @"\" + TempData["UserID"] + @"\";
            var newdirectory = PhotoPath + directory;
            if (!Directory.Exists(path))
            {
                UploadHelper.CreateDirectoryIfNotExist(newdirectory);
            }
            int counter = 0;
            var virtualdestinationdirectoryvirtualmapping = Server.MapPath("~/Photo");
            virtualdestinationdirectoryvirtualmapping += @"\Owner\Property" + directory;
            //var virtualdestinationFile =  @"~\Photo\Owner\Property" + directory;
            if (!Directory.Exists(virtualdestinationdirectoryvirtualmapping))
            {
                UploadHelper.CreateDirectoryIfNotExist(virtualdestinationdirectoryvirtualmapping);
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
                    AddPicture(unit, Convert.ToInt32(TempData["UserID"]), virtualdestinationdirectoryvirtualmapping,
                               counter);
                    counter++;
                }
                if (System.IO.File.Exists(f.Name))
                    System.IO.File.Delete(f.Name);
            }
            UploadHelper.DeleteDirectoryIfExist(path);
            DefaultPhoto(unit, files, newdirectory, virtualdestinationdirectoryvirtualmapping, directory);
        }

        public void DefaultPhoto(Unit unit, FileInfo[] files, string newdirectory,
                                 string virtualdestinationdirectoryvirtualmapping, string directory)
        {
            if (!files.Any()) return;
            var defaultpropertyphoto = Server.MapPath("~/UploadedImages/Default/Property/coming_soon.png");
            var defaultpropertyphotodestination = newdirectory + @"\" + "coming_soon.png";
            var defaultvirtualpropertyphotodestination = virtualdestinationdirectoryvirtualmapping + @"\Owner\Property" +
                                                         directory + "coming_soon.png";
            System.IO.File.Copy(defaultpropertyphoto, defaultpropertyphotodestination);
            AddPicture(unit, Convert.ToInt32(TempData["UserID"]), defaultvirtualpropertyphotodestination, 0);
        }

        public void AddPicture(Unit unit, int uploaderid, string photoPath, int rank)
        {

            var unitgallery = new UnitGallery
            {
                Path = photoPath,
                Caption = "",
                Rank = rank,
                Unit = unit
            };

            if (!ModelState.IsValid) return;
            _db.UnitGalleries.Add(unitgallery);
            _db.SaveChanges();

        }

    }




    public static class DateExtension
    {
        public static long ToUnixTimestamp(this DateTime target)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            var unixTimestamp = System.Convert.ToInt64((target - date).TotalSeconds);

            return unixTimestamp;
        }

        public static DateTime ToDateTime(this DateTime target, long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);

            return dateTime.AddSeconds(timestamp);
        }
    }

}


