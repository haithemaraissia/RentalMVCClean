using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Controllers.PublicProfile;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.Identity.Base.Roles.PublicProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Roles;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;
using TestProject.UnitTest.Helpers.Fake;
using TestProject.UnitTest.Helpers.Util;

namespace TestProject.UnitTest.Application.Controllers.InProgress.PublicProfile
{

    [TestClass]
    public class SpecialistProfileControllerTest
    {

        #region Initialization

        public SpecialistProfileController Controller;
        public AssertHelper Helper = new AssertHelper();
        public UnitofWork Uow;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            #region SpecialistPublicProfileHelper

            #region Repo
            var professionalRepo = new FakeSpecialistRepository();
            var maintenanceCompanyLookUpRepo = new FakeMaintenanceCompanyLookUpRepository();
            var maintenanceRepairRepo = new FakeMaintenanceRepairRepository();
            var maintenanceCompanySpecializationRepo = new FakeMaintenanceCompanySpecializationRepository();
            var currencyRepo = new FakeCurrencyRepository();
            var specialistProfileCommentRepo = new FakeSpecialistProfileCommentRepository();
            var specialistWorkRepo = new FakeSpecialistWorkRepository();
            var tenantRepo = new FakeTenantRepository();
            Uow = new UnitofWork
           {
               SpecialistRepository = professionalRepo,
               MaintenanceCompanyLookUpRepository = maintenanceCompanyLookUpRepo,
               MaintenanceRepairRepository = maintenanceRepairRepo,
               MaintenanceCompanySpecializationRepository = maintenanceCompanySpecializationRepo,
               CurrencyRepository = currencyRepo,
               SpecialistProfileCommentRepository = specialistProfileCommentRepo,
               SpecialistWorkRepository = specialistWorkRepo,
               TenantRepository = tenantRepo
           };
            #endregion

            #region Mocking Context

            //MockHelper  
            var specialistPublicProfileHelperController =
                new SpecialistPublicProfileHelper(Uow, new FakeMembershipProvider(), null);

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.Request.Url).Returns(new Uri("http://tempuri.org"));
            specialistPublicProfileHelperController.ControllerContext = controllerContext.Object;
            #endregion

            #region Mocking IUserHelper
            var mockHelper = new Mock<IUserHelper>();
            mockHelper.
                Setup(x => x.SpecialistPublicProfileHelper).
                Returns(specialistPublicProfileHelperController);
            mockHelper.
                Setup(x => x.PosterHelper).
                Returns(new PosterHelper(Uow, new FakeMembershipProvider()));
            #endregion

            #region Mocking MemberShipService
            //MembershipService Optional 
            var membershipMock = new Mock<IMembershipService>();
            //var userMock = new Mock<MembershipUser>();
            //var secondSpecialist = professionalRepo.MyList[1];
            //userMock.Setup(u => u.ProviderUserKey).Returns(secondSpecialist.GUID);
            //userMock.Setup(u => u.UserName).Returns(secondSpecialist.FirstName);
            //membershipMock.Setup(s => s.GetUser(It.IsAny<string>())).Returns(userMock.Object);
            #endregion

            #region Controller Construction

            // Controller = new SpecialistProfileController(Uow, membershipMock.Object, new CoreUserHelper(Uow, membershipMock.Object));
            Controller = new SpecialistProfileController(Uow, membershipMock.Object, mockHelper.Object);

            #endregion

