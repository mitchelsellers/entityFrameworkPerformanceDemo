using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PerformanceDemo.Data.Models
{
    public class Classroom
    {
        public int ClassroomId { get; set; }

        [Required]
        public int SchoolId { get; set; }

        [Required]
        public string Roomname { get; set; }

        [Required]
        public int MaxStudents { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<CourseSession> Classes { get; set; }
    }
}