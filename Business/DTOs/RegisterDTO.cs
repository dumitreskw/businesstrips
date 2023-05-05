using BusinessTrips.Business.Validators;
using System.ComponentModel.DataAnnotations;

namespace BusinessTrips.Business.DTOs;

public class RegisterDTO
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    [Required]
    [Display(Name = "Accept T&Cs")]
    [EnableRequired("Please accept Terms and Conditions in order to register")]
    public bool TCAccepted { get; set; }
}
