
using System;
using Xove.Domain.Interfaces;

namespace Xove.Api.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
