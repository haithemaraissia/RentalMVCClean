using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeGarages
    { 
       public List<Garage> MyGarages;

       public FakeGarages()
        {
            InitializeGarageList();
        }

       public void InitializeGarageList()
        {
            MyGarages = new List<Garage> {
                FirstGarage(), 
                SecondGarage(),
                ThirdGarage()
            };
        }

       public Garage FirstGarage()
        {

            var firstGarage = new Garage {

                 GarageID = new Int32()
,
                 GarageValue = null
    
 };

            return firstGarage;
        }

       public Garage SecondGarage()
        {

            var secondGarage = new Garage {

                 GarageID = new Int32()
,
                 GarageValue = null
        
 };

            return secondGarage;
        }

       public Garage ThirdGarage()
        {

            var thirdGarage = new Garage {

                 GarageID = new Int32()
,
                 GarageValue = null
 
 };

            return thirdGarage;
        }

        ~FakeGarages()
        {
            MyGarages = null;
        }
    }
}


    