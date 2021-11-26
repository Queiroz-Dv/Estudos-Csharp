using System.ComponentModel.DataAnnotations;

namespace SetupApi.Models.Users
{
    public class RegisterViewModelInput
    {
        [Required(ErrorMessage = "Login is obrigatory!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "E-mail is obrigatory!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is obrigatory!")]
        public string Password { get; set; }
    }
}
