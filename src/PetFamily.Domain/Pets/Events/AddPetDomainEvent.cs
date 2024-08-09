using PetFamily.Domain.Abstractions;

namespace PetFamily.Domain.Pets.Events;

internal record AddPetDomainEvent(Guid PetId) : IDomainEvent;
