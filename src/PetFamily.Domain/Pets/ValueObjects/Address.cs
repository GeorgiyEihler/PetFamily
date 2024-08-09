using FluentValidation;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Pets.ValueObjects;

public record Address
{
    public string PostalCode { get; init; }
    public string Country { get; init; }
    public string Region { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string House { get; init; }

    private Address(
        string postalCode,
        string country,
        string region,
        string city,
        string street,
        string house)
    {
        (PostalCode, Country, Region, City, Street, House) = (postalCode, country, region, city, street, house);
    }

    public static Address Create(
        string postalCode,
        string country,
        string region,
        string city,
        string street,
        string house)
    {
        var address = new Address(
            postalCode,
            country,
            region,
            city,
            street,
            house);

        var addressValidator = new AddressValidator();

        var result = addressValidator.Validate(address);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        return address;
    }
}

internal class AddressValidator : AbstractValidator<Address>
{
    private readonly Regex _postalCodeRegex =
        new(@"^\d{6,6}$", RegexOptions.Compiled);

    public AddressValidator()
    {
        RuleFor(c => c.PostalCode)
            .NotEmpty()
            .Length(6)
            .Must(_postalCodeRegex.IsMatch);

        RuleFor(c => c.Country)
            .NotEmpty();

        RuleFor(c => c.Region)
            .NotEmpty();

        RuleFor(c => c.City)
            .NotEmpty();

        RuleFor(c => c.Street)
            .NotEmpty();
    }
}