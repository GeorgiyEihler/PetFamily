using FluentValidation;
using FluentValidation.Results;
using PetFamily.Domain.Pets.ValueObjects;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Shared;

public record PhoneNumber
{
    private static readonly Regex _phoneRegex = 
        new(@"^\+?[\d\s\-().]{7,}$", RegexOptions.Compiled);

    public string Value { get; init; }

    private PhoneNumber(string value) => Value = value;

    public static PhoneNumber Create(string value)
    {
        if (!_phoneRegex.IsMatch(value))
        {
            var message = "Description property of HelpRequisites can not be empty string!";

            throw new ValidationException(message, [
                new ValidationFailure(nameof(Description), message)
            ]);
        }

        return new PhoneNumber(value);
    }
}