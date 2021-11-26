using APIStudy.Models.Users;
using Refit;
using System.Threading.Tasks;

namespace APIStudy.Services
{
    public interface IUserService
    {
        [Post("/api/v1/user/register")]
        Task<RegisterViewModelInput> Register(RegisterViewModelInput registerViewModelInput);

        [Post("/api/v1/user/login")]
        Task<LoginViewModelOutput> Login(LoginViewModelInput loginViewModelInput);
    }
}
