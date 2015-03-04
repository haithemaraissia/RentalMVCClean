using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeOwnerPendingShowingCalendarModelView
    { 
       public List<OwnerPendingShowingCalendarModelView> MyOwnerPendingShowingCalendarModelViews;

       public FakeOwnerPendingShowingCalendarModelView()
        {
            InitializeOwnerPendingShowingCalendarModelViewList();
        }

       public void InitializeOwnerPendingShowingCalendarModelViewList()
        {
            MyOwnerPendingShowingCalendarModelViews = new List<OwnerPendingShowingCalendarModelView> {
                FirstOwnerPendingShowingCalendarModelView(), 
                SecondOwnerPendingShowingCalendarModelView(),
                ThirdOwnerPendingShowingCalendarModelView()
            };
        }

       public OwnerPendingShowingCalendarModelView FirstOwnerPendingShowingCalendarModelView()
        {

            var firstOwnerPendingShowingCalendarModelView = new OwnerPendingShowingCalendarModelView {

                 Unit = new Unit()
,
                 OwnerPendingShowingCalendar = new OwnerPendingShowingCalendar()

         
 };

            return firstOwnerPendingShowingCalendarModelView;
        }

       public OwnerPendingShowingCalendarModelView SecondOwnerPendingShowingCalendarModelView()
        {

            var secondOwnerPendingShowingCalendarModelView = new OwnerPendingShowingCalendarModelView {

                 Unit = new Unit()
,
                 OwnerPendingShowingCalendar = new OwnerPendingShowingCalendar()

        
 };

            return secondOwnerPendingShowingCalendarModelView;
        }

       public OwnerPendingShowingCalendarModelView ThirdOwnerPendingShowingCalendarModelView()
        {

            var thirdOwnerPendingShowingCalendarModelView = new OwnerPendingShowingCalendarModelView {

                 Unit = new Unit()
,
                 OwnerPendingShowingCalendar = new OwnerPendingShowingCalendar()

 
 };

            return thirdOwnerPendingShowingCalendarModelView;
        }

        ~FakeOwnerPendingShowingCalendarModelView()
        {
            MyOwnerPendingShowingCalendarModelViews = null;
        }
    }
}


    