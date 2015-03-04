using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTest
    { 
       public List<Test> MyTests;

       public FakeTest()
        {
            InitializeTestList();
        }

       public void InitializeTestList()
        {
            MyTests = new List<Test> {
                FirstTest(), 
                SecondTest(),
                ThirdTest()
            };
        }

       public Test FirstTest()
        {

            var firstTest = new Test {

                 Unit = new Unit()
,
                 UnitFeature = new UnitFeature()

         
 };

            return firstTest;
        }

       public Test SecondTest()
        {

            var secondTest = new Test {

                 Unit = new Unit()
,
                 UnitFeature = new UnitFeature()

        
 };

            return secondTest;
        }

       public Test ThirdTest()
        {

            var thirdTest = new Test {

                 Unit = new Unit()
,
                 UnitFeature = new UnitFeature()

 
 };

            return thirdTest;
        }

        ~FakeTest()
        {
            MyTests = null;
        }
    }
}


    