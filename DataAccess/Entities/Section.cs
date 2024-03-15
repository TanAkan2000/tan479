#nullable disable

using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Section : RecordBase
    {
        public string SectionName { get; set; }

        public List<Blog> blogs { get; set; }
    }
}
