using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceDemo.Data.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(500)]
        [Index(IsUnique = true)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(10)]
        [Index(IsUnique = true)]
        public string CourseAcronym { get; set; }

        [Required]
        public string CourseDescription { get; set; }

        public bool IsActive { get; set; }

        public Department Department { get; set; }
        public ICollection<School> OfferedInSchools { get; set; }
        public ICollection<CourseSession> Sessions { get; set; }
    }
}