using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeChangeEmail
    { 
       public List<ChangeEmail> MyChangeEmails;

       public FakeChangeEmail()
        {
            InitializeChangeEmailList();
        }

       public void InitializeChangeEmailList()
        {
            MyChangeEmails = new List<ChangeEmail> {
                FirstChangeEmail(), 
                SecondChangeEmail(),
                ThirdChangeEmail()
            };
        }

       public ChangeEmail FirstChangeEmail()
        {

            var firstChangeEmail = new ChangeEmail {

                 Email = null
         
 };

            return firstChangeEmail;
        }

       public ChangeEmail SecondChangeEmail()
        {

            var secondChangeEmail = new ChangeEmail {

                 Email = null
        
 };

            return secondChangeEmail;
        }

       public ChangeEmail ThirdChangeEmail()
        {

            var thirdChangeEmail = new ChangeEmail {

                 Email = null
 
 };

            return thirdChangeEmail;
        }

        ~FakeChangeEmail()
        {
            MyChangeEmails = null;
        }
    }
}


    