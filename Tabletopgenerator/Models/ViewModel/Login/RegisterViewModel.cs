using System.ComponentModel.DataAnnotations;

namespace Tabletopgenerator.Models.ViewModel.Login
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string UserName { get; set; } = null!;

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Email Id is Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = null!;


        [Required]
        [DataType(DataType.Password)]
        [StringLength(120, MinimumLength = 8, ErrorMessage ="Password must be at least 8 characters.")]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
