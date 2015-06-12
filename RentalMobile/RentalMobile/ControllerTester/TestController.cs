using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalMobile.ControllerTester
{
    public class TestController : Controller
    {
        //
        // GET: /Test/3


        public RentalContext Db = new RentalContext();

        public SpecialistZone GetSpecialistZone(int specialistId)
        {
            var specialist = Db.Specialists.FirstOrDefault(x => x.SpecialistId == specialistId);
            if (specialist != null)
            {
                if (specialist.City != null)
                {
                    return new SpecialistZone
                        {
                            Zone = specialist.City,
                            Zipcode = specialist.Zip
                        };
                }
            }

            return null;
        }

        public SpecialistZone GetSpecialistCompanyZone(int specialistId)
        {
            var companyLookUp = Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.UserId == specialistId && x.Role == 1);
            if (companyLookUp != null)
            {
                var specialistcompany =
                    Db.MaintenanceCompanies.FirstOrDefault(x => x.CompanyId == companyLookUp.CompanyId);
                if (specialistcompany != null)
                {
                    return new SpecialistZone
                        {
                            Zone = specialistcompany.City,
                            Zipcode = specialistcompany.Zip
                        };
                }
            }
            return null;
        }








        public static void GetCurrentProperties<T>(T obj1)
        {
            System.Web.HttpContext.Current.Response.Write(obj1.ToString());
            System.Web.HttpContext.Current.Response.Write("<br/>");
            var properties = typeof (T).GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                object value1 = typeof (T).GetProperty(pi.Name).GetValue(obj1, null);
                System.Web.HttpContext.Current.Response.Write(
                    string.Format("Current Property of {0} = {1}", pi.Name, value1));
                System.Web.HttpContext.Current.Response.Write("<br/>");
            }
        }

        public static IEnumerable<PropertyInfo> EnumeratePropertyDifferences<T>(T obj1, T obj2)
        {
            var properties = typeof (T).GetProperties();
            var changes = new List<string>();
            var propertyList = new List<PropertyInfo>();

            foreach (PropertyInfo pi in properties)
            {
                object value1 = typeof (T).GetProperty(pi.Name).GetValue(obj1, null);
                object value2 = typeof (T).GetProperty(pi.Name).GetValue(obj2, null);

                if (value1 != value2 && (value1 == null || !value1.Equals(value2)))
                {
                    if (value1 is bool && value2 is bool)
                    {
                        var value1Bool = (bool) value1;
                        if (value1Bool == false)
                        {
                            // changes.Add(string.Format("Property {0} changed from {1} to {2}", pi.Name, value1, value2));
                            WriteResult((string.Format("Property {0} changed from {1} to {2}  --from {3} --to {4} ",
                                                       pi.Name, value1, value2, obj1, obj2)));
                            propertyList.Add(pi);
                        }
                    }

                }
            }
            return propertyList;
        }

        public static void WriteResult(String result)
        {
            System.Web.HttpContext.Current.Response.Write(result);
            System.Web.HttpContext.Current.Response.Write("<br/>");
        }

        public static void SetProperty(object instance, string propertyName, object newValue)
        {
            Type type = instance.GetType();

            if (type.BaseType != null)
            {
                PropertyInfo prop = type.BaseType.GetProperty(propertyName);

                prop.SetValue(instance, newValue, null);
            }
        }

        public ActionResult Index()
        {
            const int specialistId = 15;
            const int providerId = 2;
            var specialistCoverage = GetSpecialistCoverage(specialistId);
            var providerCoverage = GetProviderCoverage();
            if (specialistCoverage != null)
            {
                if (providerCoverage != null)
                {

                    //Adding 
                    //Response.Write("----------PROVIDER BEFORE CHANGE-------");
                    //Response.Write("<br/>");
                    //GetCurrentProperties(providerCoverage.MaintenanceCompanySpecialization);


                    //Response.Write("-------Getting the values---------");
                    //Response.Write("<br/>");
                    //var difference = EnumeratePropertyDifferences
                    //    (providerCoverage.MaintenanceCompanySpecialization,
                    //     specialistCoverage.MaintenanceCompanySpecialization);

                    //Response.Write("------Setting the values-------");
                    //Response.Write("<br/>");
                    //AddSpecialistmaintenanceCompanySpecializationtoProviderCoverage(difference);
                    //Response.Write("<br/>");

                    //Response.Write("----------PROVIDER AFTER CHANGE-------");
                    //Response.Write("<br/>");
                    //GetCurrentProperties(providerCoverage.MaintenanceCompanySpecialization);






                    //Removing
                    Response.Write("----------PROVIDER BEFORE CHANGE-------");
                    Response.Write("<br/>");

                    GetMaintenanceCompanySpecializationValue(providerCoverage, specialistCoverage, providerId);

                    GetMaintenanceCompanyRepair(providerCoverage, specialistCoverage, providerId);

                    //var propertyInfos = difference as PropertyInfo[] ?? difference.ToArray();
                    //var propertyListTheNeedToBeRemovedFromProvider = new List<PropertyInfo>();
                    //if (propertyInfos.Count() >= 0)
                    //{
                    //    foreach (var propertyInfo in propertyInfos)
                    //    {
                    //        //Compare to each specialist coverage
                    //        //For all Specialist

                    //        var propertyInfoTrueforOtherMember = 
                    //            IsPropertyInfoTrueforOtherMemberForMaintenanceCompanySpecialization(providerId, propertyInfo);

                    //        if (propertyInfoTrueforOtherMember)
                    //        {
                    //            //No action
                    //            //Already Exist in Other Team Member
                    //        }
                    //        else
                    //        {
                    //            //You need to remove it from the Provider Coverage

                    //            propertyListTheNeedToBeRemovedFromProvider.Add(propertyInfo);
                    //        }
                    //    }
                    //    Response.Write("------Removing the values-------");
                    //    Response.Write("<br/>");
                    //    RemoveSpecialistmaintenanceCompanySpecializationFromProviderCoverage(
                    //        propertyListTheNeedToBeRemovedFromProvider);
                    //    Response.Write("<br/>");

                    //    Response.Write("----------PROVIDER AFTER CHANGE-------");
                    //    Response.Write("<br/>");
                    //    GetCurrentProperties(providerCoverage.MaintenanceCompanySpecialization);






                   // //Testing
                   // Response.Write("----------PROVIDER PROPERTY-------");
                   // Response.Write("<br/>");

                   // //Getting The properties for ProviderCoverage through Reflection
                   // var teamMainteanceProvider = GetProviderCoverage();

                   // var properties = typeof(ProviderMaintenanceProfile).GetProperties();
                   // foreach (PropertyInfo pi in properties)
                   // {
                   //     var teamMainteanceProviderValue = typeof(ProviderMaintenanceProfile).GetProperty(pi.Name).GetValue(teamMainteanceProvider, null);
                   //     System.Web.HttpContext.Current.Response.Write(
                   //         string.Format("Current Property of {0} = {1}", pi.Name, teamMainteanceProviderValue));

                   //     var coverageType = teamMainteanceProvider.GetType();
                   //     var coverage = coverageType.GetProperties();



                   //     //foreach (PropertyInfo ps in coverageType)
                   //     //{
                   //     //    object value1 = typeof(coverageType).GetProperty(pi.Name).GetValue(coverage, null);
                   //     //    System.Web.HttpContext.Current.Response.Write(
                   //     //        string.Format("Current Property of {0} = {1}", pi.Name, value1));
                   //     //    System.Web.HttpContext.Current.Response.Write("<br/>");
                   //     //}



                   //     //Foreach Property Get Property
                   ////     GetCurrentProperties(teamMainteanceProviderValue);
                   //     GetCurrentProperties(coverageType);
                   //     GetCurrentProperties(coverage);
                   //     Response.Write("<br/>");
                   //     Response.Write("---------------");

                   // }

                   

                   // Response.Write("-------Getting the values---------");
                   // Response.Write("<br/>");

                   // var difference = EnumeratePropertyDifferences
                   //     (specialistCoverage.MaintenanceCompanySpecialization,
                   //      providerCoverage.MaintenanceCompanySpecialization);

                    //var propertyInfos = difference as PropertyInfo[] ?? difference.ToArray();
                    //var propertyListTheNeedToBeRemovedFromProvider = new List<PropertyInfo>();
                    //if (propertyInfos.Count() >= 0)
                    //{
                    //    foreach (var propertyInfo in propertyInfos)
                    //    {
                    //        //Compare to each specialist coverage
                    //        //For all Specialist

                    //        var propertyInfoTrueforOtherMember =
                    //            IsPropertyInfoTrueforOtherMemberForMaintenanceCompanySpecialization(providerId, propertyInfo);

                    //        if (propertyInfoTrueforOtherMember)
                    //        {
                    //            //No action
                    //            //Already Exist in Other Team Member
                    //        }
                    //        else
                    //        {
                    //            //You need to remove it from the Provider Coverage

                    //            propertyListTheNeedToBeRemovedFromProvider.Add(propertyInfo);
                    //        }
                    //    }
                    //    Response.Write("------Removing the values-------");
                    //    Response.Write("<br/>");
                    //    RemoveSpecialistmaintenanceCompanySpecializationFromProviderCoverage(
                    //        propertyListTheNeedToBeRemovedFromProvider);
                    //    Response.Write("<br/>");

                    //    Response.Write("----------PROVIDER AFTER CHANGE-------");
                    //    Response.Write("<br/>");
                    //    GetCurrentProperties(providerCoverage.MaintenanceCompanySpecialization);
                
                
              
                    return View();
                }
                return null;
            }
            return null;
        }













        public void GetMaintenanceCompanySpecializationValue(ProviderMaintenanceProfile providerCoverage, SpecialistMaintenanceProfile specialistCoverage,
                             int providerId)
        {
            GetCurrentProperties(providerCoverage.MaintenanceCompanySpecialization);
            Response.Write("-------Getting the values---------");
            Response.Write("<br/>");

            var difference = EnumeratePropertyDifferences
                (specialistCoverage.MaintenanceCompanySpecialization,
                 providerCoverage.MaintenanceCompanySpecialization);


            var propertyInfos = difference as PropertyInfo[] ?? difference.ToArray();
            var propertyListTheNeedToBeRemovedFromProvider = new List<PropertyInfo>();
            if (propertyInfos.Count() >= 0)
            {
                foreach (var propertyInfo in propertyInfos)
                {
                    //Compare to each specialist coverage
                    //For all Specialist

                    var propertyInfoTrueforOtherMember =
                        IsPropertyInfoTrueforOtherMemberForMaintenanceCompanySpecialization(providerId,
                                                                                            propertyInfo);

                    if (propertyInfoTrueforOtherMember)
                    {
                        //No action
                        //Already Exist in Other Team Member
                    }
                    else
                    {
                        //You need to remove it from the Provider Coverage

                        propertyListTheNeedToBeRemovedFromProvider.Add(propertyInfo);
                    }
                }
                Response.Write("------Removing the values-------");
                Response.Write("<br/>");
                RemoveSpecialistmaintenanceCompanySpecializationFromProviderCoverage(
                    propertyListTheNeedToBeRemovedFromProvider);
                Response.Write("<br/>");

                Response.Write("----------PROVIDER AFTER CHANGE-------");
                Response.Write("<br/>");
                GetCurrentProperties(providerCoverage.MaintenanceCompanySpecialization);
            }
        }





        public void GetMaintenanceCompanyRepair(ProviderMaintenanceProfile providerCoverage, SpecialistMaintenanceProfile specialistCoverage,
                             int providerId)
        {
           
            var specialistMaintenanceProfileproperties = typeof(SpecialistMaintenanceProfile).GetProperties();
            var specialistProfileDictionary = new Dictionary<string, object>();
            var lookUpTypeDictionary = new Dictionary<string, Type>();
            foreach (PropertyInfo pi in specialistMaintenanceProfileproperties)
            {
                if (pi != null)
                {
                    if (pi.Name.ToString(CultureInfo.InvariantCulture)!= typeof (MaintenanceCompanyLookUp).Name.ToString(CultureInfo.InvariantCulture) &&
                        pi.Name.ToString(CultureInfo.InvariantCulture) != typeof(MaintenanceCompany).Name.ToString(CultureInfo.InvariantCulture) &&
                        pi.Name.ToString(CultureInfo.InvariantCulture) != typeof(MaintenanceProvider).Name.ToString(CultureInfo.InvariantCulture))
                    {

                        //Insert the type here
                        //if( pi.Name)
                        var currentSpecialistInstancePropertyValue =
                            typeof(SpecialistMaintenanceProfile).GetProperty(pi.Name)
                                       .GetValue(specialistCoverage, null);
                        specialistProfileDictionary.Add(pi.Name, currentSpecialistInstancePropertyValue);

                        TypeofCoverage(pi, lookUpTypeDictionary);
                    }
                }
            }

            var providerMaintenanceProfileproperties = typeof(ProviderMaintenanceProfile).GetProperties();
            var providerProfileDictionary = new Dictionary<string, object>();
            foreach (PropertyInfo pi in providerMaintenanceProfileproperties)
            {
                if (pi != null)
                {
                    if (pi.Name.ToString(CultureInfo.InvariantCulture)
                        != typeof(MaintenanceCompanyLookUp).Name.ToString(CultureInfo.InvariantCulture) &&
                        pi.Name != typeof(MaintenanceCompany).Name &&
                        pi.Name != typeof (MaintenanceProvider).Name)
                    {
                        var currentProviderInstancePropertyObject =
                            typeof (ProviderMaintenanceProfile).GetProperty(pi.Name)
                                                               .GetValue(providerCoverage, null);
                        providerProfileDictionary.Add(pi.Name, currentProviderInstancePropertyObject);

                    }
                }
            }


            // Test for equality.
            if (providerProfileDictionary.Count == specialistProfileDictionary.Count) // Require equal count.
            {
                foreach (var providerValue in providerProfileDictionary)
                {
                    object specialistValue;
                    if (specialistProfileDictionary.TryGetValue(providerValue.Key, out specialistValue))
                    {
                        Type coverageTypeObject;
                        lookUpTypeDictionary.TryGetValue(providerValue.Key, out coverageTypeObject);

                        //var currentProviderInstancePropertyObject =
                        //    typeof(SpecialistMaintenanceProfile).GetProperty(providerValue.Key)
                        //                                       .GetValue(providerCoverage, null);
                       dynamic coveragetype = typeof (SpecialistMaintenanceProfile).GetProperty(providerValue.Key).Name;
                       // var t = typeof()

                   //    var t = Convert.ChangeType(test, coveragetype);

                  //     object value1 = typeof(T).GetProperty(pi.Name).GetValue(obj1, null);


                       UpdateCoverage(providerValue, specialistValue, providerId, coverageTypeObject);
                        // Require value be equal.
                        //if (value != pair.Value)
                        //{
                        //    equal = false;
                        //    break;
                        //}
                        //else
                        //{
                        //    //Only way
                        //    //UpdateCoverage(providerProfileDictionary., specialistCoverage, providerId);
                        //}
                    }
                    else
                    {
                        // Require key be present.
                        break;
                    }

                }
            }


            //    var currentProviderInstancePropertyValue2 =
	                //pi.GetValue(providerCoverage, null);



	                //var currentSpecialistInstancePropertyValue =
	                //    typeof(SpecialistMaintenanceProfile).GetProperty(pi.Name)
	                //               .GetValue(providerCoverage, null);

	                //if (currentProviderInstancePropertyValue != null && currentSpecialistInstancePropertyValue!= null)
	                //{
	                //    UpdateCoverage(currentProviderInstancePropertyValue, currentProviderInstancePropertyValue, providerId);
	                //   // UpdateCoverage(providerCoverage, specialistCoverage, providerId);
	                //}
	                //        }
	                //    }
	                //}

	           

	        }

        private static void TypeofCoverage(PropertyInfo pi, Dictionary<string, Type> lookUpTypeDictionary)
        {
            if (pi.Name.ToString(CultureInfo.InvariantCulture) ==
                typeof (MaintenanceCompanySpecialization).Name.ToString(CultureInfo.InvariantCulture))
            {
                lookUpTypeDictionary.Add(pi.Name, typeof (MaintenanceCompanySpecialization));
            }
            if (pi.Name.ToString(CultureInfo.InvariantCulture) ==
                typeof (MaintenanceCustomService).Name.ToString(CultureInfo.InvariantCulture))
            {
                lookUpTypeDictionary.Add(pi.Name, typeof (MaintenanceCustomService));
            }
            if (pi.Name.ToString(CultureInfo.InvariantCulture) ==
                typeof (MaintenanceExterior).Name.ToString(CultureInfo.InvariantCulture))
            {
                lookUpTypeDictionary.Add(pi.Name, typeof (MaintenanceExterior));
            }
            if (pi.Name.ToString(CultureInfo.InvariantCulture) ==
                typeof (MaintenanceInterior).Name.ToString(CultureInfo.InvariantCulture))
            {
                lookUpTypeDictionary.Add(pi.Name, typeof (MaintenanceInterior));
            }
            if (pi.Name.ToString(CultureInfo.InvariantCulture) ==
                typeof (MaintenanceNewConstruction).Name.ToString(CultureInfo.InvariantCulture))
            {
                lookUpTypeDictionary.Add(pi.Name, typeof (MaintenanceNewConstruction));
            }
            if (pi.Name.ToString(CultureInfo.InvariantCulture) ==
                typeof (MaintenanceRepair).Name.ToString(CultureInfo.InvariantCulture))
            {
                lookUpTypeDictionary.Add(pi.Name, typeof (MaintenanceRepair));
            }
            if (pi.Name.ToString(CultureInfo.InvariantCulture) ==
                typeof (MaintenanceUtility).Name.ToString(CultureInfo.InvariantCulture))
            {
                lookUpTypeDictionary.Add(pi.Name, typeof (MaintenanceUtility));
            }
        }


        public void UpdateCoverage(object providerCoverage, object specialistCoverage, int providerId , Type coverageType)
        {
            Response.Write(String.Format("Getting The Property of Provider Type {0}", providerCoverage));
            Response.Write("<br/>");
            GetCurrentProperties(providerCoverage);
            Response.Write(String.Format("Getting The Property of Provider Type {0}", providerCoverage));
            Response.Write("<br/>---------");



            var difference = EnumeratePropertyDifferences
                (specialistCoverage,providerCoverage);
            var propertyInfos = difference as PropertyInfo[] ?? difference.ToArray();
            var propertyListTheNeedToBeRemovedFromProvider = new List<PropertyInfo>();
            if (propertyInfos.Count() >= 0)
            {
                foreach (var propertyInfo in propertyInfos)
                {
                    //Compare to each specialist coverage For all Specialist
                    var propertyInfoTrueforOtherMember =
                        IsPropertyInfoTrueforOtherMemberForMaintenanceRepair(providerId, propertyInfo);

                    if (propertyInfoTrueforOtherMember)
                    {
                        //No action
                        //Already Exist in Other Team Member
                    }
                    else
                    {
                        //You need to remove it from the Provider Coverage
                        propertyListTheNeedToBeRemovedFromProvider.Add(propertyInfo);
                    }
                }



                Response.Write(String.Format("Removing the Value From {0}", providerCoverage));

                RemoveSpecialistCoverageFromProviderCoverage(
                    propertyListTheNeedToBeRemovedFromProvider, coverageType);
                Response.Write(String.Format("Removing the Value From {0}", providerCoverage));
                Response.Write("<br/>-----");




                Response.Write("-------*******PROVIDER AFTER CHANGE********--------");
                Response.Write("<br/>");
                GetCurrentProperties(providerCoverage);
                Response.Write(String.Format("Getting The Property of Provider Type {0}", providerCoverage));
                Response.Write("<br/>");
            }
        }

        /// <summary>
        /// Need to Refactor
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public bool IsPropertyInfoTrueforOtherMemberForMaintenanceCompanySpecialization(int providerId, PropertyInfo propertyInfo)
        {
            var propertyInfoTrueforOtherMember = false;
            var provider = Db.MaintenanceProviderProfile.Find(providerId);
            var allSpecialistInTeam =
                Db.MaintenanceTeamAssociations.
                   Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            if (allSpecialistInTeam.Count > 0)
            {
                foreach (var specialist in allSpecialistInTeam)
                {
                    var teamMateCoverageProperty = typeof (MaintenanceCompanySpecialization).
                        GetProperty(propertyInfo.Name).
                        GetValue(GetSpecialistCoverage(specialist).MaintenanceCompanySpecialization,
                                 null);

                    if (teamMateCoverageProperty is bool)
                    {
                        var teamMateCoveragePropertyValue = (bool) teamMateCoverageProperty;
                        if (teamMateCoveragePropertyValue)
                        {
                            //Property True for other member
                            propertyInfoTrueforOtherMember = true;
                        }
                    }
                    //If doesn' exist
                    //Set the provider coverage to false
                    return propertyInfoTrueforOtherMember;
                }
            }
            return false;
        }

        public bool IsPropertyInfoTrueforOtherMemberForMaintenanceCustomService(int providerId, PropertyInfo propertyInfo)
        {
            var propertyInfoTrueforOtherMember = false;
            var provider = Db.MaintenanceProviderProfile.Find(providerId);
            var allSpecialistInTeam =
                Db.MaintenanceTeamAssociations.
                   Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            if (allSpecialistInTeam.Count > 0)
            {
                foreach (var specialist in allSpecialistInTeam)
                {
                    var teamMateCoverageProperty = typeof(MaintenanceCustomService).
                        GetProperty(propertyInfo.Name).
                        GetValue(GetSpecialistCoverage(specialist).MaintenanceCustomService,
                                 null);

                    if (teamMateCoverageProperty is bool)
                    {
                        var teamMateCoveragePropertyValue = (bool)teamMateCoverageProperty;
                        if (teamMateCoveragePropertyValue)
                        {
                            //Property True for other member
                            propertyInfoTrueforOtherMember = true;
                        }
                    }
                    //If doesn' exist
                    //Set the provider coverage to false
                    return propertyInfoTrueforOtherMember;
                }
            }
            return false;
        }

        public bool IsPropertyInfoTrueforOtherMemberForMaintenanceExterior(int providerId, PropertyInfo propertyInfo)
        {
            var propertyInfoTrueforOtherMember = false;
            var provider = Db.MaintenanceProviderProfile.Find(providerId);
            var allSpecialistInTeam =
                Db.MaintenanceTeamAssociations.
                   Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            if (allSpecialistInTeam.Count > 0)
            {
                foreach (var specialist in allSpecialistInTeam)
                {
                    var teamMateCoverageProperty = typeof(MaintenanceExterior).
                        GetProperty(propertyInfo.Name).
                        GetValue(GetSpecialistCoverage(specialist).MaintenanceExterior,
                                 null);

                    if (teamMateCoverageProperty is bool)
                    {
                        var teamMateCoveragePropertyValue = (bool)teamMateCoverageProperty;
                        if (teamMateCoveragePropertyValue)
                        {
                            //Property True for other member
                            propertyInfoTrueforOtherMember = true;
                        }
                    }
                    //If doesn' exist
                    //Set the provider coverage to false
                    return propertyInfoTrueforOtherMember;
                }
            }
            return false;
        }

        public bool IsPropertyInfoTrueforOtherMemberForMaintenanceInterior(int providerId, PropertyInfo propertyInfo)
        {
            var propertyInfoTrueforOtherMember = false;
            var provider = Db.MaintenanceProviderProfile.Find(providerId);
            var allSpecialistInTeam =
                Db.MaintenanceTeamAssociations.
                   Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            if (allSpecialistInTeam.Count > 0)
            {
                foreach (var specialist in allSpecialistInTeam)
                {
                    var teamMateCoverageProperty = typeof(MaintenanceInterior).
                        GetProperty(propertyInfo.Name).
                        GetValue(GetSpecialistCoverage(specialist).MaintenanceInterior,
                                 null);

                    if (teamMateCoverageProperty is bool)
                    {
                        var teamMateCoveragePropertyValue = (bool)teamMateCoverageProperty;
                        if (teamMateCoveragePropertyValue)
                        {
                            //Property True for other member
                            propertyInfoTrueforOtherMember = true;
                        }
                    }
                    //If doesn' exist
                    //Set the provider coverage to false
                    return propertyInfoTrueforOtherMember;
                }
            }
            return false;
        }

        public bool IsPropertyInfoTrueforOtherMemberForMaintenanceNewConstruction(int providerId, PropertyInfo propertyInfo)
        {
            var propertyInfoTrueforOtherMember = false;
            var provider = Db.MaintenanceProviderProfile.Find(providerId);
            var allSpecialistInTeam =
                Db.MaintenanceTeamAssociations.
                   Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            if (allSpecialistInTeam.Count > 0)
            {
                foreach (var specialist in allSpecialistInTeam)
                {
                    var teamMateCoverageProperty = typeof(MaintenanceNewConstruction).
                        GetProperty(propertyInfo.Name).
                        GetValue(GetSpecialistCoverage(specialist).MaintenanceNewConstruction,
                                 null);

                    if (teamMateCoverageProperty is bool)
                    {
                        var teamMateCoveragePropertyValue = (bool)teamMateCoverageProperty;
                        if (teamMateCoveragePropertyValue)
                        {
                            //Property True for other member
                            propertyInfoTrueforOtherMember = true;
                        }
                    }
                    //If doesn' exist
                    //Set the provider coverage to false
                    return propertyInfoTrueforOtherMember;
                }
            }
            return false;
        }

        public bool IsPropertyInfoTrueforOtherMemberForMaintenanceRepair(int providerId, PropertyInfo propertyInfo)
        {
            var propertyInfoTrueforOtherMember = false;
            var provider = Db.MaintenanceProviderProfile.Find(providerId);
            var allSpecialistInTeam =
                Db.MaintenanceTeamAssociations.
                   Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            if (allSpecialistInTeam.Count > 0)
            {
                foreach (var specialist in allSpecialistInTeam)
                {
                    var teamMateCoverageProperty = typeof(MaintenanceRepair).
                        GetProperty(propertyInfo.Name).
                        GetValue(GetSpecialistCoverage(specialist).MaintenanceRepair,
                                 null);

                    if (teamMateCoverageProperty is bool)
                    {
                        var teamMateCoveragePropertyValue = (bool)teamMateCoverageProperty;
                        if (teamMateCoveragePropertyValue)
                        {
                            //Property True for other member
                            propertyInfoTrueforOtherMember = true;
                        }
                    }
                    //If doesn' exist
                    //Set the provider coverage to false
                    return propertyInfoTrueforOtherMember;
                }
            }
            return false;
        }

        public bool IsPropertyInfoTrueforOtherMemberForMaintenanceUtility(int providerId, PropertyInfo propertyInfo)
        {
            var propertyInfoTrueforOtherMember = false;
            var provider = Db.MaintenanceProviderProfile.Find(providerId);
            var allSpecialistInTeam =
                Db.MaintenanceTeamAssociations.
                   Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                  .Select(x => x.SpecialistId)
                  .ToList();
            if (allSpecialistInTeam.Count > 0)
            {
                foreach (var specialist in allSpecialistInTeam)
                {
                    var teamMateCoverageProperty = typeof(MaintenanceUtility).
                        GetProperty(propertyInfo.Name).
                        GetValue(GetSpecialistCoverage(specialist).MaintenanceUtility,
                                 null);

                    if (teamMateCoverageProperty is bool)
                    {
                        var teamMateCoveragePropertyValue = (bool)teamMateCoverageProperty;
                        if (teamMateCoveragePropertyValue)
                        {
                            //Property True for other member
                            propertyInfoTrueforOtherMember = true;
                        }
                    }
                    //If doesn' exist
                    //Set the provider coverage to false
                    return propertyInfoTrueforOtherMember;
                }
            }
            return false;
        }




        public ProviderMaintenanceProfile GetProviderCoverage()
        {
            //  var providerId = UserHelper.GetProviderId();
            var providerId = 2;

            if (providerId != 0)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    return new ProviderMaintenanceProfile
                        {
                            MaintenanceProvider = Db.MaintenanceProviderProfile.Find(providerId),
                            MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
                            MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
                            MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
                            MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
                            MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
                            MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
                            MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
                            MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
                            MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId)
                        };
                }
            }
            return null;

        }

        public SpecialistMaintenanceProfile GetSpecialistCoverage(int specialistId)
        {
            const int specialistrole = 1;
            var specialistlookUp =
                Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialistId);
            if (specialistlookUp != null)
            {
                int companyId = specialistlookUp.CompanyId;

                return new SpecialistMaintenanceProfile
                    {
                        MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
                        MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
                        MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
                        MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
                        MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
                        MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
                        MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
                        MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
                        MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId)
                    };
            }
            return null;
        }

        public void GetAllSpecialistmaintenanceCompanySpecializationtoProviderCoverage()
        {
            var providerId = 2;

            if (providerId != 0)
            {
                //Get All Specialist in Team
                var provider = Db.MaintenanceProviderProfile.Find(providerId);
                var allSpecialistInTeam =
                    Db.MaintenanceTeamAssociations.
                       Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId)
                      .Select(x => x.SpecialistId)
                      .ToList();
                if (allSpecialistInTeam.Count > 0)
                {
                    foreach (var specialist in allSpecialistInTeam)
                    {

                        Response.Write("----------SPECIALIST COVERAGE------");
                        Response.Write("---------- ID = ------");
                        Response.Write(specialist);
                        Response.Write("<br/>");
                        GetCurrentProperties(GetSpecialistCoverage(specialist).MaintenanceCompanySpecialization);
                        Response.Write("<br/>");
                        Response.Write("/////////////////////////");
                        Response.Write("<br/>");
                    }
                }
            }
        }






        /// <summary>
        /// maintenanceCompanySpecialization
        /// </summary>
        /// <param name="properties"></param>
        public void AddSpecialistmaintenanceCompanySpecializationtoProviderCoverage
            (IEnumerable<PropertyInfo> properties)
        {
            //  var providerId = UserHelper.GetProviderId();
            var providerId = 2;

            if (providerId != 0)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;
                    var maintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId);

                    foreach (PropertyInfo pi in properties)
                    {
                        SetProperty(maintenanceCompanySpecialization, pi.Name, true);
                    }
                    maintenanceCompanySpecialization.NumberofEmployee += 1;
                    maintenanceCompanySpecialization.NumberofCertifitedEmplyee += 1;

                    var allSpecialistInTeam = Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == providerId ).Select(x => x.SpecialistId).ToList();
                    if (allSpecialistInTeam.Count > 1)
                    {
                        maintenanceCompanySpecialization.NumberofEmployee = allSpecialistInTeam.Count - 1;
                        maintenanceCompanySpecialization.NumberofCertifitedEmplyee -= allSpecialistInTeam.Count - 1;
                    }
                    Db.SaveChanges();
                }

            }
        }

        public void RemoveSpecialistmaintenanceCompanySpecializationFromProviderCoverage(
            IEnumerable<PropertyInfo> properties)
        {
            //  var providerId = UserHelper.GetProviderId();
            var providerId = 2;

            if (providerId != 0)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;
                    var maintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId);

                    foreach (PropertyInfo pi in properties)
                    {
                        SetProperty(maintenanceCompanySpecialization, pi.Name, false);
                    }
                    maintenanceCompanySpecialization.NumberofEmployee -= 1;
                    maintenanceCompanySpecialization.NumberofCertifitedEmplyee -= 1;
                    Db.SaveChanges();
                }

            }
        }




        public void RemoveSpecialistmaintenanceRepairFromProviderCoverage(
            IEnumerable<PropertyInfo> properties, Type maintenance)
        {
            //  var providerId = UserHelper.GetProviderId();
            var providerId = 2;

            if (providerId != 0)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var maintenanceRepair = Db.Set(maintenance).Find(companyId);
                    foreach (PropertyInfo pi in properties)
                    {
                        SetProperty(maintenanceRepair, pi.Name, false);
                    }
   
                    Db.SaveChanges();
                }

            }
        }





        public void RemoveSpecialistCoverageFromProviderCoverage(
          IEnumerable<PropertyInfo> properties, Type maintenance)
        {
            //  var providerId = UserHelper.GetProviderId();
            var providerId = 2;

            if (providerId != 0)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var maintenanceRepair = Db.Set(maintenance).Find(companyId);
                    foreach (PropertyInfo pi in properties)
                    {
                        SetProperty(maintenanceRepair, pi.Name, false);
                    }

                    Db.SaveChanges();
                }

            }
        }


                  //  var t2 = Maintenance.GetType();
                  //  if (Maintenance.IsClass)
                  //  {
                  //      var t = Activator.CreateInstance(Maintenance);
                  //      var maintenanceRepairs = new DbSet<Maintenance>;
                  //  }
                   
                  //  //var test = object.ClassType();
                  //  //var test = DbSet<i>;
                  //  var obj = (Maintenance) typeof(Maintenance).GetConstructor(
                  //BindingFlags.NonPublic | BindingFlags.Instance,
                  //null, Type.EmptyTypes, null).Invoke(null);


                  //  var users = Db.Set<(typeof(T)>();
                   // DbSet set = DbContext.Set(typeof(T));
                 //   maintenanceRepairs = DbSet<Type>;











        //MOre WORK
        //GET TYPE OF TYPE OF MaintenanceProvider
        //FOR EACH TYPE GET THE PROP

        public enum TeamCoverageOperations
        {
        Add = 1,
	    Remove = 2
        }

        public void AddSpecialistCoveragetoProviderCoverage(IEnumerable<PropertyInfo> properties)
        {
             UpdateTeamCoverage(properties, TeamCoverageOperations.Add);
        }

        public void UpdateTeamCoverage(IEnumerable<PropertyInfo> properties, TeamCoverageOperations coverageoperation)
        {
            //  var providerId = UserHelper.GetProviderId();
            var providerId = 2;

            if (providerId != 0)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    var providerMaintenanceProfile = new ProviderMaintenanceProfile
                        {
                            MaintenanceProvider = Db.MaintenanceProviderProfile.Find(providerId),
                            MaintenanceCompanyLookUp = Db.MaintenanceCompanyLookUps.Find(companyId),
                            MaintenanceCompany = Db.MaintenanceCompanies.Find(companyId),
                            MaintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId),
                            MaintenanceCustomService = Db.MaintenanceCustomServices.Find(companyId),
                            MaintenanceExterior = Db.MaintenanceExteriors.Find(companyId),
                            MaintenanceInterior = Db.MaintenanceInteriors.Find(companyId),
                            MaintenanceNewConstruction = Db.MaintenanceNewConstructions.Find(companyId),
                            MaintenanceRepair = Db.MaintenanceRepairs.Find(companyId),
                            MaintenanceUtility = Db.MaintenanceUtilities.Find(companyId)
                        };

                   // var providerMaintenanceProfileproperties = typeof(ProviderMaintenanceProfile).GetProperties();
                    //  foreach (PropertyInfo pi in providerMaintenanceProfileproperties
                    foreach (PropertyInfo pi in properties)
                    {
                        if (pi != null)
                        {
                            if (pi.GetType() != typeof(MaintenanceCompanyLookUp) ||
                                pi.GetType() != typeof(MaintenanceCompany) ||
                                pi.GetType() != typeof(MaintenanceProvider))
                            {

                                var currentInstancePropertyValue =
                                    typeof(ProviderMaintenanceProfile).GetProperty(pi.Name)
                                                                       .GetValue(providerMaintenanceProfile, null);
                                if (currentInstancePropertyValue != null)
                                {
                                    SetProperty(currentInstancePropertyValue, pi.Name, true);
                                }
                            }
                        }
                    }
                    var maintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId);
                    if (coverageoperation == TeamCoverageOperations.Add)
                    {
                        maintenanceCompanySpecialization.NumberofEmployee += 1;
                        maintenanceCompanySpecialization.NumberofCertifitedEmplyee += 1;
                    }
                    else
                    {
                        maintenanceCompanySpecialization.NumberofEmployee -= 1;
                        maintenanceCompanySpecialization.NumberofCertifitedEmplyee -= 1;
                    }

                    Db.SaveChanges();
                }
            }
        }

        public void RemoveSpecialistmaintenanceCompanyCustomServiceFromProviderCoverage(IEnumerable<PropertyInfo> properties)
        {
            //  var providerId = UserHelper.GetProviderId();
            var providerId = 2;

            if (providerId != 0)
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == providerId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;
                    var maintenanceCompanyCustomService = Db.MaintenanceCustomServices.Find(companyId);

                    foreach (PropertyInfo pi in properties)
                    {
                        SetProperty(maintenanceCompanyCustomService, pi.Name, false);
                    }
                    //maintenanceCompanyCustomService.NumberofEmployee -= 1;
                    //maintenanceCompanyCustomService.NumberofCertifitedEmplyee -= 1;
                    Db.SaveChanges();
                }

            }
        }






        public class SpecialistZone
        {
            public string Zone { get; set; }

            public string Zipcode { get; set; }

            public string Country { get; set; }

            public int MaitenanceProviderID { get; set; }
        }
    }
}





        //public ActionResult Index()
        //{

        //    var specialistsZone = new List<SpecialistZone>();
        //    var allTeamAssociations = Db.MaintenanceTeamAssociations.Select(x => x).ToList();

        //    foreach (var provider in allTeamAssociations)
        //    {


        //        var specialistZone = GetSpecialistZone(provider.SpecialistId);
        //        var specialistCompanyZone = GetSpecialistCompanyZone(provider.SpecialistId);

        //        if (specialistZone != null)
        //        {
        //            specialistsZone.Add(new SpecialistZone
        //            {
        //                Country = specialistZone.Country,
        //                Zone = specialistZone.Zone,
        //                Zipcode = specialistZone.Zipcode,
        //                MaitenanceProviderID = provider.MaintenanceProviderId
        //            });
        //        }
        //        if (specialistCompanyZone == null) continue;
        //        if (specialistZone != specialistCompanyZone)
        //            specialistsZone.Add(new SpecialistZone
        //            {
        //                Zone = specialistCompanyZone.Zone,
        //                Country = specialistCompanyZone.Country,
        //                Zipcode = specialistCompanyZone.Zipcode,
        //                MaitenanceProviderID = provider.MaintenanceProviderId
        //            });
        //    }

        //  //  var specialistcount = allTeamAssociations.Count();

        //    //Provider Zone
        //    //From Table
        //    //Keep count of how many availabe


        //    //Add them to the Provider Table

        //    foreach (var zone in specialistsZone)
        //    {
        //        Db.MaintenanceProviderZones.Add(new MaintenanceProviderZone
        //            {
        //                MaintenanceProviderId = zone.MaitenanceProviderID,
        //                CityName = zone.Zone,
        //                Country = zone.Country,
        //                TeamMemberCount = 0,
        //                ZipCode = zone.Zipcode
        //            });

        //    }

        //    Db.SaveChanges();
        //    return View();
        //}


