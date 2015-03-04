using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeLogOnModel
    { 
       public List<LogOnModel> MyLogOnModels;

       public FakeLogOnModel()
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

        ~FakeLogOnModel()
        {
            MyLogOnModels = null;
        }
    }
}


    