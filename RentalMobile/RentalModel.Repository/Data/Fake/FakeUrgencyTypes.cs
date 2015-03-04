using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUrgencyType
    { 
       public List<UrgencyType> MyUrgencyTypes;

       public FakeUrgencyType()
        {
            InitializeUrgencyTypeList();
        }

       public void InitializeUrgencyTypeList()
        {
            MyUrgencyTypes = new List<UrgencyType> {
                FirstUrgencyType(), 
                SecondUrgencyType(),
                ThirdUrgencyType()
            };
        }

       public UrgencyType FirstUrgencyType()
        {

            var firstUrgencyType = new UrgencyType {

                 UrgencyTypeID = new Int32()
,
                 UrgencyType1 = null,
                 LCID = new Int32()
,
//Skipping MaintenanceOrder Collection

    
 };

            return firstUrgencyType;
        }

       public UrgencyType SecondUrgencyType()
        {

            var secondUrgencyType = new UrgencyType {

                 UrgencyTypeID = new Int32()
,
                 UrgencyType1 = null,
                 LCID = new Int32()
,
//Skipping MaintenanceOrder Collection

        
 };

            return secondUrgencyType;
        }

       public UrgencyType ThirdUrgencyType()
        {

            var thirdUrgencyType = new UrgencyType {

                 UrgencyTypeID = new Int32()
,
                 UrgencyType1 = null,
                 LCID = new Int32()
,
//Skipping MaintenanceOrder Collection

 
 };

            return thirdUrgencyType;
        }

        ~FakeUrgencyType()
        {
            MyUrgencyTypes = null;
        }
    }
}


    