using PetFamily.Domain.Abstractions;
using PetFamily.Domain.Pets.ValueObjects;

namespace PetFamily.Domain.Pets.Entityes;

public class PetPhoto : Entity
{
    public Content Content { get; private set; }

    public Guid PetId { get; private set; }

    private PetPhoto(
        Guid id, 
        Guid petId, 
        Content content) : base(id)
    {
        PetId = petId;
        Content = content;
    }

#pragma warning disable CS8618
    private PetPhoto()
#pragma warning restore CS8618
    { 
        // efcore
    }

    internal static PetPhoto Create(
        Guid petId,
        Content content, 
        Guid? id = null)
    {
        return new PetPhoto(
            id ?? Guid.NewGuid(),
            petId,
            content);
    }
}
