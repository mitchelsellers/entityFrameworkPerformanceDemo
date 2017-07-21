using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceDemo.Data.Models
{
    public class SchoolType
    {
        public int SchoolTypeId { get; set; }

        [Required]
        public string SchoolTypeName { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}