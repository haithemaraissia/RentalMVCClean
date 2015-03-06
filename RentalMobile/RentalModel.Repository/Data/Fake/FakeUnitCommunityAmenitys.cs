using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeUnitCommunityAmenitys
    { 
       public List<UnitCommunityAmenity> MyUnitCommunityAmenitys;

       public FakeUnitCommunityAmenitys()
        {
            InitializeUnitCommunityAmenityList();
        }

       public void InitializeUnitCommunityAmenityList()
        {
            MyUnitCommunityAmenitys = new List<UnitCommunityAmenity> {
                FirstUnitCommunityAmenity(), 
                SecondUnitCommunityAmenity(),
                ThirdUnitCommunityAmenity()
            };
        }

       public UnitCommunityAmenity FirstUnitCommunityAmenity()
        {

            var firstUnitCommunityAmenity = new UnitCommunityAmenity {

                 UnitId = new Int32()
,
                 Neighborhood_Name = null,
                 Elementary_School = null,
                 High_School = null,
                 School_District = null,
                 Middle_School = null,
                 County_Name = null,
                 Assisted_Living_Community = new Boolean()
,
                 Over_55_Active_Community = new Boolean()
,
                 Disability_Access = new Boolean()
,
                 Controlled_Access = new Boolean()
,
                 Community_Pool = new Boolean()
,
                 Unit = new Unit()

    
 };

            return firstUnitCommunityAmenity;
        }

       public UnitCommunityAmenity SecondUnitCommunityAmenity()
        {

            var secondUnitCommunityAmenity = new UnitCommunityAmenity {

                 UnitId = new Int32()
,
                 Neighborhood_Name = null,
                 Elementary_School = null,
                 High_School = null,
                 School_District = null,
                 Middle_School = null,
                 County_Name = null,
                 Assisted_Living_Community = new Boolean()
,
                 Over_55_Active_Community = new Boolean()
,
                 Disability_Access = new Boolean()
,
                 Controlled_Access = new Boolean()
,
                 Community_Pool = new Boolean()
,
                 Unit = new Unit()

        
 };

            return secondUnitCommunityAmenity;
        }

       public UnitCommunityAmenity ThirdUnitCommunityAmenity()
        {

            var thirdUnitCommunityAmenity = new UnitCommunityAmenity {

                 UnitId = new Int32()
,
                 Neighborhood_Name = null,
                 Elementary_School = null,
                 High_School = null,
                 School_District = null,
                 Middle_School = null,
                 County_Name = null,
                 Assisted_Living_Community = new Boolean()
,
                 Over_55_Active_Community = new Boolean()
,
                 Disability_Access = new Boolean()
,
                 Controlled_Access = new Boolean()
,
                 Community_Pool = new Boolean()
,
                 Unit = new Unit()

 
 };

            return thirdUnitCommunityAmenity;
        }

        ~FakeUnitCommunityAmenitys()
        {
            MyUnitCommunityAmenitys = null;
        }
    }
}


    