using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitGallerys
    { 
       public List<UnitGallery> MyUnitGallerys;

       public FakeUnitGallerys()
        {
            InitializeUnitGalleryList();
        }

       public void InitializeUnitGalleryList()
        {
            MyUnitGallerys = new List<UnitGallery> {
                FirstUnitGallery(), 
                SecondUnitGallery(),
                ThirdUnitGallery()
            };
        }

       public UnitGallery FirstUnitGallery()
        {

            var firstUnitGallery = new UnitGallery {

                 UnitGalleryId = new Int32()
,
                 Path = null,
                 Caption = null,
                 Rank = new Int32()
,
                 UnitId = new Int32()
,
                 Unit = new Unit()

    
 };

            return firstUnitGallery;
        }

       public UnitGallery SecondUnitGallery()
        {

            var secondUnitGallery = new UnitGallery {

                 UnitGalleryId = new Int32()
,
                 Path = null,
                 Caption = null,
                 Rank = new Int32()
,
                 UnitId = new Int32()
,
                 Unit = new Unit()

        
 };

            return secondUnitGallery;
        }

       public UnitGallery ThirdUnitGallery()
        {

            var thirdUnitGallery = new UnitGallery {

                 UnitGalleryId = new Int32()
,
                 Path = null,
                 Caption = null,
                 Rank = new Int32()
,
                 UnitId = new Int32()
,
                 Unit = new Unit()

 
 };

            return thirdUnitGallery;
        }

        ~FakeUnitGallerys()
        {
            MyUnitGallerys = null;
        }
    }
}


    