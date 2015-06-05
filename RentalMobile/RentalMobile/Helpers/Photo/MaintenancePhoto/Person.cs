using System.Collections.Generic;

namespace RentalMobile.Helpers.Photo.MaintenancePhoto
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Address> Addresses { get; set; }
    }
}