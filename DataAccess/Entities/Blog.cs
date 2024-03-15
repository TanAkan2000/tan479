using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Blog : RecordBase
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishedAt { get; set; }

        public int UserId { get; set; } // Foreign key for user
        public User User { get; set; }

        public int SectionId { get; set; } // Foreign key for section
        public Section Section { get; set; }
    }
}
