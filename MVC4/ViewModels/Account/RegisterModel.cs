using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace MVC4.ViewModels.Account
{
    public class RegisterModel
    {
        [Required]
        [Email]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "First name")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}