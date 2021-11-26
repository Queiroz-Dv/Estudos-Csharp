using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SetupApi.Filters;
using SetupApi.Models;
using SetupApi.Models.Users;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SetupApi.Controllers
{
    [Route("api/v1/user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        /// <summary>
        /// This service allow to authenticate an user to registered and activated.
        /// </summary>
        /// <param name="loginViewModelInput">Login's view model</param>
        /// <returns>Returns ok status</returns>
        [SwaggerResponse(statusCode: 200, description: "Authentication Successful", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Obrigatory fields", Type = typeof(ValidateViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal error", Type = typeof(GenericErrorViewModel))]

        [HttpPost]
        [Route("login")]
        [ValidateModelStateCustom]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            ///if (ModelState.IsValid)
            /// {
            ///   return BadRequest(new ValidateViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            /// }
            var userViewModelOutput = new UserViewModelOutput()
            {
                Coding = 1,
                Login = "EduardoQueiroz",
                Email = "ed@gmail.com"
            };

            var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qY#7");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Coding.ToString()),
                    new Claim(ClaimTypes.Name, userViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, userViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new
            {
                Token = token,
                User = userViewModelOutput
            });
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            return Created("", registerViewModelInput);
        }
    }
}
