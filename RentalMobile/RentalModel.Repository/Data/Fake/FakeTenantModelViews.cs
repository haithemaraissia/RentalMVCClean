using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTenantModelViews
    { 
       public List<TenantModelView> MyTenantModelViews;

       public FakeTenantModelViews()
        {
            InitializeTenantModelViewList();
        }

       public void InitializeTenantModelViewList()
        {
            MyTenantModelViews = new List<TenantModelView> {
                FirstTenantModelView(), 
                SecondTenantModelView(),
                ThirdTenantModelView()
            };
        }

       public TenantModelView FirstTenantModelView()
        {

            var firstTenantModelView = new TenantModelView {

                 Tenants = new Tenant()
,
//Skipping TenantShowing Collection

         
 };

            return firstTenantModelView;
        }

       public TenantModelView SecondTenantModelView()
        {

            var secondTenantModelView = new TenantModelView {

                 Tenants = new Tenant()
,
//Skipping TenantShowing Collection

        
 };

            return secondTenantModelView;
        }

       public TenantModelView ThirdTenantModelView()
        {

            var thirdTenantModelView = new TenantModelView {

                 Tenants = new Tenant()
,
//Skipping TenantShowing Collection

 
 };

            return thirdTenantModelView;
        }

        ~FakeTenantModelViews()
        {
            MyTenantModelViews = null;
        }
    }
}

    