using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PetFamily.Infrastructure.Configurations.Converters;

internal sealed class ListOfIdsConverter : ValueConverter<List<Guid>, string>
{
    public ListOfIdsConverter(
        ConverterMappingHints? mappingHints = null)
        : base(
            v => string.Join(',', v),
            v=> v.Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(Guid.Parse).ToList(),
            mappingHints)
    {
    }
}

internal sealed class ListOfIdsComparer : ValueComparer<List<Guid>>
{
    public ListOfIdsComparer() : base(
        (l, r) => l!.SequenceEqual(r!),
        v => v.Select(id => id!.GetHashCode())
        .Aggregate((x, y) => x^y),
        v => v)
    {
    }
}
