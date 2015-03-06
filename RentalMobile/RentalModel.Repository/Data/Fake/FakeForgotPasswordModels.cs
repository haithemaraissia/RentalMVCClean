using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeForgotPasswordModels
    { 
       public List<ForgotPasswordModel> MyForgotPasswordModels;

       public FakeForgotPasswordModels()
        {
            InitializeForgotPasswordModelList();
        }

       public void InitializeForgotPasswordModelList()
        {
            MyForgotPasswordModels = new List<ForgotPasswordModel> {
                FirstForgotPasswordModel(), 
                SecondForgotPasswordModel(),
                ThirdForgotPasswordModel()
            };
        }

       public ForgotPasswordModel FirstForgotPasswordModel()
        {

            var firstForgotPasswordModel = new ForgotPasswordModel {

                 Email = null
         
 };

            return firstForgotPasswordModel;
        }

       public ForgotPasswordModel SecondForgotPasswordModel()
        {

            var secondForgotPasswordModel = new ForgotPasswordModel {

                 Email = null
        
 };

            return secondForgotPasswordModel;
        }

       public ForgotPasswordModel ThirdForgotPasswordModel()
        {

            var thirdForgotPasswordModel = new ForgotPasswordModel {

                 Email = null
 
 };

            return thirdForgotPasswordModel;
        }

        ~FakeForgotPasswordModels()
        {
            MyForgotPasswordModels = null;
        }
    }
}

    