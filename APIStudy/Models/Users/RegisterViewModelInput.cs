using System.ComponentModel.DataAnnotations;

namespace APIStudy.Models.Users
{
    public class RegisterViewModelInput
    {
        [Required(ErrorMessage ="Login is obrigatory.")]

        public string Login { get; set; }

        [Required(ErrorMessage = "Email is obrigatory.")]
        [EmailAddress(ErrorMessage = "E-mail is invalid.")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
