using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    [Authorize]
    public class TenantRentalApplicationController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();
        public static Guid UserGUID = (Guid)UserHelper.GetUserGUID();
        public int TenantID = (int)UserHelper.GetTenantID(UserGUID);


        // GET: /RATest/

        public ViewResult Index()
        {

            var tenantrentalapplication = db.RentalApplications.
                Where(t => t.TenantId == TenantID);

            return View(tenantrentalapplication.FirstOrDefault());
        }

        //
        // GET: /RATest/Details/5

        public ViewResult Details()
        {
            var tenantrentalapplication = db.RentalApplications.Where(t => t.TenantId == TenantID);
            if (!tenantrentalapplication.Any())
            {
                RedirectToActionPermanent("Create");
            }

            return View(tenantrentalapplication.FirstOrDefault());
        }

        //
        // GET: /RATest/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RATest/Create

        [HttpPost]
        public ActionResult Create(RentalApplication rentalapplication)
        {
            if (ModelState.IsValid)
            {
                rentalapplication.TenantId = TenantID;
                db.RentalApplications.Add(rentalapplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(rentalapplication);
        }

        //
        // GET: /RATest/Edit/5

        public ActionResult Edit()
        {
            var tenantrentalapplication = db.RentalApplications.Where(t => t.TenantId == TenantID);
            if (!tenantrentalapplication.Any())
            {
                RedirectToActionPermanent("Create");
            }

            return View(tenantrentalapplication.FirstOrDefault());
        }

        //
        // POST: /RATest/Edit/5

        [HttpPost]
        public ActionResult Edit(RentalApplication rentalapplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalapplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalapplication);
        }

        //
        // GET: /RATest/Delete/5

        public ActionResult Delete(int id)
        {
            RentalApplication rentalapplication = db.RentalApplications.Find(id);
            return View(rentalapplication);
        }

        //
        // POST: /RATest/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalApplication rentalapplication = db.RentalApplications.Find(id);
            db.RentalApplications.Remove(rentalapplication);
            db.SaveChanges();
            return RedirectToAction("Index");
        }









        //
        // GET: /RATest/Edit/5

        public ActionResult Submit()
        {
            return View();
        }



        //    [HttpPost]
        //            public ActionResult Submit(string propertyIdcustom)
        //{
        //    return View();
        //}

        //
        // POST: /RATest/Edit/5

        [HttpPost]
        public ActionResult Submit(string propertyIdcustom)
        {

            //Property

            var propertyId = (Convert.ToInt32(propertyIdcustom));
            var property = db.Units.FirstOrDefault(t => t.UnitId == propertyId);
            if (property == null)
            {
                return RedirectToAction("submit");
            }



            //OVER HERE YOU HAVE TO
            //CHECK THAT AN APPLICATION EXIST
            var tenantrentalapplication = db.RentalApplications.Where(t => t.TenantId == TenantID);
            if (!tenantrentalapplication.Any())
            {
                return RedirectToAction("Create", "TenantRentalApplication");

            }


            //PROCESS TO AMAZONPAYPAL
            //YOU DON'T NEED MODEL VALIDATION

            //ALSO WHEN SUCCED
            //ADD ROW IN PAYMENT WITH DESCRIPTION OF THIS TRANSACTION

            //ALSO SEND EMAIL TO LISTER
            //SO HE OR SHE DOES BACKGROUND CHECKING AND ACCPET/DENY APPLICATION

            //Insert into Owner/Agent Pending Application when Application payment is complete 
            //var f = db.Units.Where(t=>t.)

            //WHEN AMAZON PAYMENT SUCCEED
            if (property != null)
            {
                var posterrole = property.PosterRole.Trim();

                switch (posterrole)
                {

                    case "Owner":
                        //Insert into Pending Application
                        if (property.PosterID != null)
                            InsertOwnerPendingApplication(tenantrentalapplication.First(), (int)property.PosterID);
                        ViewData["confirmationmsg"] = "Your Application had been succesfully submitted to the Owner.";

                        //Confirmation that is has been posted
                        break;

                    case "Agent":
                        //Insert into Pending Application
                        if (property.PosterID != null)
                            InsertAgentPendingApplication(tenantrentalapplication.First(), (int)property.PosterID);
                        ViewData["confirmationmsg"] = "Pass";
                        break;

                }
            }
            return View();
        }



        protected void InsertOwnerPendingApplication(RentalApplication r, int ownerId)
        {

            var opa = new OwnerPendingApplication
                {
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    MiddleName = r.MiddleName,
                    SocialSecurityNumber = r.SocialSecurityNumber,
                    DriverLicense = r.DriverLicense,
                    Phone = r.Phone,
                    CellPhone = r.CellPhone,
                    EmailAddress = r.EmailAddress,
                    CoSignerName = r.CoSignerName,
                    CoSignerAddress = r.CoSignerAddress,
                    CoSignerCity = r.CoSignerCity,
                    CoSignerState = r.CoSignerState,
                    CoSignerZipcode = r.CoSignerZipcode,
                    CoSignerPhone = r.CoSignerPhone,
                    CoSignerRelationShip = r.CoSignerRelationShip,
                    CoSignerEmailAddress = r.CoSignerEmailAddress,
                    OtherOccupant1Name = r.OtherOccupant1Name,
                    IsOccupant1Adult = r.IsOccupant1Adult,
                    RelationshipOccupant1ToApplicant = r.RelationshipOccupant1ToApplicant,
                    OtherOccupant2Name = r.OtherOccupant2Name,
                    IsOccupant2Adult = r.IsOccupant2Adult,
                    RelationshipOccupant2ToApplicant = r.RelationshipOccupant2ToApplicant,
                    OtherOccupant3Name = r.OtherOccupant3Name,
                    IsOccupant3Adult = r.IsOccupant3Adult,
                    RelationshipOccupant3ToApplicant = r.RelationshipOccupant3ToApplicant,
                    OtherOccupant4Name = r.OtherOccupant4Name,
                    IsOccupant4Adult = r.IsOccupant4Adult,
                    RelationshipOccupant4ToApplicant = r.RelationshipOccupant4ToApplicant,
                    EmployerName = r.EmployerName,
                    Income = r.Income,
                    WorkStartDate = r.WorkStartDate,
                    WorkEndDate = r.WorkEndDate,
                    EmployerAddress = r.EmployerAddress,
                    EmployerCity = r.EmployerCity,
                    EmployerState = r.EmployerState,
                    EmployerZipcode = r.EmployerZipcode,
                    EmployerPhone = r.EmployerPhone,
                    EmployerFax = r.EmployerFax,
                    CurrentLandloard = r.CurrentLandloard,
                    CurrentLandLoardPhone = r.CurrentLandLoardPhone,
                    CurrentLandLoardFax = r.CurrentLandLoardFax,
                    CurrentAddress = r.CurrentAddress,
                    CurrentAddressCity = r.CurrentAddressCity,
                    CurrentAddressState = r.CurrentAddressState,
                    CurrentAddressZip = r.CurrentAddressZip,
                    Rent = r.Rent,
                    CurrentRentStartDate = r.CurrentRentStartDate,
                    CurrentRentEndDate = r.CurrentRentEndDate,
                    PreviousLandloard = r.PreviousLandloard,
                    PreviousLandLoardPhone = r.PreviousLandLoardPhone,
                    PreviousLandLoardFax = r.PreviousLandLoardFax,
                    PreviousAddress = r.PreviousAddress,
                    PreviousAddressCity = r.PreviousAddressCity,
                    PreviousAddressState = r.PreviousAddressState,
                    PreviousAddressZip = r.PreviousAddressZip,
                    PreviousRent = r.PreviousRent,
                    PreviousRentStartDate = r.PreviousRentStartDate,
                    PreviousRentEndDate = r.PreviousRentEndDate,
                    EmergencyContactName = r.EmergencyContactName,
                    EmergencyContactRelationShip = r.EmergencyContactRelationShip,
                    EmergencyContactPhone = r.EmergencyContactPhone,
                    EmergencyContactAddress = r.EmergencyContactAddress,
                    EmergencyContactCity = r.EmergencyContactCity,
                    EmergencyContactState = r.EmergencyContactState,
                    EmergencyContactZipCode = r.EmergencyContactZipCode,
                    Pets = r.Pets,
                    PetsNumber = r.PetsNumber,
                    Pet1Brand = r.Pet1Brand,
                    Pet1Age = r.Pet1Age,
                    Pet1Weight = r.Pet1Weight,
                    Pet2Brand = r.Pet2Brand,
                    Pet2Age = r.Pet2Age,
                    Pet2Weight = r.Pet2Weight,
                    Vehicle1Make = r.Vehicle1Make,
                    Vehicle1Model = r.Vehicle1Model,
                    Vehicle1Year = r.Vehicle1Year,
                    Vehicle1Color = r.Vehicle1Color,
                    Vehicle1LicensePlate = r.Vehicle1LicensePlate,
                    Vehicle2Make = r.Vehicle2Make,
                    Vehicle2Model = r.Vehicle2Model,
                    Vehicle2Year = r.Vehicle2Year,
                    Vehicle2Color = r.Vehicle2Color,
                    Vehicle2LicensePlate = r.Vehicle2LicensePlate,
                    Vehicle3Make = r.Vehicle3Make,
                    Vehicle3Model = r.Vehicle3Model,
                    Vehicle3Year = r.Vehicle3Year,
                    Vehicle3Color = r.Vehicle3Color,
                    Vehicle3LicensePlate = r.Vehicle3LicensePlate,
                    Vehicle4Make = r.Vehicle4Make,
                    Vehicle4Model = r.Vehicle4Model,
                    Vehicle4Year = r.Vehicle4Year,
                    Vehicle4Color = r.Vehicle4Color,
                    Vehicle4LicensePlate = r.Vehicle4LicensePlate,
                    Bankruptcy = r.Bankruptcy,
                    LeaseDefaulted = r.LeaseDefaulted,
                    RefusedtoPayRent = r.RefusedtoPayRent,
                    EvictedFromRental = r.EvictedFromRental,
                    ConvictedofFelony = r.ConvictedofFelony,
                    TenantId = r.TenantId,
                    OwnerId = ownerId
                };

            db.OwnerPendingApplications.Add(opa);
            db.SaveChanges();
        }

        protected void InsertAgentPendingApplication(RentalApplication r, int agentId)
        {
            var apa = new AgentPendingApplication
            {
                FirstName = r.FirstName,
                LastName = r.LastName,
                MiddleName = r.MiddleName,
                SocialSecurityNumber = r.SocialSecurityNumber,
                DriverLicense = r.DriverLicense,
                Phone = r.Phone,
                CellPhone = r.CellPhone,
                EmailAddress = r.EmailAddress,
                CoSignerName = r.CoSignerName,
                CoSignerAddress = r.CoSignerAddress,
                CoSignerCity = r.CoSignerCity,
                CoSignerState = r.CoSignerState,
                CoSignerZipcode = r.CoSignerZipcode,
                CoSignerPhone = r.CoSignerPhone,
                CoSignerRelationShip = r.CoSignerRelationShip,
                CoSignerEmailAddress = r.CoSignerEmailAddress,
                OtherOccupant1Name = r.OtherOccupant1Name,
                IsOccupant1Adult = r.IsOccupant1Adult,
                RelationshipOccupant1ToApplicant = r.RelationshipOccupant1ToApplicant,
                OtherOccupant2Name = r.OtherOccupant2Name,
                IsOccupant2Adult = r.IsOccupant2Adult,
                RelationshipOccupant2ToApplicant = r.RelationshipOccupant2ToApplicant,
                OtherOccupant3Name = r.OtherOccupant3Name,
                IsOccupant3Adult = r.IsOccupant3Adult,
                RelationshipOccupant3ToApplicant = r.RelationshipOccupant3ToApplicant,
                OtherOccupant4Name = r.OtherOccupant4Name,
                IsOccupant4Adult = r.IsOccupant4Adult,
                RelationshipOccupant4ToApplicant = r.RelationshipOccupant4ToApplicant,
                EmployerName = r.EmployerName,
                Income = r.Income,
                WorkStartDate = r.WorkStartDate,
                WorkEndDate = r.WorkEndDate,
                EmployerAddress = r.EmployerAddress,
                EmployerCity = r.EmployerCity,
                EmployerState = r.EmployerState,
                EmployerZipcode = r.EmployerZipcode,
                EmployerPhone = r.EmployerPhone,
                EmployerFax = r.EmployerFax,
                CurrentLandloard = r.CurrentLandloard,
                CurrentLandLoardPhone = r.CurrentLandLoardPhone,
                CurrentLandLoardFax = r.CurrentLandLoardFax,
                CurrentAddress = r.CurrentAddress,
                CurrentAddressCity = r.CurrentAddressCity,
                CurrentAddressState = r.CurrentAddressState,
                CurrentAddressZip = r.CurrentAddressZip,
                Rent = r.Rent,
                CurrentRentStartDate = r.CurrentRentStartDate,
                CurrentRentEndDate = r.CurrentRentEndDate,
                PreviousLandloard = r.PreviousLandloard,
                PreviousLandLoardPhone = r.PreviousLandLoardPhone,
                PreviousLandLoardFax = r.PreviousLandLoardFax,
                PreviousAddress = r.PreviousAddress,
                PreviousAddressCity = r.PreviousAddressCity,
                PreviousAddressState = r.PreviousAddressState,
                PreviousAddressZip = r.PreviousAddressZip,
                PreviousRent = r.PreviousRent,
                PreviousRentStartDate = r.PreviousRentStartDate,
                PreviousRentEndDate = r.PreviousRentEndDate,
                EmergencyContactName = r.EmergencyContactName,
                EmergencyContactRelationShip = r.EmergencyContactRelationShip,
                EmergencyContactPhone = r.EmergencyContactPhone,
                EmergencyContactAddress = r.EmergencyContactAddress,
                EmergencyContactCity = r.EmergencyContactCity,
                EmergencyContactState = r.EmergencyContactState,
                EmergencyContactZipCode = r.EmergencyContactZipCode,
                Pets = r.Pets,
                PetsNumber = r.PetsNumber,
                Pet1Brand = r.Pet1Brand,
                Pet1Age = r.Pet1Age,
                Pet1Weight = r.Pet1Weight,
                Pet2Brand = r.Pet2Brand,
                Pet2Age = r.Pet2Age,
                Pet2Weight = r.Pet2Weight,
                Vehicle1Make = r.Vehicle1Make,
                Vehicle1Model = r.Vehicle1Model,
                Vehicle1Year = r.Vehicle1Year,
                Vehicle1Color = r.Vehicle1Color,
                Vehicle1LicensePlate = r.Vehicle1LicensePlate,
                Vehicle2Make = r.Vehicle2Make,
                Vehicle2Model = r.Vehicle2Model,
                Vehicle2Year = r.Vehicle2Year,
                Vehicle2Color = r.Vehicle2Color,
                Vehicle2LicensePlate = r.Vehicle2LicensePlate,
                Vehicle3Make = r.Vehicle3Make,
                Vehicle3Model = r.Vehicle3Model,
                Vehicle3Year = r.Vehicle3Year,
                Vehicle3Color = r.Vehicle3Color,
                Vehicle3LicensePlate = r.Vehicle3LicensePlate,
                Vehicle4Make = r.Vehicle4Make,
                Vehicle4Model = r.Vehicle4Model,
                Vehicle4Year = r.Vehicle4Year,
                Vehicle4Color = r.Vehicle4Color,
                Vehicle4LicensePlate = r.Vehicle4LicensePlate,
                Bankruptcy = r.Bankruptcy,
                LeaseDefaulted = r.LeaseDefaulted,
                RefusedtoPayRent = r.RefusedtoPayRent,
                EvictedFromRental = r.EvictedFromRental,
                ConvictedofFelony = r.ConvictedofFelony,
                TenantId = r.TenantId,
                AgentId = agentId
            };

            db.AgentPendingApplications.Add(apa);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}