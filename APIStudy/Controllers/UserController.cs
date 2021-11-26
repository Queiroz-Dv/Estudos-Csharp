using APIStudy.Models.Users;
using APIStudy.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIStudy.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModelInput registerViewModelInput)
        {
            try
            {
              var user = await  _userService.Register(registerViewModelInput);
                ModelState.AddModelError("", "Register successful");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error. Try again.");
            }

            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var httpClient = new HttpClient(clientHandler);
            httpClient.BaseAddress = new Uri("/");
            var registerViewModelInputJson = JsonConvert.SerializeObject(registerViewModelInput);
            var httpContent = new StringContent(registerViewModelInputJson, Encoding.UTF8, "application/json");

            var httpPost = httpClient.PostAsync("/api/v1/user/register", httpContent).GetAwaiter().GetResult();
            return View();

            /*
            if (httpPost.StatusCode == System.Net.HttpStatusCode.Created)
            {
                
                ModelState.AddModelError("","Register successful");
            }
            else
            {
                
            }
            */
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModelInput loginViewModelInput)
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var user = await _userService.Login(loginViewModelInput);

                var claims = new List<Claim>
                {   new Claim(ClaimTypes.NameIdentifier, user.User.Coding.ToString()),
                    new Claim(ClaimTypes.Name, user.User.Login),
                    new Claim(ClaimTypes.Email, user.User.Email),
                    new Claim("token", user.Token),
                };


                var claimsIdebtity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddDays(1))
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal());

                //var user = await _userService.Login(loginViewModelInput);
                ModelState.AddModelError("", $"Login successful {user.Token}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error. Try again.");
            }

            return View();
        }

        public IActionResult EffectLogoff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Logoff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction($"{nameof(Login)}");
        }
    }
}
