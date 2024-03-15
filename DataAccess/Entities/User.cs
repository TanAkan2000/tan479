using DataAccess.Enum;
#nullable disable

using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User : RecordBase
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public AuthorType AuthorType { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthor { get; set; }
        public List<Blog> blogs { get; set; }
    }
}
