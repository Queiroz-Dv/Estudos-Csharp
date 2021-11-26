using System.ComponentModel.DataAnnotations;

namespace SetupApi.Models.Users
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "Login is obrigatory")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is obrigatory")]
        public string Senha { get; set; }
    }
}
