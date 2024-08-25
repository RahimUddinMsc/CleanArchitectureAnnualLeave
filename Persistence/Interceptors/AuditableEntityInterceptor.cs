using Application.Contracts.Providers;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Persistence.Extensions;

namespace Persistence.Interceptors;

public class AuditableEntityInterceptor(IDateTimeProvider dateTimeProvider) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        AddAuditLogs(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var utcNow = dateTimeProvider.UtcNow;

        foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "System Interceptor";
                entry.Entity.CreatedDate = utcNow;
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEnities())
            {
                entry.Entity.LastModifiedBy = "System Interceptor";
                entry.Entity.LastModifiedDate = utcNow;
            }
        }
    }

    private void AddAuditLogs(DbContext? context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var utcNow = dateTimeProvider.UtcNow;

        foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;

            var tableName = entry.Metadata.GetTableName();
            var recordId = entry.Property("Id").CurrentValue?.ToString();

            if (recordId == null)
                continue;

            foreach (var property in entry.Properties)
            {
                var originalValue = property.OriginalValue?.ToString();
                var updateValue = property.CurrentValue?.ToString();

                if (property.Metadata.Name.Contains("Modified") || property.Metadata.Name.Contains("Created"))
                    continue;

                if (!property.IsModified || originalValue?.Equals(updateValue, StringComparison.OrdinalIgnoreCase) == true)
                    continue;


                context.Set<AuditLog>().AddAsync(new AuditLog()
                {
                    Id = Guid.NewGuid(),
                    RecordId = Guid.Parse(recordId),
                    TableName = tableName ?? "unknown",
                    ColumnName = property.Metadata.Name,
                    OriginalValue = originalValue ?? "unknown", 
                    UpdatedValue = updateValue ?? "unknown",
                    ModifiedBy = "System Interceptor",
                    ModifiedDate = dateTimeProvider.UtcNow
                });
            }                       
        }
    }
}

