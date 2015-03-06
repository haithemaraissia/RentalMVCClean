using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenancePhotos
    { 
       public List<MaintenancePhoto> MyMaintenancePhotos;

       public FakeMaintenancePhotos()
        {
            InitializeMaintenancePhotoList();
        }

       public void InitializeMaintenancePhotoList()
        {
            MyMaintenancePhotos = new List<MaintenancePhoto> {
                FirstMaintenancePhoto(), 
                SecondMaintenancePhoto(),
                ThirdMaintenancePhoto()
            };
        }

       public MaintenancePhoto FirstMaintenancePhoto()
        {

            var firstMaintenancePhoto = new MaintenancePhoto {

                 MaintenanceID = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null,
                 MaintenanceOrder = new MaintenanceOrder()

    
 };

            return firstMaintenancePhoto;
        }

       public MaintenancePhoto SecondMaintenancePhoto()
        {

            var secondMaintenancePhoto = new MaintenancePhoto {

                 MaintenanceID = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null,
                 MaintenanceOrder = new MaintenanceOrder()

        
 };

            return secondMaintenancePhoto;
        }

       public MaintenancePhoto ThirdMaintenancePhoto()
        {

            var thirdMaintenancePhoto = new MaintenancePhoto {

                 MaintenanceID = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null,
                 MaintenanceOrder = new MaintenanceOrder()

 
 };

            return thirdMaintenancePhoto;
        }

        ~FakeMaintenancePhotos()
        {
            MyMaintenancePhotos = null;
        }
    }
}


    