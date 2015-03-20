using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeCurrencys
    { 
       public List<Currency> MyCurrencys;

       public FakeCurrencys()
        {
            InitializeCurrencyList();
        }

       public void InitializeCurrencyList()
        {
            MyCurrencys = new List<Currency> {
                FirstCurrency(), 
                SecondCurrency(),
                ThirdCurrency()
            };
        }

       public Currency FirstCurrency()
        {

            var firstCurrency = new Currency {

                 CurrencyID = 1
,
                 CurrencyValue = "US"
    
 };

            return firstCurrency;
        }

       public Currency SecondCurrency()
        {

            var secondCurrency = new Currency {

                 CurrencyID = new Int32()
,
                 CurrencyValue = null
        
 };

            return secondCurrency;
        }

       public Currency ThirdCurrency()
        {

            var thirdCurrency = new Currency {

                 CurrencyID = new Int32()
,
                 CurrencyValue = null
 
 };

            return thirdCurrency;
        }

        ~FakeCurrencys()
        {
            MyCurrencys = null;
        }
    }
}


    