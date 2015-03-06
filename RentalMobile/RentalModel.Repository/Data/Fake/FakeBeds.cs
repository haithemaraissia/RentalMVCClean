using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeBeds
    { 
       public List<Bed> MyBeds;

       public FakeBeds()
        {
            InitializeBedList();
        }

       public void InitializeBedList()
        {
            MyBeds = new List<Bed> {
                FirstBed(), 
                SecondBed(),
                ThirdBed()
            };
        }

       public Bed FirstBed()
        {

            var firstBed = new Bed {

                 BedID = new Int32()
,
                 BedValue = null
    
 };

            return firstBed;
        }

       public Bed SecondBed()
        {

            var secondBed = new Bed {

                 BedID = new Int32()
,
                 BedValue = null
        
 };

            return secondBed;
        }

       public Bed ThirdBed()
        {

            var thirdBed = new Bed {

                 BedID = new Int32()
,
                 BedValue = null
 
 };

            return thirdBed;
        }

        ~FakeBeds()
        {
            MyBeds = null;
        }
    }
}


    