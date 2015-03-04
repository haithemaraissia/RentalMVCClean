using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeProjectPhoto
    { 
       public List<ProjectPhoto> MyProjectPhotos;

       public FakeProjectPhoto()
        {
            InitializeProjectPhotoList();
        }

       public void InitializeProjectPhotoList()
        {
            MyProjectPhotos = new List<ProjectPhoto> {
                FirstProjectPhoto(), 
                SecondProjectPhoto(),
                ThirdProjectPhoto()
            };
        }

       public ProjectPhoto FirstProjectPhoto()
        {

            var firstProjectPhoto = new ProjectPhoto {

                 ProjectID = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null
    
 };

            return firstProjectPhoto;
        }

       public ProjectPhoto SecondProjectPhoto()
        {

            var secondProjectPhoto = new ProjectPhoto {

                 ProjectID = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null
        
 };

            return secondProjectPhoto;
        }

       public ProjectPhoto ThirdProjectPhoto()
        {

            var thirdProjectPhoto = new ProjectPhoto {

                 ProjectID = new Int32()
,
                 PhotoID = new Int32()
,
                 PhotoPath = null
 
 };

            return thirdProjectPhoto;
        }

        ~FakeProjectPhoto()
        {
            MyProjectPhotos = null;
        }
    }
}


    