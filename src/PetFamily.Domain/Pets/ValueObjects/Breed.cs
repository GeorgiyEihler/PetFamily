using FluentValidation.Results;
using FluentValidation;

namespace PetFamily.Domain.Pets.ValueObjects;

public record Breed
{
    public string Value { get; init; } = null!;

    private Breed(string value) => Value = value;

    public static Breed Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            var message = "Breed can not be enpty string!";

            throw new ValidationException(message,
            [
                new ValidationFailure(nameof(Breed), message)
            ]);
        }

        return new Breed(value);
    }
}