using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitPricings
    { 
       public List<UnitPricing> MyUnitPricings;

       public FakeUnitPricings()
        {
            InitializeUnitPricingList();
        }

       public void InitializeUnitPricingList()
        {
            MyUnitPricings = new List<UnitPricing> {
                FirstUnitPricing(), 
                SecondUnitPricing(),
                ThirdUnitPricing()
            };
        }

       public UnitPricing FirstUnitPricing()
        {

            var firstUnitPricing = new UnitPricing {

                 UnitId = new Int32()
,
                 Rent = new Double(),
                 CurrencyId = new Int32(),
                 AvailableDate = new DateTime(),
                 Deposit = new Double(),
                 ApplicationFee = new Double(),
                 Section_8_Eligible = new Boolean(),
                 Unit = new Unit()

    
 };

            return firstUnitPricing;
        }

       public UnitPricing SecondUnitPricing()
        {

            var secondUnitPricing = new UnitPricing {

                 UnitId = new Int32()
,
                 Rent = new Double(),
                 CurrencyId = new Int32(),
                 AvailableDate = new DateTime(),
                 Deposit = new Double(),
                 ApplicationFee = new Double(),
                 Section_8_Eligible = new Boolean(),
                 Unit = new Unit()

        
 };

            return secondUnitPricing;
        }

       public UnitPricing ThirdUnitPricing()
        {

            var thirdUnitPricing = new UnitPricing {

                 UnitId = new Int32()
,
                 Rent = new Double(),
                 CurrencyId = new Int32(),
                 AvailableDate = new DateTime(),
                 Deposit = new Double(),
                 ApplicationFee = new Double(),
                 Section_8_Eligible = new Boolean(),
                 Unit = new Unit()

 
 };

            return thirdUnitPricing;
        }

        ~FakeUnitPricings()
        {
            MyUnitPricings = null;
        }
    }
}


    