//public ActionResult Index()
        //{
        //    //var unit = db.Units.FirstOrDefault(x => x.UnitId == 26);
        //    //return View(unit);



        //    //Spe 8 id:10
        //    //spe10 id:12

        //    //


        //    //All i have from registration is

        //    //Name
        //    //EmailAddress

        //    //Passwod, Role

        //    var specialist = db.Specialists.FirstOrDefault(x => x.SpecialistId == 10);




        //    if (specialist != null)
        //    {
        //        var smp = new SpecialistMaintenanceProfile()
        //            {
        //                MaintenanceCompanyLookUp = { Role = 1, UserId = 10 },
        //                MaintenanceCompany =
        //                    {
        //                        Name = specialist.LastName + "," + specialist.FirstName,
        //                        EmailAddress = specialist.EmailAddress,
        //                        GUID = specialist.GUID
        //                    }
        //            };

        //        //if (ModelState.IsValid)
        //        //{
        //        //    try
        //        //    {
        //        //        smp.Save(smp);
        //        //    }
        //        //    catch (Exception e)
        //        //    {

        //        //        throw new Exception(e.InnerException.Message);
        //        //    }

        //        //}
        //    }






        //    //testing the creation and the identity for company id
        //    //When success ; go back to regisrtation and them to
        //    //Professional
        //    //Specialist




        //    //Then do the complete profile for both roles
        //    //Then create the table for profile completion.


        //    return View();
        //}







        //--------------------------------------------------------------------------------------------------------------------------------------------------------//
        //public ActionResult Index()
        //{
        //    var providerId = 2;
        //    if (providerId != 0)
        //    {
        //        var newMaintenanceCompanyLookUp = new MaintenanceCompanyLookUp
        //            {
        //                UserId = providerId,
        //                Role = 2
        //            };
        //        _db.MaintenanceCompanyLookUps.Add(newMaintenanceCompanyLookUp);
        //        _db.SaveChanges();

        //        var providerCompanyId = newMaintenanceCompanyLookUp.CompanyId;
        //        var newMaintenanceCompany = new MaintenanceCompany
        //            {
        //                CompanyId = providerCompanyId,
        //                Name = "Provider5",
        //                EmailAddress = "haraissia@sosland.com",
        //                GoogleMap = "USA",
        //                Country = "US",
        //                //   CountryCode = "US"
        //            };
        //        var newMaintenanceCompanySpecialization = new MaintenanceCompanySpecialization
        //            {
        //                CompanyId = providerCompanyId,
        //                NumberofEmployee = 1,
        //                NumberofCertifitedEmplyee = 1,
        //                IsInsured = true,
        //                Rate = 50,
        //                CurrencyID = 1,
        //                Currency = "USD"
        //            };
        //        var newMaintenanceCustomService = new MaintenanceCustomService
        //            {
        //                CompanyId = providerCompanyId
        //            };

        //        var newMaintenanceExterior = new MaintenanceExterior
        //            {
        //                CompanyId = providerCompanyId
        //            };
        //        var newMaintenanceInterior = new MaintenanceInterior
        //            {
        //                CompanyId = providerCompanyId
        //            };
        //        var newMaintenanceNewConstruction = new MaintenanceNewConstruction
        //            {
        //                CompanyId = providerCompanyId
        //            };
        //        var newMaintenanceRepair = new MaintenanceRepair
        //            {
        //                CompanyId = providerCompanyId
        //            };
        //        var newMaintenanceUtility = new MaintenanceUtility
        //            {
        //                CompanyId = providerCompanyId
        //            };
        //        var providerwork = new ProviderWork
        //            {
        //                PhotoPath = "./../images/dotimages/home-handyman-projects.jpg",
        //                ProviderId = providerCompanyId
        //            };

        //        _db.MaintenanceCompanies.Add(newMaintenanceCompany);
        //        _db.MaintenanceCompanySpecializations.Add(newMaintenanceCompanySpecialization);
        //        _db.MaintenanceCustomServices.Add(newMaintenanceCustomService);
        //        _db.MaintenanceExteriors.Add(newMaintenanceExterior);
        //        _db.MaintenanceInteriors.Add(newMaintenanceInterior);
        //        _db.MaintenanceNewConstructions.Add(newMaintenanceNewConstruction);
        //        _db.MaintenanceRepairs.Add(newMaintenanceRepair);
        //        _db.MaintenanceUtilities.Add(newMaintenanceUtility);
        //        _db.ProviderWorks.Add(providerwork);
        //        _db.SaveChanges();

        //    }


        //    return View();
        //}


        //--------------------------------------------------------------------------------------------------------------------------------------------------------//

