using FluentValidation;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public record FullName
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Patronymic { get; init; }

    private FullName(
        string firstName,
        string lastName,
        string patronymic) =>
        (FirstName, LastName, Patronymic) = (firstName, lastName, patronymic);

    public static FullName Create(
        string firstName,
        string lastName,
        string patronymic)
    {
        var fullName = new FullName(firstName, lastName, patronymic);

        var validator = new FullNameValidator();

        var result = validator.Validate(fullName);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        return fullName;
    }
}

internal class FullNameValidator : AbstractValidator<FullName>
{
    public FullNameValidator()
    {
        RuleFor(n => n.FirstName)
            .NotEmpty();

        RuleFor(n => n.LastName)
            .NotEmpty();
    }
}
