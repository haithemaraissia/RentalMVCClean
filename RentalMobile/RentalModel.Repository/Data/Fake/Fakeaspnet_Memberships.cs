using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetMemberships
    { 
       public List<aspnet_Membership> MyaspnetMemberships;

       public FakeaspnetMemberships()
        {
            Initializeaspnet_MembershipList();
        }

       public void Initializeaspnet_MembershipList()
        {
            MyaspnetMemberships = new List<aspnet_Membership> {
                Firstaspnet_Membership(), 
                Secondaspnet_Membership(),
                Thirdaspnet_Membership()
            };
        }

       public aspnet_Membership Firstaspnet_Membership()
        {

            var firstaspnetMembership = new aspnet_Membership {

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

            return firstaspnetMembership;
        }

       public aspnet_Membership Secondaspnet_Membership()
        {

            var secondaspnetMembership = new aspnet_Membership {

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

            return secondaspnetMembership;
        }

       public aspnet_Membership Thirdaspnet_Membership()
        {

            var thirdaspnetMembership = new aspnet_Membership {

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

            return thirdaspnetMembership;
        }

        ~FakeaspnetMemberships()
        {
            MyaspnetMemberships = null;
        }
    }
}


    