using CSharpPractice.DTOs.CharacterDtos;

namespace CSharpPractice.Models.Characters;

public class Population
{
  private readonly List<Character> _characters = [];
  public IReadOnlyList<Character> Characters => _characters;

  public void Add(Character character) => _characters.Add(character);
}

