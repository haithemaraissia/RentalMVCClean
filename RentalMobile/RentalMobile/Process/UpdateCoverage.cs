using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalMobile.Process
{
    public class UpdateCoverage
    {
        public RentalContext Db = new RentalContext();
        public int ProviderId { get; set; }
        public int SpecialistId { get; set; }

        public UpdateCoverage(int providerId, int specialistId)
        {
            ProviderId = providerId;
            SpecialistId = specialistId;
        }

        public ProviderMaintenanceProfile GetProviderCoverage()
        {
            {
                const int providerrole = 2;
                var lookUp =
                    Db.MaintenanceCompanyLookUps.FirstOrDefault(
                        x => x.Role == providerrole && x.UserId == ProviderId);
                if (lookUp != null)
                {
                    int companyId = lookUp.CompanyId;

                    return new ProviderMaintenanceProfile
                        {
                            MaintenanceProvider = Db.MaintenanceProviders.Find(ProviderId),
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

        public SpecialistMaintenanceProfile GetSpecialistCoverage()
        {
            const int specialistrole = 1;
            var specialistlookUp =
                Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == SpecialistId);
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

        public SpecialistMaintenanceProfile GetSpecialistByIdCoverage(int specialistID)
        {
            const int specialistrole = 1;
            var specialistlookUp =
                Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == SpecialistId);
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

        public bool GetCurrentProperty<T>(T objectInstance, Type objectType, PropertyInfo propertyInfo)
        {
            var properties = objectType.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                if (pi.Name == propertyInfo.Name)
                {
                    return (bool)objectType.GetProperty(pi.Name).GetValue(objectInstance, null);
                }
            }
            return false;
        }

        public IEnumerable<PropertyInfo> EnumeratePropertyDifferences<T>(T obj1, T obj2, Type objectType)
        {
            var properties = objectType.GetProperties();
            var propertyList = new List<PropertyInfo>();
            foreach (PropertyInfo pi in properties)
            {
                object value1 = objectType.GetProperty(pi.Name).GetValue(obj1, null);
                object value2 = objectType.GetProperty(pi.Name).GetValue(obj2, null);

                if (value1 != value2 && (value1 == null || !value1.Equals(value2)))
                {
                    if (value1 is bool && value2 is bool)
                    {
                        var value2Bool = (bool)value2;
                        var value1Bool = (bool)value1;
                        if (value1Bool && value2Bool == false)
                        {
                            propertyList.Add(pi);
                        }
                    }
                }
            }
            return propertyList;
        }

        public IEnumerable<PropertyInfo> EnumeratePropertyWithTrueValue<T>(T obj1, Type objectType)
        {
            var properties = objectType.GetProperties();
            var propertyList = new List<PropertyInfo>();
            foreach (PropertyInfo pi in properties)
            {
                object value1 = objectType.GetProperty(pi.Name).GetValue(obj1, null);

                if (value1 == null || !(value1 is bool)) continue;
                var value1Bool = (bool)value1;
                if (value1Bool)
                {
                    propertyList.Add(pi);
                }
            }
            return propertyList;
        }

        public void SetProperty(object instance, string propertyName, object newValue)
        {
            Type type = instance.GetType();
            if (type.BaseType != null)
            {
                PropertyInfo prop = type.BaseType.GetProperty(propertyName);
                prop.SetValue(instance, newValue, null);
            }
        }

        public bool IsPropertyInfoTrueforOtherMemberInTheTeam(PropertyInfo propertyInfo, Type coverageType, object coverageValue)
        {
            var propertyInfoTrueforOtherMember = false;
            var provider = Db.MaintenanceProviders.Find(ProviderId);
            var allSpecialistInTeam = Db.MaintenanceTeamAssociations.
                Where(x => x.MaintenanceProviderId == provider.MaintenanceProviderId && x.SpecialistId != SpecialistId).Select(x => x.SpecialistId).ToList();
            if (allSpecialistInTeam.Count > 0)
            {
                foreach (var specialist in allSpecialistInTeam)
                {
                    const int specialistrole = 1;
                    var lookUp = Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == specialistrole && x.UserId == specialist);
                    if (lookUp != null)
                    {
                        int companyId = lookUp.CompanyId;
                        var maintenanceCoverage = Db.Set(coverageType).Find(companyId);
                        if (maintenanceCoverage != null)
                        {
                            var teamMateCoverageProperty = GetCurrentProperty(maintenanceCoverage, coverageType,
                                                                              propertyInfo);
                            {
                                var teamMateCoveragePropertyValue = teamMateCoverageProperty;
                                if (teamMateCoveragePropertyValue)
                                {
                                    propertyInfoTrueforOtherMember = true;
                                }
                            }
                            return propertyInfoTrueforOtherMember;
                        }
                    }
                }
            }
            return false;
        }

        public void RemoveSpecialistCoverageFromProviderCoverage(IEnumerable<PropertyInfo> properties, Type maintenance)
        {
            const int providerrole = 2;
            var lookUp = Db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.Role == providerrole && x.UserId == ProviderId);
            if (lookUp != null)
            {
                int companyId = lookUp.CompanyId;
                var maintenanceCoverage = Db.Set(maintenance).Find(companyId);
                foreach (PropertyInfo pi in properties)
                {
                    SetProperty(maintenanceCoverage, pi.Name, false);
                }

                var maintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId);
                var allSpecialistInTeam = Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == ProviderId).Select(x => x.SpecialistId).ToList();
                if (allSpecialistInTeam.Count > 1)
                {
                    maintenanceCompanySpecialization.NumberofEmployee = allSpecialistInTeam.Count - 1;
                    maintenanceCompanySpecialization.NumberofCertifitedEmplyee = allSpecialistInTeam.Count - 1;
                }
                Db.SaveChanges();
            }
        }

        public void AddSpecialistCoverageFromProviderCoverage(IEnumerable<PropertyInfo> properties, Type maintenance)
        {
            const int providerrole = 2;
            var lookUp =
                Db.MaintenanceCompanyLookUps.FirstOrDefault(
                    x => x.Role == providerrole && x.UserId == ProviderId);
            if (lookUp != null)
            {
                int companyId = lookUp.CompanyId;
                var maintenanceCoverage = Db.Set(maintenance).Find(companyId);

                foreach (PropertyInfo pi in properties)
                {
                    if (pi != null)
                    {
                        if (pi.GetType() != typeof(MaintenanceCompanyLookUp) ||
                            pi.GetType() != typeof(MaintenanceCompany) ||
                            pi.GetType() != typeof(MaintenanceProvider))
                        {
                            if (maintenanceCoverage != null)
                            {
                                SetProperty(maintenanceCoverage, pi.Name, true);
                            }

                        }
                    }
                }
                var allSpecialistInTeam = Db.MaintenanceTeamAssociations.Where(x => x.MaintenanceProviderId == ProviderId).Select(x => x.SpecialistId).ToList();
                var maintenanceCompanySpecialization = Db.MaintenanceCompanySpecializations.Find(companyId);
                if (allSpecialistInTeam.Count > 0)
                {
                    maintenanceCompanySpecialization.NumberofEmployee = allSpecialistInTeam.Count + 1;
                    maintenanceCompanySpecialization.NumberofCertifitedEmplyee = allSpecialistInTeam.Count + 1;
                }
                Db.SaveChanges();
            }
        }

        public void RemoveCoverageFromTeam(object specialistCoverage, object providerCoverage, Type coverageType)
        {
            if (specialistCoverage == null || providerCoverage == null || coverageType == null) return;
            var difference = EnumeratePropertyWithTrueValue(specialistCoverage, coverageType);
            var propertyInfos = difference as PropertyInfo[] ?? difference.ToArray();
            var propertyListTheNeedToBeRemovedFromProvider = new List<PropertyInfo>();
            if (propertyInfos.Count() >= 0)
            {
                foreach (var propertyInfo in propertyInfos)
                {
                    var propertyInfoTrueforOtherMember = IsPropertyInfoTrueforOtherMemberInTheTeam(propertyInfo, coverageType, specialistCoverage);

                    if (!propertyInfoTrueforOtherMember)
                    {
                        propertyListTheNeedToBeRemovedFromProvider.Add(propertyInfo);
                    }
                }
                RemoveSpecialistCoverageFromProviderCoverage(propertyListTheNeedToBeRemovedFromProvider, coverageType);
            }
        }

        public void AddCoverageToTeam(object specialistCoverage, object providerCoverage, Type coverageType)
        {
            if (specialistCoverage == null || providerCoverage == null || coverageType == null) return;
            var difference = EnumeratePropertyDifferences(specialistCoverage, providerCoverage, coverageType);
            var differenceList = difference as IList<PropertyInfo> ?? difference.ToList();
            var propertyInfos = difference as PropertyInfo[] ?? differenceList.ToArray();
            if (propertyInfos.Count() >= 0)
            {
                AddSpecialistCoverageFromProviderCoverage(differenceList, coverageType);
            }
        }

        public void RemoveAllCoverageFromSpecialistToTeam()
        {
            if (GetSpecialistCoverage() == null || GetProviderCoverage() == null) return;
            RemoveCoverageFromTeam(GetSpecialistCoverage().MaintenanceCompanySpecialization, GetProviderCoverage().MaintenanceCompanySpecialization, typeof(MaintenanceCompanySpecialization));
            RemoveCoverageFromTeam(GetSpecialistCoverage().MaintenanceCustomService, GetProviderCoverage().MaintenanceCustomService, typeof(MaintenanceCustomService));
            RemoveCoverageFromTeam(GetSpecialistCoverage().MaintenanceExterior, GetProviderCoverage().MaintenanceExterior, typeof(MaintenanceExterior));
            RemoveCoverageFromTeam(GetSpecialistCoverage().MaintenanceInterior, GetProviderCoverage().MaintenanceInterior, typeof(MaintenanceInterior));
            RemoveCoverageFromTeam(GetSpecialistCoverage().MaintenanceNewConstruction, GetProviderCoverage().MaintenanceNewConstruction, typeof(MaintenanceNewConstruction));
            RemoveCoverageFromTeam(GetSpecialistCoverage().MaintenanceRepair, GetProviderCoverage().MaintenanceRepair, typeof(MaintenanceRepair));
            RemoveCoverageFromTeam(GetSpecialistCoverage().MaintenanceUtility, GetProviderCoverage().MaintenanceUtility, typeof(MaintenanceUtility));
        }

        public void AddAllCoverageFromSpecialistToTeam()
        {
            if (GetSpecialistCoverage() == null || GetProviderCoverage() == null) return;
            AddCoverageToTeam(GetSpecialistCoverage().MaintenanceCompanySpecialization, GetProviderCoverage().MaintenanceCompanySpecialization, typeof(MaintenanceCompanySpecialization));
            AddCoverageToTeam(GetSpecialistCoverage().MaintenanceCustomService, GetProviderCoverage().MaintenanceCustomService, typeof(MaintenanceCustomService));
            AddCoverageToTeam(GetSpecialistCoverage().MaintenanceExterior, GetProviderCoverage().MaintenanceExterior, typeof(MaintenanceExterior));
            AddCoverageToTeam(GetSpecialistCoverage().MaintenanceInterior, GetProviderCoverage().MaintenanceInterior, typeof(MaintenanceInterior));
            AddCoverageToTeam(GetSpecialistCoverage().MaintenanceNewConstruction, GetProviderCoverage().MaintenanceNewConstruction, typeof(MaintenanceNewConstruction));
            AddCoverageToTeam(GetSpecialistCoverage().MaintenanceRepair, GetProviderCoverage().MaintenanceRepair, typeof(MaintenanceRepair));
            AddCoverageToTeam(GetSpecialistCoverage().MaintenanceUtility, GetProviderCoverage().MaintenanceUtility, typeof(MaintenanceUtility));
        }








        public void CleanOutCoverageFromProvider( object providerCoverage, Type coverageType)
        {
            if (providerCoverage == null || coverageType == null) return;
            var difference = EnumeratePropertyWithTrueValue(providerCoverage, coverageType);
            var propertyInfos = difference as PropertyInfo[] ?? difference.ToArray();
            if (propertyInfos.Count() < 0) return;
            foreach (PropertyInfo pi in propertyInfos)
            {
                SetProperty(providerCoverage, pi.Name, false);
            }
            Db.SaveChanges();
        }

        public void CleanOutProvider()
        {
            if (GetProviderCoverage() == null) return;
            CleanOutCoverageFromProvider(GetProviderCoverage().MaintenanceCompanySpecialization, typeof(MaintenanceCompanySpecialization));
            CleanOutCoverageFromProvider(GetProviderCoverage().MaintenanceCustomService, typeof(MaintenanceCustomService));
            CleanOutCoverageFromProvider(GetProviderCoverage().MaintenanceExterior, typeof(MaintenanceExterior));
            CleanOutCoverageFromProvider(GetProviderCoverage().MaintenanceInterior, typeof(MaintenanceInterior));
            CleanOutCoverageFromProvider(GetProviderCoverage().MaintenanceNewConstruction, typeof(MaintenanceNewConstruction));
            CleanOutCoverageFromProvider(GetProviderCoverage().MaintenanceRepair, typeof(MaintenanceRepair));
            CleanOutCoverageFromProvider(GetProviderCoverage().MaintenanceUtility, typeof(MaintenanceUtility));
        }

    }
}