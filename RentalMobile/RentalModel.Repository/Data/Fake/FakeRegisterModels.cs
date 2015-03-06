using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeRegisterModels
    { 
       public List<RegisterModel> MyRegisterModels;

       public FakeRegisterModels()
        {
            InitializeRegisterModelList();
        }

       public void InitializeRegisterModelList()
        {
            MyRegisterModels = new List<RegisterModel> {
                FirstRegisterModel(), 
                SecondRegisterModel(),
                ThirdRegisterModel()
            };
        }

       public RegisterModel FirstRegisterModel()
        {

            var firstRegisterModel = new RegisterModel {

                 UserName = null,
                 Email = null,
                 Password = null,
                 ConfirmPassword = null,
                 Role = null
         
 };

            return firstRegisterModel;
        }

       public RegisterModel SecondRegisterModel()
        {

            var secondRegisterModel = new RegisterModel {

                 UserName = null,
                 Email = null,
                 Password = null,
                 ConfirmPassword = null,
                 Role = null
        
 };

            return secondRegisterModel;
        }

       public RegisterModel ThirdRegisterModel()
        {

            var thirdRegisterModel = new RegisterModel {

                 UserName = null,
                 Email = null,
                 Password = null,
                 ConfirmPassword = null,
                 Role = null
 
 };

            return thirdRegisterModel;
        }

        ~FakeRegisterModels()
        {
            MyRegisterModels = null;
        }
    }
}


    