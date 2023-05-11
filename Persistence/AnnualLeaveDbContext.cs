using AnnualLeave.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class AnnualLeaveDbContext : DbContext
    {
        public AnnualLeaveDbContext(DbContextOptions<AnnualLeaveDbContext> options) : base(options)
        {

        }

        public DbSet<Calendar> Calendar { get; set; }

    }
}
