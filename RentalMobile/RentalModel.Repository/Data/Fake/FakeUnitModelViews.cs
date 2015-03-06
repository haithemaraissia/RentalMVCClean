using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitModelViews
    { 
       public List<UnitModelView> MyUnitModelViews;

       public FakeUnitModelViews()
        {
            InitializeUnitModelViewList();
        }

       public void InitializeUnitModelViewList()
        {
            MyUnitModelViews = new List<UnitModelView> {
                FirstUnitModelView(), 
                SecondUnitModelView(),
                ThirdUnitModelView()
            };
        }

       public UnitModelView FirstUnitModelView()
        {

            var firstUnitModelView = new UnitModelView {

                 Unit = new Unit()
,
                 UnitFeature = new UnitFeature()
,
                 UnitCommunityAmenity = new UnitCommunityAmenity()
,
                 UnitAppliance = new UnitAppliance()
,
                 UnitInteriorAmenity = new UnitInteriorAmenity()
,
                 UnitExteriorAmenity = new UnitExteriorAmenity()
,
                 UnitLuxuryAmenity = new UnitLuxuryAmenity()
,
                 UnitPricing = new UnitPricing()
,
                 UnitGallery = new UnitGallery()
,
                 Currency = new Currency()

         
 };

            return firstUnitModelView;
        }

       public UnitModelView SecondUnitModelView()
        {

            var secondUnitModelView = new UnitModelView {

                 Unit = new Unit()
,
                 UnitFeature = new UnitFeature()
,
                 UnitCommunityAmenity = new UnitCommunityAmenity()
,
                 UnitAppliance = new UnitAppliance()
,
                 UnitInteriorAmenity = new UnitInteriorAmenity()
,
                 UnitExteriorAmenity = new UnitExteriorAmenity()
,
                 UnitLuxuryAmenity = new UnitLuxuryAmenity()
,
                 UnitPricing = new UnitPricing()
,
                 UnitGallery = new UnitGallery()
,
                 Currency = new Currency()

        
 };

            return secondUnitModelView;
        }

       public UnitModelView ThirdUnitModelView()
        {

            var thirdUnitModelView = new UnitModelView {

                 Unit = new Unit()
,
                 UnitFeature = new UnitFeature()
,
                 UnitCommunityAmenity = new UnitCommunityAmenity()
,
                 UnitAppliance = new UnitAppliance()
,
                 UnitInteriorAmenity = new UnitInteriorAmenity()
,
                 UnitExteriorAmenity = new UnitExteriorAmenity()
,
                 UnitLuxuryAmenity = new UnitLuxuryAmenity()
,
                 UnitPricing = new UnitPricing()
,
                 UnitGallery = new UnitGallery()
,
                 Currency = new Currency()

 
 };

            return thirdUnitModelView;
        }

        ~FakeUnitModelViews()
        {
            MyUnitModelViews = null;
        }
    }
}

    