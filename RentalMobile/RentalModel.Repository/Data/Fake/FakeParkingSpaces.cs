using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeParkingSpaces
    { 
       public List<ParkingSpace> MyParkingSpaces;

       public FakeParkingSpaces()
        {
            InitializeParkingSpaceList();
        }

       public void InitializeParkingSpaceList()
        {
            MyParkingSpaces = new List<ParkingSpace> {
                FirstParkingSpace(), 
                SecondParkingSpace(),
                ThirdParkingSpace()
            };
        }

       public ParkingSpace FirstParkingSpace()
        {

            var firstParkingSpace = new ParkingSpace {

                 ParkingID = new Int32()
,
                 ParkingValue = null
    
 };

            return firstParkingSpace;
        }

       public ParkingSpace SecondParkingSpace()
        {

            var secondParkingSpace = new ParkingSpace {

                 ParkingID = new Int32()
,
                 ParkingValue = null
        
 };

            return secondParkingSpace;
        }

       public ParkingSpace ThirdParkingSpace()
        {

            var thirdParkingSpace = new ParkingSpace {

                 ParkingID = new Int32()
,
                 ParkingValue = null
 
 };

            return thirdParkingSpace;
        }

        ~FakeParkingSpaces()
        {
            MyParkingSpaces = null;
        }
    }
}


    