using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using RentalMobile.Models;

namespace RentalMobile.ModelViews
{
    public class SpecialistMaintenanceProfile
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();
        public MaintenanceCompanyLookUp MaintenanceCompanyLookUp { get; set; }
        public MaintenanceCompany MaintenanceCompany { get; set; }
        public MaintenanceCompanySpecialization MaintenanceCompanySpecialization { get; set; }
        public MaintenanceCustomService MaintenanceCustomService { get; set; }
        public MaintenanceExterior MaintenanceExterior { get; set; }
        public MaintenanceInterior MaintenanceInterior { get; set; }
        public MaintenanceNewConstruction MaintenanceNewConstruction { get; set; }
        public MaintenanceRepair MaintenanceRepair { get; set; }
        public MaintenanceUtility MaintenanceUtility { get; set; }

        public SpecialistMaintenanceProfile()
        {
            MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp();
            MaintenanceCompany = new MaintenanceCompany();
            MaintenanceCompanySpecialization = new MaintenanceCompanySpecialization();
            MaintenanceCustomService = new MaintenanceCustomService();
            MaintenanceExterior = new MaintenanceExterior();
            MaintenanceInterior = new MaintenanceInterior();
            MaintenanceNewConstruction = new MaintenanceNewConstruction();
            MaintenanceRepair = new MaintenanceRepair();
            MaintenanceUtility = new MaintenanceUtility();

        }

        public SpecialistMaintenanceProfile(int role, int userId)
        {
            MaintenanceCompanyLookUp = db.MaintenanceCompanyLookUps.
                Include("MaintenanceCompany").
                Include("MaintenanceCompanySpecialization").
                Include("MaintenanceCustomService").
                Include("MaintenanceExterior").
                Include("MaintenanceInterior").
                Include("MaintenanceNewConstruction").
                Include("MaintenanceRepair").
                Include("MaintenanceUtility").
                FirstOrDefault(x => x.Role == role && x.UserId == userId);
            //MaintenanceCompany = new MaintenanceCompany();
            //MaintenanceCompanySpecialization = new MaintenanceCompanySpecialization();
            //MaintenanceCustomService = new MaintenanceCustomService();
            //MaintenanceExterior = new MaintenanceExterior();
            //MaintenanceInterior = new MaintenanceInterior();
            //MaintenanceNewConstruction = new MaintenanceNewConstruction();
            //MaintenanceRepair = new MaintenanceRepair();
            //MaintenanceUtility = new MaintenanceUtility();

        }

        public void Save()
        {
            try
            {
            db.MaintenanceCompanyLookUps.Add(MaintenanceCompanyLookUp);
            db.MaintenanceCompanies.Add(MaintenanceCompany);
            db.MaintenanceCompanySpecializations.Add(MaintenanceCompanySpecialization);
            db.MaintenanceCustomServices.Add(MaintenanceCustomService);
            db.MaintenanceExteriors.Add(MaintenanceExterior);
            db.MaintenanceInteriors.Add(MaintenanceInterior);
            db.MaintenanceNewConstructions.Add(MaintenanceNewConstruction);
            db.MaintenanceRepairs.Add(MaintenanceRepair);
            db.MaintenanceUtilities.Add(MaintenanceUtility);
            db.SaveChanges();
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
    }
}
