using PetFamily.Domain.Abstractions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : AggregateRoot
{
    private readonly List<Guid> _pets = [];

    private readonly List<SocialMedia> _socialMedias = [];

    private readonly List<HelpRequisite> _helpRequisites = [];

    public Description Description { get; private set; }

    public FullName FullName { get; private set; }

    public Experience Experience { get; private set; }

    public PetInformation PetInformation { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public IReadOnlyList<SocialMedia> SocialMedias  => _socialMedias;

    public IReadOnlyList<HelpRequisite> HelpRequisites => _helpRequisites;

    public IReadOnlyList<Guid> Pets => _pets;

    private Volunteer(
        Guid id,
        FullName fullName,
        Experience experience,
        PetInformation petInformation,
        Description description,
        PhoneNumber phoneNumber) : base(id)
    {
        FullName = fullName;
        Experience = experience;
        PetInformation = petInformation;
        PhoneNumber = phoneNumber;
        Description = description;
    }

   
#pragma warning disable CS8618
    private Volunteer()
#pragma warning restore CS8618
    {
        // efcore
    }

    public static Volunteer Create(
        FullName fullName,
        Experience experience,
        PetInformation petInformation,
        PhoneNumber phoneNumber,
        Description description,
        Guid? id = null)
    {
        return new Volunteer(
            id ?? Guid.NewGuid(),
            fullName,
            experience,
            petInformation,
            description,
            phoneNumber);
    }
}
