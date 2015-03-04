using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeFloorCovering
    { 
       public List<FloorCovering> MyFloorCoverings;

       public FakeFloorCovering()
        {
            InitializeFloorCoveringList();
        }

       public void InitializeFloorCoveringList()
        {
            MyFloorCoverings = new List<FloorCovering> {
                FirstFloorCovering(), 
                SecondFloorCovering(),
                ThirdFloorCovering()
            };
        }

       public FloorCovering FirstFloorCovering()
        {

            var firstFloorCovering = new FloorCovering {

                 FloorID = new Int32()
,
                 FloorValue = null
    
 };

            return firstFloorCovering;
        }

       public FloorCovering SecondFloorCovering()
        {

            var secondFloorCovering = new FloorCovering {

                 FloorID = new Int32()
,
                 FloorValue = null
        
 };

            return secondFloorCovering;
        }

       public FloorCovering ThirdFloorCovering()
        {

            var thirdFloorCovering = new FloorCovering {

                 FloorID = new Int32()
,
                 FloorValue = null
 
 };

            return thirdFloorCovering;
        }

        ~FakeFloorCovering()
        {
            MyFloorCoverings = null;
        }
    }
}


    