using FluentValidation;
using FluentValidation.Results;

namespace PetFamily.Domain.Pets.ValueObjects;

public record Color
{
    public string Value { get; init; }

    private Color(string value) => Value = value;

    public static Color Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            var message = "Color can not be empty!";

            throw new ValidationException(message, [
                new ValidationFailure(nameof(Color), message)
            ]);
        }

        return new Color(value);
    }
}