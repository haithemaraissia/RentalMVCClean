using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeGeneratedRentalContract
    { 
       public List<GeneratedRentalContract> MyGeneratedRentalContracts;

       public FakeGeneratedRentalContract()
        {
            InitializeGeneratedRentalContractList();
        }

       public void InitializeGeneratedRentalContractList()
        {
            MyGeneratedRentalContracts = new List<GeneratedRentalContract> {
                FirstGeneratedRentalContract(), 
                SecondGeneratedRentalContract(),
                ThirdGeneratedRentalContract()
            };
        }

       public GeneratedRentalContract FirstGeneratedRentalContract()
        {

            var firstGeneratedRentalContract = new GeneratedRentalContract {

                 ID = new Int32()
,
                 LandLoardName = null,
                 LandLoardRole = null,
                 LandLoradID = new Int32(),
                 LandLoardAddress = null,
                 TenantName = null,
                 TenantID = new Int32(),
                 PropertyID = new Int32(),
                 PropertyAddress = null,
                 PropertyCity = null,
                 MonthlyRent = new Double(),
                 BeginingDate = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime(),
                 FirstMonthRent = new Double(),
                 SecurityDeposit = new Double(),
                 TotalPayment = new Double(),
                 TenantRefundedNumberofDays = new Int32(),
                 NoticeofMoveoutNumberofDays = new Int32(),
                 LateFeeCharge = new Double(),
                 PercentageofLateFeeCharge = new Int32(),
                 LateFeeStartingDay = new Int32(),
                 ExceptedUtilites = null,
                 PetDeposit = new Double(),
                 PetMonthly = new Double(),
                 ParkingSpaceNumber = null,
                 ParkingFee = new Double()
    
 };

            return firstGeneratedRentalContract;
        }

       public GeneratedRentalContract SecondGeneratedRentalContract()
        {

            var secondGeneratedRentalContract = new GeneratedRentalContract {

                 ID = new Int32()
,
                 LandLoardName = null,
                 LandLoardRole = null,
                 LandLoradID = new Int32(),
                 LandLoardAddress = null,
                 TenantName = null,
                 TenantID = new Int32(),
                 PropertyID = new Int32(),
                 PropertyAddress = null,
                 PropertyCity = null,
                 MonthlyRent = new Double(),
                 BeginingDate = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime(),
                 FirstMonthRent = new Double(),
                 SecurityDeposit = new Double(),
                 TotalPayment = new Double(),
                 TenantRefundedNumberofDays = new Int32(),
                 NoticeofMoveoutNumberofDays = new Int32(),
                 LateFeeCharge = new Double(),
                 PercentageofLateFeeCharge = new Int32(),
                 LateFeeStartingDay = new Int32(),
                 ExceptedUtilites = null,
                 PetDeposit = new Double(),
                 PetMonthly = new Double(),
                 ParkingSpaceNumber = null,
                 ParkingFee = new Double()
        
 };

            return secondGeneratedRentalContract;
        }

       public GeneratedRentalContract ThirdGeneratedRentalContract()
        {

            var thirdGeneratedRentalContract = new GeneratedRentalContract {

                 ID = new Int32()
,
                 LandLoardName = null,
                 LandLoardRole = null,
                 LandLoradID = new Int32(),
                 LandLoardAddress = null,
                 TenantName = null,
                 TenantID = new Int32(),
                 PropertyID = new Int32(),
                 PropertyAddress = null,
                 PropertyCity = null,
                 MonthlyRent = new Double(),
                 BeginingDate = new Int32(),
                 StartDate = new DateTime(),
                 EndDate = new DateTime(),
                 FirstMonthRent = new Double(),
                 SecurityDeposit = new Double(),
                 TotalPayment = new Double(),
                 TenantRefundedNumberofDays = new Int32(),
                 NoticeofMoveoutNumberofDays = new Int32(),
                 LateFeeCharge = new Double(),
                 PercentageofLateFeeCharge = new Int32(),
                 LateFeeStartingDay = new Int32(),
                 ExceptedUtilites = null,
                 PetDeposit = new Double(),
                 PetMonthly = new Double(),
                 ParkingSpaceNumber = null,
                 ParkingFee = new Double()
 
 };

            return thirdGeneratedRentalContract;
        }

        ~FakeGeneratedRentalContract()
        {
            MyGeneratedRentalContracts = null;
        }
    }
}


    