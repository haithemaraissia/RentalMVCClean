using System;
using System.Collections.Generic;
using System.Data;
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

      //
        //   public SpecialistMaintenanceProfile()
     //   {
     //       MaintenanceCompanyLookUp = new MaintenanceCompanyLookUp();
     //       MaintenanceCompany = new MaintenanceCompany();
     //       MaintenanceCompanySpecialization = new MaintenanceCompanySpecialization();
     //       MaintenanceCustomService = new MaintenanceCustomService();
     //       MaintenanceExterior = new MaintenanceExterior();
     //       MaintenanceInterior = new MaintenanceInterior();
     //       MaintenanceNewConstruction = new MaintenanceNewConstruction();
     //       MaintenanceRepair = new MaintenanceRepair();
     //       MaintenanceUtility = new MaintenanceUtility();

     //   }





     //   //More Review try to use this
     //   public SpecialistMaintenanceProfile(int companyId)
     //   {
     //       MaintenanceCompanyLookUp = db.MaintenanceCompanyLookUps.Find(companyId);
     //       MaintenanceCompany = db.MaintenanceCompanies.Find(companyId);
     //       MaintenanceCompanySpecialization = db.MaintenanceCompanySpecializations.Find(companyId);
     //       MaintenanceCustomService = db.MaintenanceCustomServices.Find(companyId);
     //       MaintenanceExterior = db.MaintenanceExteriors.Find(companyId);
     //       MaintenanceInterior = db.MaintenanceInteriors.Find(companyId);
     //       MaintenanceNewConstruction = db.MaintenanceNewConstructions.Find(companyId);
     //       MaintenanceRepair = db.MaintenanceRepairs.Find(companyId);
     //       MaintenanceUtility = db.MaintenanceUtilities.Find(companyId);

     //   }

     //   //public SpecialistMaintenanceProfile(int role, int userId)
     //   //{
     //   //    var test = MaintenanceCompanyLookUp = db.MaintenanceCompanyLookUps.
     //   //        Include("MaintenanceCompany").
     //   //        Include("MaintenanceCompanySpecialization").
     //   //        Include("MaintenanceCustomService").
     //   //        Include("MaintenanceExterior").
     //   //        Include("MaintenanceInterior").
     //   //        Include("MaintenanceNewConstruction").
     //   //        Include("MaintenanceRepair").
     //   //        Include("MaintenanceUtility").
     //   //        FirstOrDefault(x => x.Role == role && x.UserId == userId);

     //   //    if (test != null)
     //   //    {
     //   //        var t = new SpecialistMaintenanceProfile
     //   //        {
     //   //            MaintenanceCompanyLookUp = test,
     //   //            MaintenanceCompany = test.MaintenanceCompany,
     //   //            MaintenanceCustomService = test.MaintenanceCustomService,
     //   //            MaintenanceInterior = test.MaintenanceInterior,
     //   //            MaintenanceExterior = test.MaintenanceExterior,
     //   //            MaintenanceNewConstruction = test.MaintenanceNewConstruction,
     //   //            MaintenanceRepair = test.MaintenanceRepair,
     //   //            MaintenanceCompanySpecialization = test.MaintenanceCompanySpecialization,
     //   //            MaintenanceUtility = test.MaintenanceUtility
     //   //        };

     //   //    }

     //   //    //MaintenanceCompanyLookUp = s.MaintenanceCompanyLookUp;
     //   //    //MaintenanceCompany = s.MaintenanceCompany;
     //   //    //MaintenanceCompanySpecialization = s.MaintenanceCompanySpecialization;
     //   //    //MaintenanceCustomService = s.MaintenanceCustomService;
     //   //    //MaintenanceExterior = s.MaintenanceExterior;
     //   //    //MaintenanceInterior = s.MaintenanceInterior;
     //   //    //MaintenanceNewConstruction = s.MaintenanceNewConstruction;
     //   //    //MaintenanceRepair = s.MaintenanceRepair;
     //   //    //MaintenanceUtility = s.MaintenanceUtility;

     //   //}



     //public SpecialistMaintenanceProfile Profile(int role, int userId)
     //   {
     //      var test = MaintenanceCompanyLookUp = db.MaintenanceCompanyLookUps.
     //           Include("MaintenanceCompany").
     //           Include("MaintenanceCompanySpecialization").
     //           Include("MaintenanceCustomService").
     //           Include("MaintenanceExterior").
     //           Include("MaintenanceInterior").
     //           Include("MaintenanceNewConstruction").
     //           Include("MaintenanceRepair").
     //           Include("MaintenanceUtility").
     //           FirstOrDefault(x => x.Role == role && x.UserId == userId);


     //    if (test != null)
     //    {
     //        var t = new SpecialistMaintenanceProfile
     //                    {
     //                        MaintenanceCompanyLookUp = test,
     //                        MaintenanceCompany = test.MaintenanceCompany,
     //                        MaintenanceCustomService = test.MaintenanceCustomService,
     //                        MaintenanceInterior = test.MaintenanceInterior,
     //                        MaintenanceExterior = test.MaintenanceExterior,
     //                        MaintenanceNewConstruction = test.MaintenanceNewConstruction,
     //                        MaintenanceRepair = test.MaintenanceRepair,
     //                        MaintenanceCompanySpecialization = test.MaintenanceCompanySpecialization,
     //                        MaintenanceUtility = test.MaintenanceUtility
     //                    };

     //        return t;
     //    }


     //  //     var test2 = MaintenanceCompanyLookUp = db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == role && x.UserId == userId);
     //       //MaintenanceCompany = new MaintenanceCompany();
     //       //MaintenanceCompanySpecialization = new MaintenanceCompanySpecialization();
     //       //MaintenanceCustomService = new MaintenanceCustomService();
     //       //MaintenanceExterior = new MaintenanceExterior();
     //       //MaintenanceInterior = new MaintenanceInterior();
     //       //MaintenanceNewConstruction = new MaintenanceNewConstruction();
     //       //MaintenanceRepair = new MaintenanceRepair();
     //       //MaintenanceUtility = new MaintenanceUtility();
     //       return null;
     //   }
     //   //More Review
    
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
     //public void Save(SpecialistMaintenanceProfile s)
     //   {
     //       try
     //       {
   
     //       db.Entry(s.MaintenanceCompany).State = EntityState.Modified;
     //       db.Entry(s.MaintenanceCompanyLookUp).State = EntityState.Modified;
     //       db.Entry(s.MaintenanceCompanySpecialization).State = EntityState.Modified;
     //       db.Entry(s.MaintenanceCustomService).State = EntityState.Modified;
     //       db.Entry(s.MaintenanceExterior).State = EntityState.Modified;
     //       db.Entry(s.MaintenanceInterior).State = EntityState.Modified;
     //       db.Entry(s.MaintenanceNewConstruction).State = EntityState.Modified;
     //       db.Entry(s.MaintenanceRepair).State = EntityState.Modified;
     //       db.Entry(s.MaintenanceUtility).State = EntityState.Modified;
     //       db.SaveChanges();
     //       }
     //       catch (DbEntityValidationException e)
     //       {
     //           foreach (var eve in e.EntityValidationErrors)
     //           {
     //               Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
     //                   eve.Entry.Entity.GetType().Name, eve.Entry.State);
     //               foreach (var ve in eve.ValidationErrors)
     //               {
     //                   Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
     //                       ve.PropertyName, ve.ErrorMessage);
     //               }
     //           }
     //           throw;
     //       }

     //   }
    }
}
