using System.ComponentModel.DataAnnotations;

namespace APIStudy.Models.Users
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "Login is obrigatory.")]
        public string Login { get; set; }

        public string Senha { get; set; }
    }
}
