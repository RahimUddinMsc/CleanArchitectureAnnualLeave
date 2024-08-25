using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Extensions;

public static class EntityEntrExtensions
{
    public static bool HasChangedOwnedEnities(this EntityEntry entry)
    {
        return entry.References.Any(e =>
            e.TargetEntry != null &&
            e.TargetEntry.Metadata.IsOwned() &&
            (e.TargetEntry.State == EntityState.Added || e.TargetEntry.State == EntityState.Modified)
        );
    }
}

