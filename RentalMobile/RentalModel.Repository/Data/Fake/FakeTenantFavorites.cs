using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTenantFavorites
    { 
       public List<TenantFavorite> MyTenantFavorites;

       public FakeTenantFavorites()
        {
            InitializeTenantFavoriteList();
        }

       public void InitializeTenantFavoriteList()
        {
            MyTenantFavorites = new List<TenantFavorite> {
                FirstTenantFavorite(), 
                SecondTenantFavorite(),
                ThirdTenantFavorite()
            };
        }

       public TenantFavorite FirstTenantFavorite()
        {

            var firstTenantFavorite = new TenantFavorite {

                 FavoriteId = new Int32()
,
                 TenantId = new Int32()
,
                 UnitId = new Int32()
,
                 FavoriteDate = new DateTime()
,
                 Tenant = new Tenant()

    
 };

            return firstTenantFavorite;
        }

       public TenantFavorite SecondTenantFavorite()
        {

            var secondTenantFavorite = new TenantFavorite {

                 FavoriteId = new Int32()
,
                 TenantId = new Int32()
,
                 UnitId = new Int32()
,
                 FavoriteDate = new DateTime()
,
                 Tenant = new Tenant()

        
 };

            return secondTenantFavorite;
        }

       public TenantFavorite ThirdTenantFavorite()
        {

            var thirdTenantFavorite = new TenantFavorite {

                 FavoriteId = new Int32()
,
                 TenantId = new Int32()
,
                 UnitId = new Int32()
,
                 FavoriteDate = new DateTime()
,
                 Tenant = new Tenant()

 
 };

            return thirdTenantFavorite;
        }

        ~FakeTenantFavorites()
        {
            MyTenantFavorites = null;
        }
    }
}


    