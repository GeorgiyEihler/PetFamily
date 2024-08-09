using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Pets.Entityes;
using PetFamily.Domain.Pets.Enums;
using PetFamily.Domain.Pets.ValueObjects;
using PetFamily.Domain.Shared;
using PetFamily.Infrastructure.Configurations.Converters;

namespace PetFamily.Infrastructure.Configurations;

internal sealed class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.Property(p => p.HelpRequisites)
            .HasJsonValueConverter()
            .HasColumnName("help_requisites")
            .Metadata
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsMany<PetPhoto>("PetPhotos", pp =>
        {
            pp.ToTable("pet_photo");

            pp.WithOwner()
                .HasForeignKey(pp => pp.PetId);

            pp.Property(pp => pp.Content)
            .HasConversion(c => c.Value, v => new Content(v));
        })
        .Metadata
        .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(p => p.Name)
            .HasConversion(pt => pt.Value, v => Name.Create(v));

        builder.Property(p => p.PetType)
            .HasConversion(pt => pt.Value, v => new PetType(v));

        builder.Property(p => p.Description)
            .HasConversion(pt => pt.Value, v => new Description(v));

        builder.Property(p => p.Breed)
            .HasConversion(pt => pt.Value, v => Breed.Create(v));

        builder.Property(p => p.Color)
            .HasConversion(pt => pt.Value, v => Color.Create(v));

        builder.Property(p => p.HeathInformation)
            .HasConversion(pt => pt.Value, v => new HeathInformation(v));

        builder.ComplexProperty(p => p.Address);

        builder.Property(p => p.Weight)
           .HasConversion(pt => pt.Value, v => Weight.Create(v));

        builder.Property(p => p.Height)
           .HasConversion(pt => pt.Value, v => Height.Create(v));

        builder.Property(p => p.PhoneNumber)
           .HasConversion(pt => pt.Value, v => PhoneNumber.Create(v));

        builder.Property(p => p.IsNeuter);

        builder.Property(p => p.BirthDate);

        builder.Property(p => p.IsVaccinated);

        builder.Property(p => p.Status)
            .HasConversion(s => s.Value, v => Status.FromValue(v));

        builder.Property(p => p.CreateDate);
    }
}
