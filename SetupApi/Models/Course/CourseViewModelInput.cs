using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SetupApi.Models.Course
{
    public class CourseViewModelInput
    {
        [Required(ErrorMessage = "Name is obrigatory.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is obrigatory.")]
        public string Description { get; set; }
    }
}
