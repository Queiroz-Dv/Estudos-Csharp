using APIStudy.Models.Courses;
using APIStudy.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Threading.Tasks;

namespace APIStudy.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class CourseController : Controller
    {
        private readonly ICourseServices _courseServices;

        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        public IActionResult Register()
        {

            return View();
        }
     
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCourseInput registerCourseInput)
        {
            try
            {
                var course = await _courseServices.Register(registerCourseInput);
                ModelState.AddModelError("", "Register successful");
            }
            catch(ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error. Try again.");
            }
            return View();
        }
        
        public async Task<IActionResult> List()
        {
            var course = await _courseServices.lGet();

            return View(course);
        }

    }
}
