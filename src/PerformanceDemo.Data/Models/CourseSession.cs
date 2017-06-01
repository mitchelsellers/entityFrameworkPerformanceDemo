using System;
using System.ComponentModel.DataAnnotations;

namespace PerformanceDemo.Data.Models
{
    public class CourseSession
    {
        public int CourseSessionId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int SchoolId { get; set; }

        [Required]
        [StringLength(50)]
        public string SessionIdentifier { get; set; }

        [Required]
        public DateTime RegistrationOpens { get; set; }

        [Required]
        public DateTime RegistrationCloses { get; set; }

        [Required]
        public DateTime ClassStarts { get; set; }

        [Required]
        public DateTime ClassEnds { get; set; }
        [Required]
        public int InstructorId { get; set; }



        public virtual Course Course { get; set; }
        public virtual School School { get; set; }
        public virtual FacultyMember Instructor { get; set; }
    }
}