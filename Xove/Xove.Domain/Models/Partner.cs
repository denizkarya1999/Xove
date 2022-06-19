using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xove.Domain.Models
{
    public class Partner : BaseEntity
    {
        public int Age { get; set; }
        public string CurrentPosition { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Partner()
        {
            Id = Guid.NewGuid();
        }
        public string Interests { get; set; }
        public string Location { get; set; }
        public string SexualOrientation { get; set; }
        public string ShortBiography { get; set; }
    }
}
