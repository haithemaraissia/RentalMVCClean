using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeChangePasswordModels
    { 
       public List<ChangePasswordModel> MyChangePasswordModels;

       public FakeChangePasswordModels()
        {
            InitializeChangePasswordModelList();
        }

       public void InitializeChangePasswordModelList()
        {
            MyChangePasswordModels = new List<ChangePasswordModel> {
                FirstChangePasswordModel(), 
                SecondChangePasswordModel(),
                ThirdChangePasswordModel()
            };
        }

       public ChangePasswordModel FirstChangePasswordModel()
        {

            var firstChangePasswordModel = new ChangePasswordModel {

                 OldPassword = null,
                 NewPassword = null,
                 ConfirmPassword = null
         
 };

            return firstChangePasswordModel;
        }

       public ChangePasswordModel SecondChangePasswordModel()
        {

            var secondChangePasswordModel = new ChangePasswordModel {

                 OldPassword = null,
                 NewPassword = null,
                 ConfirmPassword = null
        
 };

            return secondChangePasswordModel;
        }

       public ChangePasswordModel ThirdChangePasswordModel()
        {

            var thirdChangePasswordModel = new ChangePasswordModel {

                 OldPassword = null,
                 NewPassword = null,
                 ConfirmPassword = null
 
 };

            return thirdChangePasswordModel;
        }

        ~FakeChangePasswordModels()
        {
            MyChangePasswordModels = null;
        }
    }
}


    