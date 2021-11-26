using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SetupApi.Models.Course;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SetupApi.Controllers
{
    [Route("api/v1/ courses")]
    [ApiController]
    [Authorize] //protege api
    public class CourseController : ControllerBase
    {
        /// <summary>
        /// This service permits to register a course for a user authenticated.
        /// </summary>
        /// <returns>Returns ok status</returns>

        [SwaggerResponse(statusCode: 201, description: "Course registration sucessful")]
        [SwaggerResponse(statusCode: 401, description: "Not allowed")]
        [HttpPost]
        [Route("")]

        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            var usercoding = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", courseViewModelInput);
        }

        /// <summary>
        /// This service permits to get all courses actives in user.
        /// </summary>
        /// <returns>Returns ok status</returns>

        [SwaggerResponse(statusCode: 201, description: "Succesful to get courses")]
        [SwaggerResponse(statusCode: 401, description: "Not allowed")]
        [HttpGet]
        [Route("")]

        public async Task<IActionResult> Get()
        {
            var courses = new List<CourseViewModelOutput>();

            //var usercoding = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            courses.Add(new CourseViewModelOutput()
            {
                Login = "",
                Description = "Test",
                Name = "Test"
            });
            return Ok(courses);
        }
    }
}
