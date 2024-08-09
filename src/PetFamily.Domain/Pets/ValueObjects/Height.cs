using FluentValidation;
using FluentValidation.Results;

namespace PetFamily.Domain.Pets.ValueObjects;

public record Height
{
    public decimal Value { get; init; }

    private Height(decimal value) => Value = value;

    public static Height Create(decimal value)
    {
        if (value < 0)
        {
            var message = "Height can not be less then 0!";

            throw new ValidationException(message, [
                new ValidationFailure(nameof(Height), message)
            ]);
        }

        return new Height(value);
    }
}