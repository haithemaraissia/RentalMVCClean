using System.ComponentModel.DataAnnotations;

namespace RentalMobile.Model.ModelViews
{
    public class ChangeEmail
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }
    }
}