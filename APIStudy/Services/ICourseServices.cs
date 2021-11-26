using APIStudy.Models.Courses;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIStudy.Services
{
    public interface ICourseServices
    {
        [Post("/api/v1/courses")]
        [Headers("Authorization: Bearer")]
        Task<RegisterCourseModelOutput> Register(RegisterCourseInput registerCourseInput);

        [Get("/api/v1/courses")]
        [Headers("Authorization: Bearer")]
        Task<List<ListCourseModelOutput>> lGet();
    }
}
