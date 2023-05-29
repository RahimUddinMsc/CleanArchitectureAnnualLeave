using AnnualLeave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> builder)
        {
            builder.Property(v => v.Day).IsRequired();
            builder.Property(v => v.Month).IsRequired();
            builder.Property(v => v.Year).IsRequired();
            builder.Property(v => v.AvailableMinutes).IsRequired();
        }
    }
}
