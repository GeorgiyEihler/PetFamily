namespace PetFamily.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; init; }

    protected Entity(Guid id) =>
        Id = id;

    protected Entity()
    {
    }

    public override bool Equals(object? other)
    {
        if (other is null || other.GetType() != GetType())
        {
            return false;
        }

        return ((Entity)other).Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
