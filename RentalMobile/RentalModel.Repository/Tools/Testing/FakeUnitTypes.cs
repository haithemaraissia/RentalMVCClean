using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitType
    { 
       public List<UnitType> MyUnitTypes;

       public FakeUnitType()
        {
            InitializeUnitTypeList();
        }

       public void InitializeUnitTypeList()
        {
            MyUnitTypes = new List<UnitType> {
                FirstUnitType(), 
                SecondUnitType(),
                ThirdUnitType()
            };
        }

       public UnitType FirstUnitType()
        {

            var firstUnitType = new UnitType {

                 TypeID = new Int32()
,
                 TypeValue = null
    
 };

            return firstUnitType;
        }

       public UnitType SecondUnitType()
        {

            var secondUnitType = new UnitType {

                 TypeID = new Int32()
,
                 TypeValue = null
        
 };

            return secondUnitType;
        }

       public UnitType ThirdUnitType()
        {

            var thirdUnitType = new UnitType {

                 TypeID = new Int32()
,
                 TypeValue = null
 
 };

            return thirdUnitType;
        }

        ~FakeUnitType()
        {
            MyUnitTypes = null;
        }
    }
}


    