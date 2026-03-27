using CSharpPractice.DTOs.CharacterDtos;
using CSharpPractice.DTOs.ItemDtos;
using CSharpPractice.Models.Characters;
using CSharpPractice.Models.Items;

namespace CSharpPractice.Data;

public class DataLoader(CharacterDatabaseDto characterDatabaseDto, ItemDatabaseDto itemDatabaseDto)
{
  private readonly CharacterDatabaseDto _characterDatabaseDto = characterDatabaseDto;
  private readonly ItemDatabaseDto _itemDatabaseDto = itemDatabaseDto;

  public Inventory LoadInventory()
  {
    Inventory inventory = new();

    foreach (ItemDto i in _itemDatabaseDto.Items)
    {
      inventory.Add(Item.MapItem(i));
    }

    return inventory;
  }

  public Population LoadPopulation()
  {
    Population population = new();

    foreach(CharacterDto c in _characterDatabaseDto.Characters)
    {
      population.Add(Character.MapCharacter(c));
    }

    return population;
  }
}
