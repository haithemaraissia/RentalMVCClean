using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeProviderWork
    { 
       public List<ProviderWork> MyProviderWorks;

       public FakeProviderWork()
        {
            InitializeProviderWorkList();
        }

       public void InitializeProviderWorkList()
        {
            MyProviderWorks = new List<ProviderWork> {
                FirstProviderWork(), 
                SecondProviderWork(),
                ThirdProviderWork()
            };
        }

       public ProviderWork FirstProviderWork()
        {

            var firstProviderWork = new ProviderWork {

                 ProviderId = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null
    
 };

            return firstProviderWork;
        }

       public ProviderWork SecondProviderWork()
        {

            var secondProviderWork = new ProviderWork {

                 ProviderId = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null
        
 };

            return secondProviderWork;
        }

       public ProviderWork ThirdProviderWork()
        {

            var thirdProviderWork = new ProviderWork {

                 ProviderId = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null
 
 };

            return thirdProviderWork;
        }

        ~FakeProviderWork()
        {
            MyProviderWorks = null;
        }
    }
}


    