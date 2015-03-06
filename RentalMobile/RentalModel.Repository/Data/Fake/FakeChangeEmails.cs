using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeChangeEmails
    { 
       public List<ChangeEmail> MyChangeEmails;

       public FakeChangeEmails()
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

        ~FakeChangeEmails()
        {
            MyChangeEmails = null;
        }
    }
}

    