using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;
using PetFamily.Domain.Volunteers.ValueObjects;
using PetFamily.Infrastructure.Configurations.Converters;

namespace PetFamily.Infrastructure.Configurations;

internal sealed class VolunteeerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.Property(p => p.Pets)
           .HasJsonValueConverter()
           .HasColumnName("pets")
           .Metadata
           .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(p => p.SocialMedias)
           .HasJsonValueConverter()
           .HasColumnName("social_medias")
           .Metadata
           .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(p => p.HelpRequisites)
            .HasJsonValueConverter()
            .HasColumnName("help_requisites")
            .Metadata
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(v => v.Description)
            .HasConversion(d => d.Value, v => new Description(v));

        builder.ComplexProperty(v => v.FullName);

        builder.Property(v => v.Experience)
            .HasConversion(d => d.Value, v =>  Experience.Create(v));

        builder.ComplexProperty(v => v.PetInformation);

        builder.Property(c => c.PhoneNumber)
            .HasConversion(p => p.Value, v => PhoneNumber.Create(v));
    }
}
