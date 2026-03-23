using CSharpPractice.Data;
using CSharpPractice.DTOs.CharacterDtos;
using CSharpPractice.DTOs.ItemDtos;
using CSharpPractice.Models.Characters;
using CSharpPractice.Models.Items;

Inventory inventory = new();
Population characters = new();

ItemDatabaseDto itemData = SeedData.LoadItems(ResolveDataFilePath("ItemDatabase.xml"));
CharacterDatabaseDto characterData = SeedData.LoadCharacters(ResolveDataFilePath("CharacterDatabase.xml"));

foreach (ItemDto dto in itemData.Items)
{
    inventory.Items.Add(MapItem(dto));
}

foreach (CharacterDto dto in characterData.Characters)
{
    characters.Characters.Add(MapCharacter(dto));
}

foreach (Character character in characters.Characters)
{
    Console.WriteLine(character.Name);
}

foreach (Item item in inventory.Items)
{
    Console.WriteLine(item.Name);
}

Inventory randomItems = new()
{
  Items = PickRandomItems(inventory.Items, 2)
};

string itemList = string.Join(", ", randomItems.Items.Select(i => i.Name));

Console.WriteLine($"The chest contains {itemList}.");

static List<Item> PickRandomItems(List<Item> items, int count)
{
    if (count > items.Count)
    {
        throw new ArgumentException("Not enough items", nameof(count));
    }

    Random rng = Random.Shared;

    return [.. items.OrderBy(_ => rng.Next()).Take(count)];
}

static Item MapItem(ItemDto dto) => dto switch
{
  WeaponDto w => new Weapon(w.Id, w.Name, w.Damage, w.Value),
  ConsumableDto c => new Consumable(c.Id, c.Name, c.Value, c.Effect, c.EffectAmount, c.StackSize),
  _ => throw new InvalidOperationException($"Unknown item DTO type: {dto.GetType().FullName}")
};

static Character MapCharacter(CharacterDto dto) => dto switch
{
  VillagerDto n => new Villager(n.Id, n.Name),
  TraderDto t => new Trader(t.Id, t.Name, t.TraderType),
  _ => throw new InvalidOperationException($"Unknown character DTO type: {dto.GetType().FullName}")
};

static string ResolveDataFilePath(string fileName)
{
  string[] candidatePaths =
  [
      Path.Combine(AppContext.BaseDirectory, "Data", fileName),
        Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName),
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", fileName)),
        Path.Combine(AppContext.BaseDirectory, fileName)
  ];

  foreach (string candidatePath in candidatePaths)
  {
    if (File.Exists(candidatePath))
    {
      Console.WriteLine(candidatePath);
      return candidatePath;
    }
  }

  throw new FileNotFoundException(
      $"Could not locate '{fileName}'. Tried: {string.Join(", ", candidatePaths)}");
}