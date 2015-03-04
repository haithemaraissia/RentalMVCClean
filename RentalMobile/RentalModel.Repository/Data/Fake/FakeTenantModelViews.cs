using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTenantModelView
    { 
       public List<TenantModelView> MyTenantModelViews;

       public FakeTenantModelView()
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
                 TenantShowings = new List`1()

         
 };

            return firstTenantModelView;
        }

       public TenantModelView SecondTenantModelView()
        {

            var secondTenantModelView = new TenantModelView {

                 Tenants = new Tenant()
,
                 TenantShowings = new List`1()

        
 };

            return secondTenantModelView;
        }

       public TenantModelView ThirdTenantModelView()
        {

            var thirdTenantModelView = new TenantModelView {

                 Tenants = new Tenant()
,
                 TenantShowings = new List`1()

 
 };

            return thirdTenantModelView;
        }

        ~FakeTenantModelView()
        {
            MyTenantModelViews = null;
        }
    }
}


    