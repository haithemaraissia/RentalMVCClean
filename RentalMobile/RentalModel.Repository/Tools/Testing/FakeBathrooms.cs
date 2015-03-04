using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeBathroom
    { 
       public List<Bathroom> MyBathrooms;

       public FakeBathroom()
        {
            InitializeBathroomList();
        }

       public void InitializeBathroomList()
        {
            MyBathrooms = new List<Bathroom> {
                FirstBathroom(), 
                SecondBathroom(),
                ThirdBathroom()
            };
        }

       public Bathroom FirstBathroom()
        {

            var firstBathroom = new Bathroom {

                 BathroomID = new Int32()
,
                 BathroomValue = null
    
 };

            return firstBathroom;
        }

       public Bathroom SecondBathroom()
        {

            var secondBathroom = new Bathroom {

                 BathroomID = new Int32()
,
                 BathroomValue = null
        
 };

            return secondBathroom;
        }

       public Bathroom ThirdBathroom()
        {

            var thirdBathroom = new Bathroom {

                 BathroomID = new Int32()
,
                 BathroomValue = null
 
 };

            return thirdBathroom;
        }

        ~FakeBathroom()
        {
            MyBathrooms = null;
        }
    }
}


    