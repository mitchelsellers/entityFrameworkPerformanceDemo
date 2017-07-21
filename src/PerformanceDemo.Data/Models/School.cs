using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceDemo.Data.Models
{
    public class School
    {
        public int SchoolId { get; set; }

        [Required]
        public int SchoolTypeId { get; set; }

        [Required]
        [StringLength(500)]
        public string SchoolName { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }


        public virtual SchoolType SchoolType { get; set; }
        public virtual AddressState State { get; set; }
        public virtual ICollection<FacultyMember> FacultyMembers { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Classroom> Classrooms { get; set; }
        public virtual ICollection<CourseSession> CourseSessions { get; set; }
    }
}