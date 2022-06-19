using System;

namespace Xove.Domain.Models
{
    public abstract class BaseAudit
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
