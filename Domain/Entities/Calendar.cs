using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualLeave.Models
{
    public class Calendar : AuditableEntity
    {
        public Guid CalendarId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int AvailableMinutes { get; set; }
    }
}