using CSharpPractice.Data;
using CSharpPractice.DTOs.CharacterDtos;
using CSharpPractice.DTOs.ItemDtos;
using CSharpPractice.Models.Characters;
using CSharpPractice.Models.Items;

CharacterDatabaseDto characterData = SeedData.Load<CharacterDatabaseDto>(SeedData.DataFilePath("CharacterDatabase.xml"));
ItemDatabaseDto itemData = SeedData.Load<ItemDatabaseDto>(SeedData.DataFilePath("ItemDatabase.xml"));

DataLoader dataLoader = new(characterData, itemData);

Inventory inventory = dataLoader.LoadInventory();
Population population = dataLoader.LoadPopulation();

foreach (Character character in population.Characters)
{
  if (character is Trader trader)
  {
    Console.WriteLine($"{character.Name} is a {trader.TraderType} trader");
  }
  else
  {
    Console.WriteLine(character.Name);
  }
}

foreach (Item item in inventory.Items)
{
  Console.WriteLine(item.Name);
}
