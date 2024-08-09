using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetFamily.Infrastructure.Configurations.Converters;

internal static class EfFluentApiExtensions
{
    public static PropertyBuilder<T> HasListOfIdsConverter<T>(this 
        PropertyBuilder<T> propertyBuilder)
    {
        return propertyBuilder.HasConversion(
            new ListOfIdsConverter(),
            new ListOfIdsComparer());
    }

    public static PropertyBuilder<T> HasJsonValueConverter<T>(
        this PropertyBuilder<T> propertyBuilder)
    {
        return propertyBuilder.HasConversion(
            new ValueJsonConverter<T>(),
            new ValueJsonComparer<T>());
    }
}
