using FluentValidation;
using FluentValidation.Results;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public record Experience
{
    public int Value { get; init; }

    private Experience(int value) => Value = value;

    public static Experience Create(int value)
    {
        if (value < 0)
        {
            var message = "Experience can not be less then 0!";

            throw new ValidationException(message, [
                new ValidationFailure(nameof(Experience), message)
                ]);
        }

        return new Experience(value);
    }
}