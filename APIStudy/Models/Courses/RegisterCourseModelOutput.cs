using System.ComponentModel.DataAnnotations;

namespace APIStudy.Models.Courses
{
    public class RegisterCourseModelOutput   
    {
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string Login { get; set; }
    }
}
