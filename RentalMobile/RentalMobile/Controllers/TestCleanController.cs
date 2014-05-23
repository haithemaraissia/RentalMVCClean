using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using RentalMobile.ModelViews;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class TestCleanController : Controller
    {

        //public DB_33736_rentalEntities Db = new DB_33736_rentalEntities();

        //public static void WriteResult(String result)
        //{
        //    System.Web.HttpContext.Current.Response.Write(result);
        //    System.Web.HttpContext.Current.Response.Write("<br/>");
        //}



        //public ProviderMaintenanceProfile GetProviderCoverage()
        //{
        //    //  var providerId = UserHelper.GetProviderId();
        //    var providerId = 2;

        //    if (providerId != null)
        //    {
        //        const int providerrole = 2;
        //        var lookUp =
        //            Db.MaintenanceCompanyLookUps.FirstOrDefault(
        //                x => x.Role == providerrole && x.UserId == providerId);
        //        if (lookUp != null)
        //        {
        //            int companyId = lookUp.CompanyId;

        //            return new ProviderMaintenanceProfile
        //            {
        //                MaintenanceProvider = Db.MaintenanceProviders.Find(providerId),
        //                MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
        //                MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
        //                MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
        //                MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
        //                MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
        //                MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
        //                MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
        //                MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
        //                MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId),
        //            };
        //        }
        //    }
        //    return null;

        //}

        //public SpecialistMaintenanceProfile GetSpecialistCoverage(int specialistId)
        //{
        //    const int specialistrole = 1;
        //    var specialistlookUp =
        //        Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialistId);
        //    if (specialistlookUp != null)
        //    {
        //        int companyId = specialistlookUp.CompanyId;

        //        return new SpecialistMaintenanceProfile
        //        {
        //            MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
        //            MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
        //            MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
        //            MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
        //            MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
        //            MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
        //            MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
        //            MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
        //            MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId),
        //        };
        //    }
        //    return null;
        //}

        //public static void GetCurrentProperties<T>(T objectInstance, Type objectType)
        //{
        //    System.Web.HttpContext.Current.Response.Write(objectInstance.ToString());
        //    System.Web.HttpContext.Current.Response.Write("<br/>");
        //    var properties = objectType.GetProperties();
        //    foreach (PropertyInfo pi in properties)
        //    {
        //        object value1 = objectType.GetProperty(pi.Name).GetValue(objectInstance, null);
        //        System.Web.HttpContext.Current.Response.Write(
        //            string.Format("Current Property of {0} = {1}", pi.Name, value1));
        //        System.Web.HttpContext.Current.Response.Write("<br/>");
        //    }
        //}

        //public static IEnumerable<PropertyInfo> EnumeratePropertyDifferences<T>(T obj1, T obj2)
        //{
        //    var properties = typeof(T).GetProperties();
        //    var propertyList = new List<PropertyInfo>();

        //    foreach (PropertyInfo pi in properties)
        //    {
        //        object value1 = typeof(T).GetProperty(pi.Name).GetValue(obj1, null);
        //        object value2 = typeof(T).GetProperty(pi.Name).GetValue(obj2, null);

        //        if (value1 != value2 && (value1 == null || !value1.Equals(value2)))
        //        {
        //            if (value1 is bool && value2 is bool)
        //            {
        //                var value1Bool = (bool)value1;
        //                if (value1Bool == false)
        //                {
        //                    WriteResult((string.Format("Property {0} changed from {1} to {2}  --from {3} --to {4} ",
        //                                               pi.Name, value1, value2, obj1, obj2)));
        //                    propertyList.Add(pi);
        //                }
        //            }

        //        }
        //    }
        //    return propertyList;
        //}

        //public static void SetProperty(object instance, string propertyName, object newValue)
        //{
        //    Type type = instance.GetType();

        //    if (type.BaseType != null)
        //    {
        //        PropertyInfo prop = type.BaseType.GetProperty(propertyName);

        //        prop.SetValue(instance, newValue, null);
        //    }
        //}

        //public bool IsPropertyInfoTrueforOtherMemberInTheTeam(int providerId, PropertyInfo propertyInfo, Type coverageType, object coverageValue)
        //{

        //    var propertyInfoTrueforOtherMember = false;
        //    var provider = Db.MaintenanceProviders.Find(providerId);
        //    var allSpecialistInTeam = Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId).Select(x => x.SpecialistId).ToList();
        //    if (allSpecialistInTeam.Count > 0)
        //    {
        //        foreach (var specialist in allSpecialistInTeam)
        //        {
        //            var teamMateCoverageProperty = coverageType.
        //                GetProperty(propertyInfo.Name).
        //                GetValue(GetSpecialistCoverage(specialist).MaintenanceInterior,
        //                         null);

        //            if (teamMateCoverageProperty is bool)
        //            {
        //                var teamMateCoveragePropertyValue = (bool)teamMateCoverageProperty;
        //                if (teamMateCoveragePropertyValue)
        //                {
        //                    propertyInfoTrueforOtherMember = true;
        //                }
        //            }
        //            return propertyInfoTrueforOtherMember;
        //        }
        //    }
        //    return false;
        //}

        //public void RemoveSpecialistCoverageFromProviderCoverage(IEnumerable<PropertyInfo> properties, Type maintenance)
        //{
        //    //  var providerId = UserHelper.GetProviderId();
        //    var providerId = 2;

        //    if (providerId != null)
        //    {
        //        const int providerrole = 2;
        //        var lookUp = Db.MaintenanceCompanyLookUps.FirstOrDefault( x => x.Role == providerrole && x.UserId == providerId);
        //        if (lookUp != null)
        //        {
        //            int companyId = lookUp.CompanyId;
        //            var maintenanceCoverage = Db.Set(maintenance).Find(companyId);
        //            foreach (PropertyInfo pi in properties)
        //            {
        //                SetProperty(maintenanceCoverage, pi.Name, false);
        //            }

        //            var maintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId);
        //            if (maintenanceCompanySpecialization.NumberofEmployee > 1)
        //            {
        //            maintenanceCompanySpecialization.NumberofEmployee -= 1;
        //            maintenanceCompanySpecialization.NumberofCertifitedEmplyee -= 1;
        //            }
        //            Db.SaveChanges();
        //        }
        //    }
        //}

        //public void AddSpecialistCoverageFromProviderCoverage(IEnumerable<PropertyInfo> properties, Type maintenance)
        //{
        //    //  var providerId = UserHelper.GetProviderId();
        //    var providerId = 2;

        //    if (providerId != null)
        //    {
        //        const int providerrole = 2;
        //        var lookUp =
        //            Db.MaintenanceCompanyLookUps.FirstOrDefault(
        //                x => x.Role == providerrole && x.UserId == providerId);
        //        if (lookUp != null)
        //        {
        //            int companyId = lookUp.CompanyId;
        //            var maintenanceCoverage = Db.Set(maintenance).Find(companyId);
                  
        //            foreach (PropertyInfo pi in properties)
        //            {
        //                if (pi != null)
        //                {
        //                    if (pi.GetType() != typeof(MaintenanceCompanyLookUp) ||
        //                        pi.GetType() != typeof(MaintenanceCompany) ||
        //                        pi.GetType() != typeof(MaintenanceProvider))
        //                    {
        //                        if (maintenanceCoverage != null)
        //                        {
        //                            SetProperty(maintenanceCoverage, pi.Name, true);
        //                        }

        //                    }
        //                }
        //            }
        //            var maintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId);
        //                maintenanceCompanySpecialization.NumberofEmployee += 1;
        //                maintenanceCompanySpecialization.NumberofCertifitedEmplyee += 1;
        //            Db.SaveChanges();
        //        }
        //    }
        //}

        //public void RemoveCoverageFromTeam(int providerId, object specialistCoverage, object providerCoverage, Type coverageType)
        //{
        //    Response.Write(String.Format("-------Getting the values of -{0}--------<br/>", coverageType));
        //    GetCurrentProperties(providerCoverage, coverageType);
           
        //    var difference =
        //        EnumeratePropertyDifferences(specialistCoverage, providerCoverage);
        //    var propertyInfos = difference as PropertyInfo[] ?? difference.ToArray();
        //    var propertyListTheNeedToBeRemovedFromProvider = new List<PropertyInfo>();
        //    if (propertyInfos.Count() >= 0)
        //    {
        //        foreach (var propertyInfo in propertyInfos)
        //        {
        //            var propertyInfoTrueforOtherMember = IsPropertyInfoTrueforOtherMemberInTheTeam(providerId, propertyInfo, coverageType, specialistCoverage);

        //            if (!propertyInfoTrueforOtherMember)
        //            {
        //                propertyListTheNeedToBeRemovedFromProvider.Add(propertyInfo);
        //            }
        //        }
        //        Response.Write("------Removing the values-------");
        //        Response.Write("<br/>");
        //        RemoveSpecialistCoverageFromProviderCoverage(propertyListTheNeedToBeRemovedFromProvider, coverageType);
        //        Response.Write("<br/>");
        //        Response.Write("----------PROVIDER AFTER CHANGE-------");
        //        Response.Write("<br/>");
        //        GetCurrentProperties(providerCoverage, coverageType);
        //    }
        //}

        //public void AddCoverageToTeam(int providerId, object specialistCoverage, object providerCoverage, Type coverageType)
        //{
        //   // Response.Write(String.Format("-------Getting the values of -{0}--------<br/>", coverageType));
        //    GetCurrentProperties(providerCoverage, coverageType);
        //    var difference =
        //        EnumeratePropertyDifferences(specialistCoverage, providerCoverage);
        //    var propertyInfos = difference as PropertyInfo[] ?? difference.ToArray();
        //    if (propertyInfos.Count() >= 0)
        //    {
        //        AddSpecialistCoverageFromProviderCoverage(difference, coverageType);
        //        //Response.Write("<br/>");
        //       // Response.Write("----------PROVIDER AFTER CHANGE-------");
        //       // Response.Write("<br/>");
        //        GetCurrentProperties(providerCoverage, coverageType);
        //    }
        //}
    
        
        
        public enum TeamCoverageOperations
        {
            Add = 1,
            Remove = 2,
        }

    

        public ActionResult Index()
        {

            var teamcoverageUpdate = new UpdateCoverage(2, 15);

    teamcoverageUpdate.AddAllCoverageFromSpecialistToTeam();

    teamcoverageUpdate.RemoveAllCoverageFromSpecialistToTeam();
            
            //teamcoverageUpdate.
            //RemovingCoverage();
           // AddingCoverage();
            return View();
        }



     


     

        //public void RemovingCoverage()
        //{

        //    const int specialistId = 15;
        //    const int providerId = 2;
        //    var specialistCoverage = GetSpecialistCoverage(specialistId);
        //    var providerCoverage = GetProviderCoverage();
        //    if (specialistCoverage != null)
        //    {
        //        if (providerCoverage != null)
        //        {

        //            //Removing
        //            Response.Write("----------PROVIDER BEFORE CHANGE-------");
        //            Response.Write("<br/>");
        //            RemoveCoverageFromTeam
        //                (providerId,
        //                 specialistCoverage.MaintenanceCompanySpecialization,
        //                 providerCoverage.MaintenanceCompanySpecialization,
        //                 typeof(MaintenanceCompanySpecialization));
        //        }
        //    }
        //}

        //public void AddingCoverage()
        //{
        //    const int specialistId = 15;
        //    const int providerId = 2;
        //    var specialistCoverage = GetSpecialistCoverage(specialistId);
        //    var providerCoverage = GetProviderCoverage();
        //    if (specialistCoverage != null)
        //    {
        //        if (providerCoverage != null)
        //        {

        //            //Adding 
        //            AddCoverageToTeam
        //                (providerId,
        //                 specialistCoverage.MaintenanceCompanySpecialization,
        //                 providerCoverage.MaintenanceCompanySpecialization,
        //                 typeof(MaintenanceCompanySpecialization));

        //        }
        //    }
        //}
      









        //public void GetAllSpecialistmaintenanceCompanySpecializationtoProviderCoverage()
        //{
        //    var providerId = 2;

        //    if (providerId != null)
        //    {
        //        //Get All Specialist in Team
        //        var provider = Db.MaintenanceProviders.Find(providerId);
        //        var allSpecialistInTeam =
        //            Db.MaintenanceTeamAssociations.
        //               Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
        //              .Select(x => x.SpecialistId)
        //              .ToList();
        //        if (allSpecialistInTeam.Count > 0)
        //        {
        //            foreach (var specialist in allSpecialistInTeam)
        //            {

        //                Response.Write("----------SPECIALIST COVERAGE------");
        //                Response.Write("---------- ID = ------");
        //                Response.Write(specialist);
        //                Response.Write("<br/>");
        //                GetCurrentProperties(GetSpecialistCoverage(specialist).MaintenanceCompanySpecialization, typeof(MaintenanceCompanySpecialization));
        //                Response.Write("<br/>");
        //                Response.Write("/////////////////////////");
        //                Response.Write("<br/>");
        //            }
        //        }
        //    }
        //}

    }
}
