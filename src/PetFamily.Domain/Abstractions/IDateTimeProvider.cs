namespace PetFamily.Domain.Abstractions;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