            #endregion

        }

        #endregion

        #region Index
        /// <summary>
        /// Index
        /// </summary>
        [TestCategory("Index")]
        [TestMethod]
        public void Index_Where_Id_isNull_And_sharespecialist_isNull_And_InsertingNewComment_isNull_Should_Return_Null()
        {
            //Act
            var actual = Controller.Index(null, true, true);

            //Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as Specialist;
            Assert.AreEqual(data, null);
        }

        [TestCategory("Index")]
        [TestMethod]
        public void Index_Where_Id_isNull_And_sharespecialist_isTrue_And_InsertingNewComment_isTrue_Should_Return_Null()
        {
            //Act
            var actual = Controller.Index(null, null, null);

            //Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as Specialist;
            Assert.AreEqual(data, null);
        }

        [TestCategory("Index")]
        [TestMethod]
        public void Index_Where_Id_isNotNull_But_Specialist_Is_Null()
        {
            //Act
            var actual = Controller.Index(500, true, true);

            //Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as Specialist;
            Assert.AreEqual(data, null);
        }

        [TestCategory("Index")]
        [TestMethod]
        public void Index_Where_Id_isNotNull_But_Specialist_Is_Not_Null()
        {
            //Act
            var actual = Controller.Index(2, true, true);

            //Assert
            var viewResult = actual as ViewResult;
            Debug.Assert(viewResult != null, "viewResult != null");
            var data = viewResult.ViewData.Model as Specialist;
            Debug.Assert(data != null, "data != null");
            Assert.AreEqual(data.Country, "USA");
        }

        [TestCategory("Index")]
        [TestMethod]
        public void Index_Where_Insertingnewcomment_isTrue()
        {
            //Act
            var actual = Controller.Index(2, null, true);

            //Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            Assert.AreEqual(viewResult.ViewBag.InsertNewComment, true);
        }

        [TestCategory("Index")]
        [TestCategory("ShareSpecialist")]
        [TestMethod]
        public void Index_Where_Sharespecialist_isTrue()
        {
            //Act
            var actual = Controller.Index(2, true, null);

            //Assert
            var viewResult = actual as ViewResult;
            Debug.Assert(viewResult != null, "viewResult != null");
            Assert.AreEqual(viewResult.ViewBag.EmailSharedwithFriend, true);
            Assert.AreEqual(viewResult.ViewBag.FaceBook,
                "http://www.facebook.com/sharer/sharer.php?s=100&p[url]=http://www.haithem-araissia.com");
            Assert.AreEqual(viewResult.ViewBag.Twitter,
                "http://twitter.com/home?status=http://tempuri.org/");
            Assert.AreEqual(viewResult.ViewBag.GooglePlusShare,
                "https://plus.google.com/share?url=http://tempuri.org/");
            Assert.AreEqual(viewResult.ViewBag.LinkedIn,
                "http://www.linkedin.com/shareArticle?mini=true&url=http://tempuri.org/&title=&summary=&source=http://www.haithem-araissia.com");
        }
        #endregion

        #region Coverage
        /// <summary>
        /// Coverage Partial View
        /// </summary>
        [TestCategory("Coverage")]
        [TestMethod]
        public void Coverage_Where_Id_Is_Zero_Should_Return_Null()
        {
            //Act
            var actual = Controller._Coverage(0);

            //Assert
            var viewResult = actual;
            Assert.AreEqual(viewResult, null);
        }

        [TestCategory("Coverage")]
        [TestMethod]
        public void Coverage_Where_LookUp_Is_Null_Should_Return_Null()
        {
            //Act
            var actual = Controller._Coverage(500);

            //Assert
            var viewResult = actual;
            Assert.AreEqual(viewResult, null);
        }

        [TestCategory("Coverage")]
        [TestMethod]
        public void Coverage_Where_Id_Is_Not_Zero_And_LookUp_Is_Not_Null()
        {
            //Act
            var actual = Controller._Coverage(2);

            //Assert
            var viewResult = actual;
            Debug.Assert(viewResult != null, "viewResult != null");
            var data = viewResult.ViewData.Model as SpecialistMaintenanceProfile;
            Debug.Assert(data != null, "data != null");
            Assert.AreEqual(data.MaintenanceRepair.Drain_Pipe, true);
        }
        #endregion

        #region Description
        /// <summary>
        /// Description Partial View
        /// </summary>
        [TestCategory("Description")]
        [TestMethod]
        public void Description_Where_Id_Is_Zero_Should_Return_Null()
        {
            //Act
            var actual = Controller._Description(0);

            //Assert
            var viewResult = actual;
            Assert.AreEqual(viewResult, null);
        }

        [TestCategory("Description")]
        [TestMethod]
        public void Description_Where_Id_Is_Zero_Should_Return_Null_Where_LookUp_Is_Null_Should_Return_Null()
        {
            //Act
            var actual = Controller._Description(500);

            //Assert
            var viewResult = actual;
            Assert.AreEqual(viewResult, null);
        }

        [TestCategory("Description")]
        [TestMethod]
        public void Description_Where_Id_Is_Not_Zero_And_LookUp_Is_Not_Null_And_MaintenanceCompany_Specialization_Is_Not_Null()
        {
            //Act
            var actual = Controller._Description(2);

            //Assert
            var viewResult = actual;
            Debug.Assert(viewResult != null, "viewResult != null");
            Assert.AreEqual(viewResult.ViewBag.Rate, 55.50);
            Assert.AreEqual(viewResult.ViewBag.YearsofExperience, 5);
            Assert.AreEqual(viewResult.ViewBag.Currency, "US");
            var data = viewResult.ViewData.Model as Specialist;
            Debug.Assert(data != null, "data != null");
            Assert.AreEqual(data.Country, "USA");
        }

        #endregion

        #region Forward to Friend


        /// <summary>
        /// Forward to Friend
        /// </summary>
        [TestCategory("ForwardtoFriend")]
        [TestMethod]
        public void ForwardToFriend()
        {
            //Act



            //var actual = new SpecialistPublicProfileHelper(Uow, new FakeMembershipProvider());

            //var controllerContext = new Mock<ControllerContext>();
            //controllerContext.SetupGet(x => x.HttpContext.Request.Url).Returns(new Uri("http://tempuri.org"));   
            //actual.ControllerContext = controllerContext.Object;

            //var email = actual.SpecialPublicProfileComposeForwardToFriendEmail("myFriendName", "myFriendEmailAddress", "myMessage", 5);


            //Assert.AreEqual(email.SenderFirstName, "A Friend");

            //// email.ProfileUrl
            ////  email.CustomTitle
            ////email.PhotoPath 
            //Assert.AreEqual(email.ProfileUrl, "A Friend");
            //Assert.AreEqual(email.CustomTitle, "A Friend");
            //Assert.AreEqual(email.PhotoPath, "A Friend");
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.Request.Url).Returns(new Uri("http://tempuri.org"));
            Controller.ControllerContext = controllerContext.Object;



            var email = new Postal.Email("ForwardtoFriend/Multipart");
            try
            {
                email.SendAsync();
            }
            catch (Exception e)
            {

                throw;
            }


            var actual = Controller.ForwardtoFriend("myFriendName", "myFriendEmailAddress", "myMessage", 5);
            var viewResult = actual as ViewResult;
            if (viewResult != null)
            {
                Assert.AreEqual(viewResult.ViewBag.Email, 55.50);


            }

            //   public ActionResult ForwardtoFriend(string friendname, string friendemailaddress, string message, int id)
            //{
            //    dynamic email = new Email("ForwardtoFriend/Multipart");
            //    var poster = UserHelper.GetSendtoFriendPoster() ?? UserHelper.DefaultPoster;
            //    email.To = friendemailaddress;
            //    email.FriendName = friendname;
            //    email.From = "postmaster@haithem-araissia.com";
            //    email.SenderFirstName = poster.FirstName;
            //    email.Title = string.Format("Request From {0}", poster.FirstName);
            //    email.SubTitle = "Request from ";
            //    email.Message = message;
            //    email.InvitationNote = " invite you to see this skilled professional.";
            //    email.FooterNote = "Check out this Professional";
            //    var uri = Request.Url;
            //    if (uri != null)
            //    {
            //        var host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
            //        email.ProfileUrl = host + uri.AbsolutePath.Replace("ForwardtoFriend", "");
            //        var currentSpecialist = _unitOfWork.SpecialistRepository.FindBy(x => x.SpecialistId == id).FirstOrDefault();
            //        if (currentSpecialist != null)
            //        {
            //            var specialistTitle = currentSpecialist.FirstName + " , " + currentSpecialist.LastName;
            //            if (specialistTitle.Length >= 50)
            //            {
            //                specialistTitle = specialistTitle.Substring(0, 50);
            //            }
            //            email.CustomTitle = specialistTitle;
            //        }
            //        if (currentSpecialist != null)
            //        {
            //            email.PhotoPath = host + "/" + GetSpecialistPrimaryWorkPhoto(id).Replace("../../", "");

            //        }
            //    }
            //    try
            //    {
            //        email.SendAsync();

            //    }
            //    catch (Exception)
            //    {
            //        return RedirectToAction("Index", new { id, sharespecialist = false });
            //    }
            //    return RedirectToAction("Index", new { id, sharespecialist = true });

            //}



            //Act
            //string friendname, string friendemailaddress, string message, int id
            //string friendname = "Joe";
            //string friendemailaddress = "JoeSmith@yahoo.com";
            //string message = "message from Joe";
            //int id = 2;
            //var actual = Controller.ForwardtoFriend();

            //var DefaultPoster = new PosterAttributes(tenant.FirstName, tenant.LastName,
            //                                    currenturl + "/tenantprofile/index/" + tenant.TenantId, tenant.Photo,
            //                                    tenant.EmailAddress, "tenant", tenant.TenantId);
            Assert.Inconclusive("Not Implemented Yet");
        }
        #endregion

        #region Comment
        /// <summary>
        /// Comment Partial View
        /// </summary>
        [TestCategory("Comment")]
        [TestMethod]
        public void Comment_When_Id_Is_Zero_Should_Return_Null()
        {
            //Act
            var actual = Controller._Comment(0);
            Helper.AssertThatViewResultIsNull(actual);
        }

        [TestCategory("Comment")]
        [TestMethod]
        public void _Comment_When_Id_Is_Not_Zero_Should_Return_Null()
        {
            //Act
            var actual = Controller._Comment(2);

            //Assert
            var viewResult = actual;
            Assert.AreEqual(viewResult.ViewBag.SpecialistId, 2);
            Assert.AreEqual(viewResult.ViewBag.CommentCount, "( 2 )");
        }

        //[TestCategory("GetSpecialistPrimaryPhoto")]
        //[TestMethod]
        //public void GetSpecialistPrimaryPhoto_Wher_Id_Is_Null_Should_Returns_Default_Specialist_Photo()
        //{
        //    //Act
        //    var actual = Controller.GetSpecialistPrimaryWorkPhoto(0);

        //    //Assert
        //    Assert.AreEqual(actual, "./../images/dotimages/home-handyman-projects.jpg");
        //}

        //[TestCategory("GetSpecialistPrimaryPhoto")]
        //[TestMethod]
        //public void GetSpecialistPrimaryPhoto_Wher_Id_Is_NOT_Null_()
        //{
        //    //Act
        //    var actual = Controller.GetSpecialistPrimaryWorkPhoto(2);

        //    //Assert
        //    Assert.AreEqual(actual, "PhotoPath");
        //}

        /// <summary>
        /// InsertComment 
        /// </summary>
        [TestCategory("InsertComment")]
        [TestMethod]
        public void InsertCommen_When_Id_Is_Zero_Should_Return_Null()
        {
            //Act
            var actual = Controller.InsertComment(null, "");
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));
            var routeResult = actual as RedirectToRouteResult;
            Debug.Assert(routeResult != null, "routeResult != null");
            Assert.AreEqual(routeResult.RouteValues["controller"], "Specialists");
            Assert.AreEqual(routeResult.RouteValues["action"], "Index");
        }

        [TestCategory("InsertComment")]
        [TestMethod]
        public void InsertComment_When_Poster_Is_Not_Authenticated_Should_Return_DefaultPoster()
        {
            //Act
            Controller.FakeHttpContext();

            //Context
            var actual = Controller.InsertComment(1000, "");

            //Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));
            var routeResult = actual as RedirectToRouteResult;
            Debug.Assert(routeResult != null, "routeResult != null");
            Assert.AreEqual(routeResult.RouteValues["action"], "Index");
            Assert.AreEqual(1000, routeResult.RouteValues["id"], "Route should map to the id parameter");
            Assert.AreEqual(true, routeResult.RouteValues["insertingnewcomment"], "Route should map to the insertingnewcomment parameter");

            var poster = new PosterHelper(Uow, new FakeMembershipProvider()).GetSendtoFriendPoster(new Uri("http://tempuri.org:80"));
            var defaultInsertedRecord = Uow.SpecialistProfileCommentRepository.
                FindBy(x => x.PosterId == poster.PosterId && x.SpecialistId == 1000);
            Assert.AreEqual(defaultInsertedRecord.First().PosterPhotoPath,
                "../../images/dotimages/single-property/agent-480x350.png");
        }

        [TestCategory("InsertComment")]
        [TestMethod]
        public void InsertComment_When_Poster_Is_Authenticated()
        {
            //Act
            Controller.FakeHttpContextWithAuthenticatedUser(LookUpRoles.Roles.Specialist);
            Controller.MockControllerContextForServerMap();

            var actual = Controller.InsertComment(2, "");

            //Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));
            var routeResult = actual as RedirectToRouteResult;
            Debug.Assert(routeResult != null, "routeResult != null");
            Assert.AreEqual(routeResult.RouteValues["action"], "Index");
            Assert.AreEqual(2, routeResult.RouteValues["id"], "Route should map to the id parameter");
            Assert.AreEqual(true, routeResult.RouteValues["insertingnewcomment"], "Route should map to the insertingnewcomment parameter");

            var poster = new PosterHelper(Uow, new FakeMembershipProvider()).GetSendtoFriendPoster(new Uri("http://tempuri.org:80"));
            var specialistCommentsInserted = Uow.SpecialistProfileCommentRepository.
                                                FindBy(x => x.PosterId == poster.PosterId && x.SpecialistId == 2);
            var specialistProfileComments = specialistCommentsInserted as IList<SpecialistProfileComment> ?? specialistCommentsInserted.ToList();


            if (specialistCommentsInserted != null && specialistProfileComments.Any())
            {
                Assert.AreEqual(specialistProfileComments.First().PosterProfileLink,
                "http://tempuri.org:80/SpecialistProfile/1");
            }
            else
            {
                Debug.Assert(specialistCommentsInserted == null || specialistProfileComments.First() == null, "No Records has been inserted");
                Assert.AreEqual("No- Records has been inserted", "No Records has been inserted");
            }
        }
        #endregion

        #region Hire Professional

        /// <summary>
        /// HireProfessional 
        /// </summary>
        [TestCategory("HireProfessional")]
        [TestMethod]
        public void HireProfessional()
        {
            var actual = Controller.HireProfessional(1, "");
            Assert.Inconclusive("Not Implemented Yet");
        }

        #endregion

        #region CleanUp
        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
            Uow.Dispose();
            Helper = null;
        }
        #endregion

    }
}
