using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.PublicProfile;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Core.InProgress.Profiles
{
    [TestClass]
    public class PropertyControllerTest
    {
        public PropertyController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var fakeUnits = new FakeUnits();
            var fakeUnitGallery = new FakeUnitGallerys();

            var unitRepo = new FakeUnitRepository(fakeUnits.MyUnits);
            var unitGalleryRepo = new FakeUnitGalleryRepository(fakeUnitGallery.MyUnitGallerys);
            var uow = new UnitofWork { UnitRepository = unitRepo, UnitGalleryRepository = unitGalleryRepo };
            Controller = new PropertyController(uow, null, null);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            var actual = Controller.Index(2);

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;

            Assert.AreEqual("1/1/2001", viewResult.ViewBag.UnitId);
            Assert.AreEqual("1/1/2002", viewResult.ViewBag.UnitGoogleMap);
            Assert.AreEqual("1/1/2002", viewResult.ViewBag.UnitGoogleMap);
            Assert.AreEqual("1/1/2002", viewResult.ViewBag.UnitGoogleMap);
            Assert.AreEqual("1/1/2002", viewResult.ViewBag.UnitGoogleMap);
            Assert.AreEqual("1/1/2002", viewResult.ViewBag.UnitGoogleMap);
            Assert.AreEqual("1/1/2002", viewResult.ViewBag.UnitGoogleMap);
            Assert.AreEqual("2", viewResult.ViewBag.ProjectId);
 
            //ViewBag.UnitId = unit.UnitId;
            //ViewBag.UnitGoogleMap = unit.GoogleMap;
            //ViewBag.Sript = FancyBox.FancyUnit(id);

            //ViewBag.FaceBook = SocialHelper.FacebookShare(url, primaryimagethumbnail, title, summary);
            //ViewBag.Twitter = SocialHelper.TwitterShare(tweet);
            //ViewBag.GooglePlusShare = SocialHelper.GooglePlusShare(url);
            //ViewBag.LinkedIn = SocialHelper.LinkedInShare(url, title, summary, sitename);

            var data = viewResult.ViewData.Model as Unit;
            if (data != null) Assert.AreEqual(4, data.Bed);

        }

        [TestMethod]
        public void ShareonFacebook()
        {
            
        }

        [TestMethod]
        public void JsonFun()
        {

        }
        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
        }
    }
}
       