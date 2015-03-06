using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeOwnerShowingCalendars
    { 
       public List<OwnerShowingCalendar> MyOwnerShowingCalendars;

       public FakeOwnerShowingCalendars()
        {
            InitializeOwnerShowingCalendarList();
        }

       public void InitializeOwnerShowingCalendarList()
        {
            MyOwnerShowingCalendars = new List<OwnerShowingCalendar> {
                FirstOwnerShowingCalendar(), 
                SecondOwnerShowingCalendar(),
                ThirdOwnerShowingCalendar()
            };
        }

       public OwnerShowingCalendar FirstOwnerShowingCalendar()
        {

            var firstOwnerShowingCalendar = new OwnerShowingCalendar {

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

            return firstOwnerShowingCalendar;
        }

       public OwnerShowingCalendar SecondOwnerShowingCalendar()
        {

            var secondOwnerShowingCalendar = new OwnerShowingCalendar {

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

            return secondOwnerShowingCalendar;
        }

       public OwnerShowingCalendar ThirdOwnerShowingCalendar()
        {

            var thirdOwnerShowingCalendar = new OwnerShowingCalendar {

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

            return thirdOwnerShowingCalendar;
        }

        ~FakeOwnerShowingCalendars()
        {
            MyOwnerShowingCalendars = null;
        }
    }
}


    