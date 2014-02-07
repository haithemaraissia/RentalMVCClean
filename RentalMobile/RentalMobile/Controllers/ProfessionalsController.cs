using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.ModelViews;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{ 
    public class ProfessionalsController : Controller
    {
        private readonly DB_33736_rentalEntities _db = new DB_33736_rentalEntities();

        public ViewResult Index(int id)
        {
            var specialist = _db.Specialists.Find(UserHelper.GetSpecialistID(id));
            ViewBag.SpecialistProfile = specialist;
            ViewBag.SpecialistId = specialist.SpecialistId;
            ViewBag.SpecialistGoogleMap = specialist.GoogleMap;
            return View(specialist);
        }



        public PartialViewResult _Coverage(int id)
        {

            if (id != 0)
            {
                const int specialistrole = 1;
                var lookUp =
                    _db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == specialistrole && x.UserId == id);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mp = new SpecialistMaintenanceProfile
                    {
                        MaintenanceCompanyLookUp = _db.MaintenanceCompanyLookUps.Find(companyId),
                        MaintenanceCompany = _db.MaintenanceCompanies.Find(companyId),
                        MaintenanceCompanySpecialization = _db.MaintenanceCompanySpecializations.Find(companyId),
                        MaintenanceCustomService = _db.MaintenanceCustomServices.Find(companyId),
                        MaintenanceExterior = _db.MaintenanceExteriors.Find(companyId),
                        MaintenanceInterior = _db.MaintenanceInteriors.Find(companyId),
                        MaintenanceNewConstruction = _db.MaintenanceNewConstructions.Find(companyId),
                        MaintenanceRepair = _db.MaintenanceRepairs.Find(companyId),
                        MaintenanceUtility = _db.MaintenanceUtilities.Find(companyId),
                    };

                    return PartialView(mp);
                }
            }
            return null;
        }


        public PartialViewResult _Description(int id)
        {

            if (id != 0)
            {
                const int specialistrole = 1;
                var lookUp =
                    _db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == specialistrole && x.UserId == id);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var mcs = _db.MaintenanceCompanySpecializations.FirstOrDefault(x => x.CompanyId == companyId);
                    if (mcs != null)
                    {
                        ViewBag.Rate = mcs.Rate;
                        var currency = _db.Currencies.FirstOrDefault(x => x.CurrencyID == mcs.CurrencyID);
                        if (currency != null)
                            ViewBag.Currency = currency.CurrencyValue;
                    }

                    var currentspecialist = _db.Specialists.FirstOrDefault(x => x.SpecialistId == id);
                    return PartialView(currentspecialist);
                }
            }
            return null;
        }



        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}