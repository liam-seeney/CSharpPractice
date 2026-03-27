using CSharpPractice.DTOs.CharacterDtos;

namespace CSharpPractice.Models.Characters;

public class Character(string id, string name)
{
  public string Id { get; } = id;
  public string Name { get; } = name;

  public static Character MapCharacter(CharacterDto dto) => dto switch
  {
    VillagerDto n => new Villager(n.Id, n.Name),
    TraderDto t => new Trader(t.Id, t.Name, t.TraderType),
    _ => throw new InvalidOperationException($"Unknown character DTO type: {dto.GetType().FullName}")
  };
}

