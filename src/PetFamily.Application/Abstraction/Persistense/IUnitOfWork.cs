namespace PetFamily.Application.Abstraction.Persistense;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
