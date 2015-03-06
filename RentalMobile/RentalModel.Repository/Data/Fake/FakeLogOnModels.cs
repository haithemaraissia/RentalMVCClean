using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeLogOnModels
    { 
       public List<LogOnModel> MyLogOnModels;

       public FakeLogOnModels()
        {
            InitializeLogOnModelList();
        }

       public void InitializeLogOnModelList()
        {
            MyLogOnModels = new List<LogOnModel> {
                FirstLogOnModel(), 
                SecondLogOnModel(),
                ThirdLogOnModel()
            };
        }

       public LogOnModel FirstLogOnModel()
        {

            var firstLogOnModel = new LogOnModel {

                 UserName = null,
                 Password = null,
                 RememberMe = new Boolean()
,
                 Role = null
         
 };

            return firstLogOnModel;
        }

       public LogOnModel SecondLogOnModel()
        {

            var secondLogOnModel = new LogOnModel {

                 UserName = null,
                 Password = null,
                 RememberMe = new Boolean()
,
                 Role = null
        
 };

            return secondLogOnModel;
        }

       public LogOnModel ThirdLogOnModel()
        {

            var thirdLogOnModel = new LogOnModel {

                 UserName = null,
                 Password = null,
                 RememberMe = new Boolean()
,
                 Role = null
 
 };

            return thirdLogOnModel;
        }

        ~FakeLogOnModels()
        {
            MyLogOnModels = null;
        }
    }
}

    