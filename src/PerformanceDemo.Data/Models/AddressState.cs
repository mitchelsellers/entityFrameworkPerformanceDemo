using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PerformanceDemo.Data.Models
{
    public class AddressState
    {
        [Key]
        public int StateId { get; set; }

        [StringLength(2)]
        public string StateCode { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}