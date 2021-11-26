using System.ComponentModel.DataAnnotations;

namespace APIStudy.Models.Courses
{
    public class RegisterCourseInput
    {
        [Required(ErrorMessage = "Name is obrigatory.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is obrigatory.")]
        public string Description { get; set; }
    }
}
