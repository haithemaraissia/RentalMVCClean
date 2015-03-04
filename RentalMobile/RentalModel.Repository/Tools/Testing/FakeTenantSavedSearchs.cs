using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTenantSavedSearch
    { 
       public List<TenantSavedSearch> MyTenantSavedSearchs;

       public FakeTenantSavedSearch()
        {
            InitializeTenantSavedSearchList();
        }

       public void InitializeTenantSavedSearchList()
        {
            MyTenantSavedSearchs = new List<TenantSavedSearch> {
                FirstTenantSavedSearch(), 
                SecondTenantSavedSearch(),
                ThirdTenantSavedSearch()
            };
        }

       public TenantSavedSearch FirstTenantSavedSearch()
        {

            var firstTenantSavedSearch = new TenantSavedSearch {

                 SearchId = new Int32()
,
                 TenantId = new Int32()
,
                 Search = null,
                 SearchDate = new DateTime()
,
                 Tenant = new Tenant()

    
 };

            return firstTenantSavedSearch;
        }

       public TenantSavedSearch SecondTenantSavedSearch()
        {

            var secondTenantSavedSearch = new TenantSavedSearch {

                 SearchId = new Int32()
,
                 TenantId = new Int32()
,
                 Search = null,
                 SearchDate = new DateTime()
,
                 Tenant = new Tenant()

        
 };

            return secondTenantSavedSearch;
        }

       public TenantSavedSearch ThirdTenantSavedSearch()
        {

            var thirdTenantSavedSearch = new TenantSavedSearch {

                 SearchId = new Int32()
,
                 TenantId = new Int32()
,
                 Search = null,
                 SearchDate = new DateTime()
,
                 Tenant = new Tenant()

 
 };

            return thirdTenantSavedSearch;
        }

        ~FakeTenantSavedSearch()
        {
            MyTenantSavedSearchs = null;
        }
    }
}


    