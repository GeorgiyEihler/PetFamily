using Ardalis.SmartEnum;

namespace PetFamily.Domain.Pets.Enums;

public class Status(string name, int value) : SmartEnum<Status>(name, value)
{
    public static readonly Status NeedHelp = new("Нуждается в помощи", 1);
    public static readonly Status LookingHome = new("Ищет дом", 2);
    public static readonly Status FoundHome = new("Нашел дом", 3);
}
