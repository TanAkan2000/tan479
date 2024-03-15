#nullable disable

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
    public class BlogModel : RecordBase
    {
        #region Entity Properties
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishedAt { get; set; }
        #endregion

        #region Extra Properties
        [DisplayName("Content")]
        public string ContentOutput { get; set; }

        [DisplayName("PublishedAt")]
        public string PublishedAtOutput { get; set; }
        #endregion
    }
}
