using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PerformanceDemo.Data.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}