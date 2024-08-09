using PetFamily.Domain.Abstractions;
using PetFamily.Domain.Pets.Entityes;
using PetFamily.Domain.Pets.Enums;
using PetFamily.Domain.Pets.Events;
using PetFamily.Domain.Pets.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets;

public class Pet : AggregateRoot
{
    private readonly List<HelpRequisite> _helpRequisites = [];

    private readonly List<PetPhoto> _petPhotos = [];

    public Name Name { get; private set; }

    public PetType PetType { get; private set; }

    public Description Description { get; private set; }

    public Breed Breed { get; private set; }

    public Color Color { get; private set; }

    public HeathInformation HeathInformation { get; private set; }

    public Address Address { get; private set; }

    public Weight Weight { get; private set; }

    public Height Height { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public bool IsNeuter { get; private set; }

    public DateOnly BirthDate { get; private set; }

    public bool IsVaccinated { get; private set; }

    public Status Status { get; private set; }

    public DateOnly CreateDate { get; private set; }

    public IReadOnlyList<HelpRequisite> HelpRequisites => _helpRequisites;

    public IReadOnlyList<PetPhoto> PetPhotos => _petPhotos;

    private Pet(
        Guid id,
        Name name,
        PetType petType,
        Breed breed,
        Color color,
        HeathInformation heathInformation,
        Description description,
        Address address,
        Weight weight,
        Height height,
        PhoneNumber phone,
        bool isNeuter,
        DateOnly birhtDate,
        bool isVaccinated,
        Status status,
        DateOnly createDate) : base(id)
    {
        Name = name;
        PetType = petType;
        Breed = breed;
        Color = color;
        HeathInformation = heathInformation;
        Address = address;
        Weight = weight;
        Height = height;
        PhoneNumber = phone;
        IsNeuter = isNeuter;
        BirthDate = birhtDate;
        IsVaccinated = isVaccinated;
        Status = status;
        CreateDate = createDate;
        Description = description;
    }

#pragma warning disable CS8618
    private Pet()
#pragma warning restore CS8618
    {
        // efcore
    }

    public static Pet Create(
        Guid? id,
        Name name,
        PetType petType,
        Breed breed,
        Color color,
        HeathInformation heathInformation,
        Description description,
        Address address,
        Weight weight,
        Height height,
        PhoneNumber phone,
        bool isNeuter,
        DateOnly birhtDate,
        bool isVaccinated,
        Status status,
        IDateTimeProvider dateTimeProvider)
    {
        var pet = new Pet(
            id ?? Guid.NewGuid(),
            name,
            petType,
            breed,
            color,
            heathInformation,
            description,
            address,
            weight,
            height,
            phone,
            isNeuter,
            birhtDate,
            isVaccinated,
            status,
            DateOnly.FromDateTime(dateTimeProvider.UtcNow));

        // Для соблюдения консистентности данных между Pet Aggregate и Volunteer Aggregate
        pet.RaiseDomainEvent(new AddPetDomainEvent(pet.Id));

        return pet;
    } 
}
