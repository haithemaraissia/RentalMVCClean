using System.Web.Security;
using Moq;
using RentalMobile.Helpers.Membership;
using TestProject.UnitTest.Helpers.Fake;

namespace TestProject.UnitTest.Helpers
{
    public class MockMemberShipService
    {

        public IMembershipService MockSaraSpecialistMembership()
        {
            var membershipMock = new Mock<IMembershipService>();
            var userMock = new Mock<MembershipUser>();
            var saraSpecialist = new FakeMembershipProvider();
            userMock.Setup(u => u.ProviderUserKey).Returns(saraSpecialist.FakeUserSara.ProviderUserKey);
            userMock.Setup(u => u.UserName).Returns(saraSpecialist.FakeUserSara.UserName);
            membershipMock.Setup(s => s.GetUser(It.IsAny<string>())).Returns(userMock.Object);



            return membershipMock.Object;
        }

        public IMembershipService MockFredTenantMembership()
        {
            var membershipMock = new Mock<IMembershipService>();
            var userMock = new Mock<MembershipUser>();
            var fredTenant = new FakeMembershipProvider();
            userMock.Setup(u => u.ProviderUserKey).Returns(fredTenant.FakeUserJeff.ProviderUserKey);
            userMock.Setup(u => u.UserName).Returns(fredTenant.FakeUserJeff.UserName);
            membershipMock.Setup(s => s.GetUser(It.IsAny<string>())).Returns(userMock.Object);
            return membershipMock.Object;
        }

        public IMembershipService MockJeffProviderMembership()
        {
            var membershipMock = new Mock<IMembershipService>();
            var userMock = new Mock<MembershipUser>();
            var jeffProvider = new FakeMembershipProvider();
            userMock.Setup(u => u.ProviderUserKey).Returns(jeffProvider.FakeUserJeff.ProviderUserKey);
            userMock.Setup(u => u.UserName).Returns(jeffProvider.FakeUserJeff.UserName);
            membershipMock.Setup(s => s.GetUser(It.IsAny<string>())).Returns(userMock.Object);
            return membershipMock.Object;
        }

        public IMembershipService MockLisaOwnerMembership()
        {
            var membershipMock = new Mock<IMembershipService>();
            var userMock = new Mock<MembershipUser>();
            var lisaOwner = new FakeMembershipProvider();
            userMock.Setup(u => u.ProviderUserKey).Returns(lisaOwner.FakeUserLisa.ProviderUserKey);
            userMock.Setup(u => u.UserName).Returns(lisaOwner.FakeUserLisa.UserName);
            membershipMock.Setup(s => s.GetUser(It.IsAny<string>())).Returns(userMock.Object);
            return membershipMock.Object;
        }

        public IMembershipService MockMikeAgentMembership()
        {
            var membershipMock = new Mock<IMembershipService>();
            var userMock = new Mock<MembershipUser>();
            var mikeAgent = new FakeMembershipProvider();
            userMock.Setup(u => u.ProviderUserKey).Returns(mikeAgent.FakeUserMike.ProviderUserKey);
            userMock.Setup(u => u.UserName).Returns(mikeAgent.FakeUserMike.UserName);
            membershipMock.Setup(s => s.GetUser(It.IsAny<string>())).Returns(userMock.Object);
            return membershipMock.Object;
        }

    }
}
