using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xove.Shared.Features.Partners
{
    public class PartnerFormModel
    {
        public int Age { get; set; }
        public string CurrentPosition { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Guid Id { get; set; }
        public string Interests { get; set; }
        public string Location { get; set; }
        public string SexualOrientation { get; set; }
        public string ShortBiography { get; set; }
    }
}
