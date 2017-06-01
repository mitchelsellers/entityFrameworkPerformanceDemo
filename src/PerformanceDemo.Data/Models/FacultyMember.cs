using System.ComponentModel.DataAnnotations;

namespace PerformanceDemo.Data.Models
{
    public class FacultyMember
    {
        public int FacultyMemberId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(500)]
        public string EmailAddress { get; set; }

        [Required]
        public char Gender { get; set; }

        public virtual School School { get; set; }
    }
}