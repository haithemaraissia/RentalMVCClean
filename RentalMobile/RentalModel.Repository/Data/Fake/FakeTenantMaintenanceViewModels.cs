using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTenantMaintenanceViewModel
    { 
       public List<TenantMaintenanceViewModel> MyTenantMaintenanceViewModels;

       public FakeTenantMaintenanceViewModel()
        {
            InitializeTenantMaintenanceViewModelList();
        }

       public void InitializeTenantMaintenanceViewModelList()
        {
            MyTenantMaintenanceViewModels = new List<TenantMaintenanceViewModel> {
                FirstTenantMaintenanceViewModel(), 
                SecondTenantMaintenanceViewModel(),
                ThirdTenantMaintenanceViewModel()
            };
        }

       public TenantMaintenanceViewModel FirstTenantMaintenanceViewModel()
        {

            var firstTenantMaintenanceViewModel = new TenantMaintenanceViewModel {

         
 };

            return firstTenantMaintenanceViewModel;
        }

       public TenantMaintenanceViewModel SecondTenantMaintenanceViewModel()
        {

            var secondTenantMaintenanceViewModel = new TenantMaintenanceViewModel {

        
 };

            return secondTenantMaintenanceViewModel;
        }

       public TenantMaintenanceViewModel ThirdTenantMaintenanceViewModel()
        {

            var thirdTenantMaintenanceViewModel = new TenantMaintenanceViewModel {

 
 };

            return thirdTenantMaintenanceViewModel;
        }

        ~FakeTenantMaintenanceViewModel()
        {
            MyTenantMaintenanceViewModels = null;
        }
    }
}


    