using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeFoundation
    { 
       public List<Foundation> MyFoundations;

       public FakeFoundation()
        {
            InitializeFoundationList();
        }

       public void InitializeFoundationList()
        {
            MyFoundations = new List<Foundation> {
                FirstFoundation(), 
                SecondFoundation(),
                ThirdFoundation()
            };
        }

       public Foundation FirstFoundation()
        {

            var firstFoundation = new Foundation {

                 FoundationID = new Int32()
,
                 FoundationValue = null
    
 };

            return firstFoundation;
        }

       public Foundation SecondFoundation()
        {

            var secondFoundation = new Foundation {

                 FoundationID = new Int32()
,
                 FoundationValue = null
        
 };

            return secondFoundation;
        }

       public Foundation ThirdFoundation()
        {

            var thirdFoundation = new Foundation {

                 FoundationID = new Int32()
,
                 FoundationValue = null
 
 };

            return thirdFoundation;
        }

        ~FakeFoundation()
        {
            MyFoundations = null;
        }
    }
}


    