using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTenantShowings
    { 
       public List<TenantShowing> MyTenantShowings;

       public FakeTenantShowings()
        {
            InitializeTenantShowingList();
        }

       public void InitializeTenantShowingList()
        {
            MyTenantShowings = new List<TenantShowing> {
                FirstTenantShowing(), 
                SecondTenantShowing(),
                ThirdTenantShowing()
            };
        }

       public TenantShowing FirstTenantShowing()
        {

            var firstTenantShowing = new TenantShowing {

                 ShowingId = new Int32()
,
                 Date = new DateTime()
,
                 UnitId = new Int32()
,
                 TenantId = new Int32()
,
                 Tenant = new Tenant()

    
 };

            return firstTenantShowing;
        }

       public TenantShowing SecondTenantShowing()
        {

            var secondTenantShowing = new TenantShowing {

                 ShowingId = new Int32()
,
                 Date = new DateTime()
,
                 UnitId = new Int32()
,
                 TenantId = new Int32()
,
                 Tenant = new Tenant()

        
 };

            return secondTenantShowing;
        }

       public TenantShowing ThirdTenantShowing()
        {

            var thirdTenantShowing = new TenantShowing {

                 ShowingId = new Int32()
,
                 Date = new DateTime()
,
                 UnitId = new Int32()
,
                 TenantId = new Int32()
,
                 Tenant = new Tenant()

 
 };

            return thirdTenantShowing;
        }

        ~FakeTenantShowings()
        {
            MyTenantShowings = null;
        }
    }
}


    