using FluentValidation;

namespace PetFamily.Domain.Pets.ValueObjects;

public record Name
{
    public string Value { get; init; } = null!;

    private Name(string value) => Value = value;

    public static Name Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ValidationException("value");
        }

        return new Name(value);
    }
}