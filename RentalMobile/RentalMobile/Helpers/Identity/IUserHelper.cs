using System;
using RentalMobile.Helpers.Identity.Abstract;

namespace RentalMobile.Helpers.Identity
{
    public interface IUserHelper : IUserIdentity,IPosterHelper,ILocationHelper,ISpecialistHelper
    {
    }
}