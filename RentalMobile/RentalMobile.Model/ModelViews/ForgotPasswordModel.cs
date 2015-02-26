using System.ComponentModel.DataAnnotations;

namespace RentalMobile.Model.ModelViews
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }
    }
}