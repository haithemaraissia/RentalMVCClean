using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeHeating
    { 
       public List<Heating> MyHeatings;

       public FakeHeating()
        {
            InitializeHeatingList();
        }

       public void InitializeHeatingList()
        {
            MyHeatings = new List<Heating> {
                FirstHeating(), 
                SecondHeating(),
                ThirdHeating()
            };
        }

       public Heating FirstHeating()
        {

            var firstHeating = new Heating {

                 HeatingID = new Int32()
,
                 HeatingValue = null
    
 };

            return firstHeating;
        }

       public Heating SecondHeating()
        {

            var secondHeating = new Heating {

                 HeatingID = new Int32()
,
                 HeatingValue = null
        
 };

            return secondHeating;
        }

       public Heating ThirdHeating()
        {

            var thirdHeating = new Heating {

                 HeatingID = new Int32()
,
                 HeatingValue = null
 
 };

            return thirdHeating;
        }

        ~FakeHeating()
        {
            MyHeatings = null;
        }
    }
}


    