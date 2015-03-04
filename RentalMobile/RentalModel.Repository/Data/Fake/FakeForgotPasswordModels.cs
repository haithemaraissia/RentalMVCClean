using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeForgotPasswordModel
    { 
       public List<ForgotPasswordModel> MyForgotPasswordModels;

       public FakeForgotPasswordModel()
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

        ~FakeForgotPasswordModel()
        {
            MyForgotPasswordModels = null;
        }
    }
}


    