using AnnualLeave.Models;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence
{
    public class AnnualLeaveDbContext : DbContext
    {
        public AnnualLeaveDbContext(DbContextOptions<AnnualLeaveDbContext> options) : base(options)
        {
        }

        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnnualLeaveDbContext).Assembly);
        }
    }
}
