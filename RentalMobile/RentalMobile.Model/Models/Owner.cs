//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalMobile.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public System.Guid GUID { get; set; }
        public string VCard { get; set; }
        public string Skype { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string GooglePlus { get; set; }
        public string Photo { get; set; }
        public string GoogleMap { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string CountryCode { get; set; }
        public Nullable<bool> YouTubeVideo { get; set; }
        public string YouTubeVideoURL { get; set; }
        public Nullable<bool> VimeoVideo { get; set; }
        public string VimeoVideoURL { get; set; }
    }
}
