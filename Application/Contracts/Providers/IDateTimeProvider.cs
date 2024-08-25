namespace Application.Contracts.Providers;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}

