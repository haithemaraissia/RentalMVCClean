using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeBasement
    { 
       public List<Basement> MyBasements;

       public FakeBasement()
        {
            InitializeBasementList();
        }

       public void InitializeBasementList()
        {
            MyBasements = new List<Basement> {
                FirstBasement(), 
                SecondBasement(),
                ThirdBasement()
            };
        }

       public Basement FirstBasement()
        {

            var firstBasement = new Basement {

                 BasementID = new Int32()
,
                 BasementValue = null
    
 };

            return firstBasement;
        }

       public Basement SecondBasement()
        {

            var secondBasement = new Basement {

                 BasementID = new Int32()
,
                 BasementValue = null
        
 };

            return secondBasement;
        }

       public Basement ThirdBasement()
        {

            var thirdBasement = new Basement {

                 BasementID = new Int32()
,
                 BasementValue = null
 
 };

            return thirdBasement;
        }

        ~FakeBasement()
        {
            MyBasements = null;
        }
    }
}


    