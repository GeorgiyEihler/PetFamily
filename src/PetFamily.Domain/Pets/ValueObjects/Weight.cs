using FluentValidation;
using FluentValidation.Results;

namespace PetFamily.Domain.Pets.ValueObjects;

public record Weight
{
    public decimal Value { get; init; }

    private Weight(decimal value) => Value = value;

    public static Weight Create(decimal value)
    {
        if (value < 0)
        {
            var message = "Weight can not be less then 0!";

            throw new ValidationException(message, [
                new ValidationFailure(nameof(Weight), message)
            ]);
        }

        return new Weight(value);
    }
}