using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeOwnerPendingShowingCalendar
    { 
       public List<OwnerPendingShowingCalendar> MyOwnerPendingShowingCalendars;

       public FakeOwnerPendingShowingCalendar()
        {
            InitializeOwnerPendingShowingCalendarList();
        }

       public void InitializeOwnerPendingShowingCalendarList()
        {
            MyOwnerPendingShowingCalendars = new List<OwnerPendingShowingCalendar> {
                FirstOwnerPendingShowingCalendar(), 
                SecondOwnerPendingShowingCalendar(),
                ThirdOwnerPendingShowingCalendar()
            };
        }

       public OwnerPendingShowingCalendar FirstOwnerPendingShowingCalendar()
        {

            var firstOwnerPendingShowingCalendar = new OwnerPendingShowingCalendar {

                 EventID = new Int32()
,
                 EventTitle = null,
                 StartDate = new DateTime(),
                 EndDate = new DateTime(),
                 IsAllDay = new Boolean(),
                 OwnerId = new Int32()
,
                 UnitId = new Int32()
,
                 RequesterName = null,
                 RequesterEmail = null,
                 RequesterTelephone = null
    
 };

            return firstOwnerPendingShowingCalendar;
        }

       public OwnerPendingShowingCalendar SecondOwnerPendingShowingCalendar()
        {

            var secondOwnerPendingShowingCalendar = new OwnerPendingShowingCalendar {

                 EventID = new Int32()
,
                 EventTitle = null,
                 StartDate = new DateTime(),
                 EndDate = new DateTime(),
                 IsAllDay = new Boolean(),
                 OwnerId = new Int32()
,
                 UnitId = new Int32()
,
                 RequesterName = null,
                 RequesterEmail = null,
                 RequesterTelephone = null
        
 };

            return secondOwnerPendingShowingCalendar;
        }

       public OwnerPendingShowingCalendar ThirdOwnerPendingShowingCalendar()
        {

            var thirdOwnerPendingShowingCalendar = new OwnerPendingShowingCalendar {

                 EventID = new Int32()
,
                 EventTitle = null,
                 StartDate = new DateTime(),
                 EndDate = new DateTime(),
                 IsAllDay = new Boolean(),
                 OwnerId = new Int32()
,
                 UnitId = new Int32()
,
                 RequesterName = null,
                 RequesterEmail = null,
                 RequesterTelephone = null
 
 };

            return thirdOwnerPendingShowingCalendar;
        }

        ~FakeOwnerPendingShowingCalendar()
        {
            MyOwnerPendingShowingCalendars = null;
        }
    }
}


    