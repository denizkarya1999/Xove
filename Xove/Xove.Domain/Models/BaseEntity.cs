using System;

namespace Xove.Domain.Models
{
    public abstract class BaseEntity : BaseAudit
    {
        public Guid Id { get; set; }
    }
}
