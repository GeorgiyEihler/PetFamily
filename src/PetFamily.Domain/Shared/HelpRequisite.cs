using FluentValidation;
using FluentValidation.Results;

namespace PetFamily.Domain.Shared;

public record HelpRequisite
{
    public string Description { get; init; } = null!;
    public string Name { get; init; }

    private HelpRequisite(string description, string name) =>
        (Description, Name) = (description, name);

    public static HelpRequisite Create(string description, string name)
    {
        if (string.IsNullOrEmpty(description))
        {
            var message = "Description property of HelpRequisites can not be empty string!";

            throw new ValidationException(message, [
                new ValidationFailure(nameof(Description), message)
            ]);
        }

        if (string.IsNullOrEmpty(name))
        {
            var message = "Name property of HelpRequisites can not be empty string!";

            throw new ValidationException(message, [
               new ValidationFailure(nameof(Name), message)
            ]);
        }

        return new HelpRequisite(description, name);
    }
}