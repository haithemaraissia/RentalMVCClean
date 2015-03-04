using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceProviderZone
    { 
       public List<MaintenanceProviderZone> MyMaintenanceProviderZones;

       public FakeMaintenanceProviderZone()
        {
            InitializeMaintenanceProviderZoneList();
        }

       public void InitializeMaintenanceProviderZoneList()
        {
            MyMaintenanceProviderZones = new List<MaintenanceProviderZone> {
                FirstMaintenanceProviderZone(), 
                SecondMaintenanceProviderZone(),
                ThirdMaintenanceProviderZone()
            };
        }

       public MaintenanceProviderZone FirstMaintenanceProviderZone()
        {

            var firstMaintenanceProviderZone = new MaintenanceProviderZone {

                 MaintenanceProviderZoneId = new Int32()
,
                 MaintenanceProviderId = new Int32()
,
                 CityName = null,
                 Country = null,
                 ZipCode = null,
                 TeamMemberCount = new Int32()
    
 };

            return firstMaintenanceProviderZone;
        }

       public MaintenanceProviderZone SecondMaintenanceProviderZone()
        {

            var secondMaintenanceProviderZone = new MaintenanceProviderZone {

                 MaintenanceProviderZoneId = new Int32()
,
                 MaintenanceProviderId = new Int32()
,
                 CityName = null,
                 Country = null,
                 ZipCode = null,
                 TeamMemberCount = new Int32()
        
 };

            return secondMaintenanceProviderZone;
        }

       public MaintenanceProviderZone ThirdMaintenanceProviderZone()
        {

            var thirdMaintenanceProviderZone = new MaintenanceProviderZone {

                 MaintenanceProviderZoneId = new Int32()
,
                 MaintenanceProviderId = new Int32()
,
                 CityName = null,
                 Country = null,
                 ZipCode = null,
                 TeamMemberCount = new Int32()
 
 };

            return thirdMaintenanceProviderZone;
        }

        ~FakeMaintenanceProviderZone()
        {
            MyMaintenanceProviderZones = null;
        }
    }
}


    