using MediatR;
using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Abstraction.Persistense;
using PetFamily.Domain.Abstractions;
using PetFamily.Infrastructure.AssemblyMarkers;

namespace PetFamily.Infrastructure.Contexts;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public ApplicationDbContext(
        DbContextOptions options,
        IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IInfrastructureAssemblyMarker).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(entity => entity.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();
                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        // Пока так потом на Outbox перейдем

        await PublishDomainEvent(domainEvents);

        return await base.SaveChangesAsync(cancellationToken);
    }

    private async Task PublishDomainEvent(List<IDomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }
}
