using System.ComponentModel.DataAnnotations;

namespace SoftDesignTesteTecnico.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The email field is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
