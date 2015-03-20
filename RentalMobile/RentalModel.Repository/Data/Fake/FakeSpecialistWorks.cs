using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeSpecialistWorks
    { 
       public List<SpecialistWork> MySpecialistWorks;

       public FakeSpecialistWorks()
        {
            InitializeSpecialistWorkList();
        }

       public void InitializeSpecialistWorkList()
        {
            MySpecialistWorks = new List<SpecialistWork> {
                FirstSpecialistWork(), 
                SecondSpecialistWork(),
                ThirdSpecialistWork()
            };
        }

       public SpecialistWork FirstSpecialistWork()
        {

            var firstSpecialistWork = new SpecialistWork {

                 SpecialistId = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null
    
 };

            return firstSpecialistWork;
        }

       public SpecialistWork SecondSpecialistWork()
        {

            var secondSpecialistWork = new SpecialistWork {

                 SpecialistId = 2
,
                 PhotoID = new Int32()
,
                 PhotoPath = "PhotoPath"
        
 };

            return secondSpecialistWork;
        }

       public SpecialistWork ThirdSpecialistWork()
        {

            var thirdSpecialistWork = new SpecialistWork {

                 SpecialistId = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null
 
 };

            return thirdSpecialistWork;
        }

        ~FakeSpecialistWorks()
        {
            MySpecialistWorks = null;
        }
    }
}


    