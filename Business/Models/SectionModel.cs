#nullable disable

using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class SectionModel : RecordBase
    {
        #region Entity Properties
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "{0} must be minimum {2} and maximum {1} characters!")]
        [DisplayName("Section Name")]
        public string SectionName { get; set; }
        #endregion



        #region Extra Properties
        [DisplayName("Blog Count")]
        public int BlogCountOutput { get; set; }

        [DisplayName("Blog Names")]
        public string BlogNamesOutput { get; set; }
        #endregion
    }
}
