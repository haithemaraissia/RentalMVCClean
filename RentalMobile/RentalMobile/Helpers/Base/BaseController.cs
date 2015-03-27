﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Pattern.UnitOfWork;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Base
{
    public class BaseController : Controller
    {
        //public IGenericUnitofWork _unitOfWork;

        //public BaseController(IGenericUnitofWork uow)
        //{
        //    _unitOfWork = uow;
        //}
        //public BaseController()
        //{
        //    _unitOfWork = new UnitofWork();
        //}



        public new HttpContextBase HttpContext
        {
            get
            {
                return ControllerContext != null ? ControllerContext.HttpContext : new HttpContextWrapper(System.Web.HttpContext.Current);
                //HttpContextWrapper context =
                //    new HttpContextWrapper(System.Web.HttpContext.Current);
                //return context;
            }
        }


        //public new HttpContextBase HttpContext
        //{
        //    get
        //    {
        //        return ControllerContext != null ? ControllerContext.HttpContext : null;
        //    }
        //}
        #region Membership provider

        public IMembershipService MembershipService;



        private MembershipProvider _membershipProvider;
        public virtual MembershipProvider MembershipProvider
        {
            get
            {
                if (_membershipProvider == null)
                {
                    _membershipProvider = System.Web.Security.Membership.Provider;
                }
                return _membershipProvider;
            }
            set
            {
                _membershipProvider = value;
            }
        }

        #endregion

    }
}