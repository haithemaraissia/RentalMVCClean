using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_Membership
    { 
       public List<aspnet_Membership> Myaspnet_Memberships;

       public Fakeaspnet_Membership()
        {
            Initializeaspnet_MembershipList();
        }

       public void Initializeaspnet_MembershipList()
        {
            Myaspnet_Memberships = new List<aspnet_Membership> {
                Firstaspnet_Membership(), 
                Secondaspnet_Membership(),
                Thirdaspnet_Membership()
            };
        }

       public aspnet_Membership Firstaspnet_Membership()
        {

            var firstaspnet_Membership = new aspnet_Membership {

                 ApplicationId = new Guid()
,
                 UserId = new Guid()
,
                 Password = null,
                 PasswordFormat = new Int32()
,
                 PasswordSalt = null,
                 MobilePIN = null,
                 Email = null,
                 LoweredEmail = null,
                 PasswordQuestion = null,
                 PasswordAnswer = null,
                 IsApproved = new Boolean()
,
                 IsLockedOut = new Boolean()
,
                 CreateDate = new DateTime()
,
                 LastLoginDate = new DateTime()
,
                 LastPasswordChangedDate = new DateTime()
,
                 LastLockoutDate = new DateTime()
,
                 FailedPasswordAttemptCount = new Int32()
,
                 FailedPasswordAttemptWindowStart = new DateTime()
,
                 FailedPasswordAnswerAttemptCount = new Int32()
,
                 FailedPasswordAnswerAttemptWindowStart = new DateTime()
,
                 Comment = null,
                 aspnet_Applications = new aspnet_Applications()
,
                 aspnet_Users = new aspnet_Users()

    
 };

            return firstaspnet_Membership;
        }

       public aspnet_Membership Secondaspnet_Membership()
        {

            var secondaspnet_Membership = new aspnet_Membership {

                 ApplicationId = new Guid()
,
                 UserId = new Guid()
,
                 Password = null,
                 PasswordFormat = new Int32()
,
                 PasswordSalt = null,
                 MobilePIN = null,
                 Email = null,
                 LoweredEmail = null,
                 PasswordQuestion = null,
                 PasswordAnswer = null,
                 IsApproved = new Boolean()
,
                 IsLockedOut = new Boolean()
,
                 CreateDate = new DateTime()
,
                 LastLoginDate = new DateTime()
,
                 LastPasswordChangedDate = new DateTime()
,
                 LastLockoutDate = new DateTime()
,
                 FailedPasswordAttemptCount = new Int32()
,
                 FailedPasswordAttemptWindowStart = new DateTime()
,
                 FailedPasswordAnswerAttemptCount = new Int32()
,
                 FailedPasswordAnswerAttemptWindowStart = new DateTime()
,
                 Comment = null,
                 aspnet_Applications = new aspnet_Applications()
,
                 aspnet_Users = new aspnet_Users()

        
 };

            return secondaspnet_Membership;
        }

       public aspnet_Membership Thirdaspnet_Membership()
        {

            var thirdaspnet_Membership = new aspnet_Membership {

                 ApplicationId = new Guid()
,
                 UserId = new Guid()
,
                 Password = null,
                 PasswordFormat = new Int32()
,
                 PasswordSalt = null,
                 MobilePIN = null,
                 Email = null,
                 LoweredEmail = null,
                 PasswordQuestion = null,
                 PasswordAnswer = null,
                 IsApproved = new Boolean()
,
                 IsLockedOut = new Boolean()
,
                 CreateDate = new DateTime()
,
                 LastLoginDate = new DateTime()
,
                 LastPasswordChangedDate = new DateTime()
,
                 LastLockoutDate = new DateTime()
,
                 FailedPasswordAttemptCount = new Int32()
,
                 FailedPasswordAttemptWindowStart = new DateTime()
,
                 FailedPasswordAnswerAttemptCount = new Int32()
,
                 FailedPasswordAnswerAttemptWindowStart = new DateTime()
,
                 Comment = null,
                 aspnet_Applications = new aspnet_Applications()
,
                 aspnet_Users = new aspnet_Users()

 
 };

            return thirdaspnet_Membership;
        }

        ~Fakeaspnet_Membership()
        {
            Myaspnet_Memberships = null;
        }
    }
}


    