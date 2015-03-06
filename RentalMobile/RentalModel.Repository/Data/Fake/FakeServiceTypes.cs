using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeServiceTypes
    { 
       public List<ServiceType> MyServiceTypes;

       public FakeServiceTypes()
        {
            InitializeServiceTypeList();
        }

       public void InitializeServiceTypeList()
        {
            MyServiceTypes = new List<ServiceType> {
                FirstServiceType(), 
                SecondServiceType(),
                ThirdServiceType()
            };
        }

       public ServiceType FirstServiceType()
        {

            var firstServiceType = new ServiceType {

                 ServiceTypeID = new Int32()
,
                 ServiceType1 = null,
                 LCID = new Int32()
,
//Skipping MaintenanceOrder Collection

    
 };

            return firstServiceType;
        }

       public ServiceType SecondServiceType()
        {

            var secondServiceType = new ServiceType {

                 ServiceTypeID = new Int32()
,
                 ServiceType1 = null,
                 LCID = new Int32()
,
//Skipping MaintenanceOrder Collection

        
 };

            return secondServiceType;
        }

       public ServiceType ThirdServiceType()
        {

            var thirdServiceType = new ServiceType {

                 ServiceTypeID = new Int32()
,
                 ServiceType1 = null,
                 LCID = new Int32()
,
//Skipping MaintenanceOrder Collection

 
 };

            return thirdServiceType;
        }

        ~FakeServiceTypes()
        {
            MyServiceTypes = null;
        }
    }
}


    