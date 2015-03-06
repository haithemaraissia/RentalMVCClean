using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeFloors
    { 
       public List<Floor> MyFloors;

       public FakeFloors()
        {
            InitializeFloorList();
        }

       public void InitializeFloorList()
        {
            MyFloors = new List<Floor> {
                FirstFloor(), 
                SecondFloor(),
                ThirdFloor()
            };
        }

       public Floor FirstFloor()
        {

            var firstFloor = new Floor {

                 FloorID = null,
                 FloorValue = null
    
 };

            return firstFloor;
        }

       public Floor SecondFloor()
        {

            var secondFloor = new Floor {

                 FloorID = null,
                 FloorValue = null
        
 };

            return secondFloor;
        }

       public Floor ThirdFloor()
        {

            var thirdFloor = new Floor {

                 FloorID = null,
                 FloorValue = null
 
 };

            return thirdFloor;
        }

        ~FakeFloors()
        {
            MyFloors = null;
        }
    }
}


    