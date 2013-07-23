using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class OwnerController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();

        // GET: /Owner/

        public ViewResult Index()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerID());
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
            var owner = db.Owners.Find(UserHelper.GetOwnerID());

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
            var owner = db.Owners.Find(UserHelper.GetOwnerID());

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
            var owner = db.Owners.Find(UserHelper.GetOwnerID());

            return View(db.OwnerRejectedApplications.Where(x => x.OwnerId == owner.OwnerId).ToList());
        }


        //










        //same as index to get the same look and fell
        public ViewResult GeneratedContract()
        {
            var owner = db.Owners.Find(UserHelper.GetOwnerID());
            ViewBag.OwnerProfile = owner;
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);

        }

        public ViewResult GeneratedRentalAgreement()
        {
             return View(db.GeneratedRentalContracts.ToList().FirstOrDefault(x => x.LandLoradID ==  UserHelper.GetOwnerID()));
        }
    }
}