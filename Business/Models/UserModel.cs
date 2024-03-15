#nullable disable

using DataAccess.Enum;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class UserModel : RecordBase
    {
        #region Entity Properties
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public AuthorType AuthorType { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthor { get; set; }
        #endregion

        #region Extra Properties
        [DisplayName("Birth Date")]
        public string BirthDateOutput { get; set; }

        [DisplayName("Email")]
        public string EmailOutput { get; set; }

        [DisplayName("Password")]
        public string PasswordOutput { get; set; }

        [DisplayName("IsAuthor")]
        public string IsAuthorOutput { get; set; }

        #endregion
    }
}