//var result2 = ReflectionHelper.Compare(specialistCoverage.MaintenanceCompanySpecialization,
//                                       providerCoverage.MaintenanceCompanySpecialization, "Id",
//                                       "AnotherProp");


//foreach (var t2 in result2)
//{
//    Response.Write(t2);
//    Response.Write("<br/>");
//}





//  Response.Write(EnumeratePropertyDifferences(providerCoverage.MaintenanceCompanySpecialization,
//specialistCoverage.MaintenanceCompanySpecialization));
//var data = new object();
//  var fields = data.GetType().GetFields().Where(x => x.FieldType == false.GetType());
//var fields = specialistCoverage.MaintenanceCompanySpecialization.GetFields();
//foreach (var f in fields)
//{
//    var stringtest = "Type" + f.FieldType + "Name" + f.Name + " = " + f.GetValue(data) + "\r\n";

//    Response.Write(stringtest);
//}



//    foreach (var bool_field in specialistCoverage.MaintenanceCompanySpecialization.GetType()
//                                                 .GetProperties()
//                                                 .Where(x => x.PropertyType == false.GetType()))

//    {
//        var test = bool_field.
//            var
//        p = GetType().GetField(bool_field).GetValue(this);
//    }

//    var t = specialistCoverage.MaintenanceCompanySpecialization.GetType().GetFields();
//    {
//        foreach (var x in t)
//        {
//            if (t.FieldType == typeof (bool))
//            {
//                if (t.GetValue(0) == (object) true)
//                {

//                }
//            }
//        }
//    }
//}



//foreach (var boolField in specialistCoverage.MaintenanceCompanySpecialization.GetType()
//                                            .GetProperties()
//                                            .Where(x => x.PropertyType == false.GetType()))
//{
//    Response.Write(boolField.ToString());
//    Response.Write("<br/>");
//}



                    //    Response.Write("-------Getting the properties---------");
                    //Response.Write("<br/>");
                    //foreach (var t in result)
                    //{
                    //    Response.Write(t);
                    //    Response.Write("<br/>");
                    //}