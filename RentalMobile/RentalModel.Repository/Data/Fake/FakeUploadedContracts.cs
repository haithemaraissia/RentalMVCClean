using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUploadedContract
    { 
       public List<UploadedContract> MyUploadedContracts;

       public FakeUploadedContract()
        {
            InitializeUploadedContractList();
        }

       public void InitializeUploadedContractList()
        {
            MyUploadedContracts = new List<UploadedContract> {
                FirstUploadedContract(), 
                SecondUploadedContract(),
                ThirdUploadedContract()
            };
        }

       public UploadedContract FirstUploadedContract()
        {

            var firstUploadedContract = new UploadedContract {

                 UploadedImageId = new Int32()
,
                 UploadedImagePath = null,
                 UploaderId = new Int32()
,
                 UploaderRole = null
    
 };

            return firstUploadedContract;
        }

       public UploadedContract SecondUploadedContract()
        {

            var secondUploadedContract = new UploadedContract {

                 UploadedImageId = new Int32()
,
                 UploadedImagePath = null,
                 UploaderId = new Int32()
,
                 UploaderRole = null
        
 };

            return secondUploadedContract;
        }

       public UploadedContract ThirdUploadedContract()
        {

            var thirdUploadedContract = new UploadedContract {

                 UploadedImageId = new Int32()
,
                 UploadedImagePath = null,
                 UploaderId = new Int32()
,
                 UploaderRole = null
 
 };

            return thirdUploadedContract;
        }

        ~FakeUploadedContract()
        {
            MyUploadedContracts = null;
        }
    }
}


    