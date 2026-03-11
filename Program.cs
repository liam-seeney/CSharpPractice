using CSharpPractice.Data;
using CSharpPractice.DTOs.CharacterDtos;
using CSharpPractice.DTOs.ItemDtos;
using CSharpPractice.Models.Characters;
using CSharpPractice.Models.Items;

Inventory Inventory = new();
Population Characters = new();

ItemDatabaseDto data = SeedData.LoadItems("C:\\Users\\liam.seeney\\source\\repos\\CSharpPractice\\Data\\ItemDatabase.xml");
CharacterDatabaseDto characterData = SeedData.LoadCharacters("C:\\Users\\liam.seeney\\source\\repos\\CSharpPractice\\Data\\CharacterDatabase.xml");

foreach (ItemDto dto in data.Items)
{
    Item item = dto switch
    {
        WeaponDto w => new Weapon(w.Id, w.Name, w.Damage, w.Value),
        ConsumableDto c => new Consumable(c.Id, c.Name, c.Value, c.Effect, c.EffectAmount, c.StackSize),
        _ => throw new InvalidOperationException($"Unknown item DTO type: {dto?.GetType().FullName ?? "null"}")
    };
    Inventory.Items.Add(item);
}

foreach (CharacterDto dto in characterData.Characters)
{
    Character character = dto switch
    {
        VillagerDto n => new Villager(n.Id, n.Name),
        TraderDto t => new Trader(t.Id, t.Name, t.TraderType),
        _ => throw new InvalidOperationException($"Unknown character DTO type: {dto?.GetType().FullName ?? "null"}")
    };
    Characters.Characters.Add(character);
}

foreach (Character character in Characters.Characters)
{
    Console.WriteLine(character.Name);
}

foreach (Item item in Inventory.Items)
{
    Console.WriteLine(item.Name);
}

Inventory randomItems = new()
{
  Items = PickRandomItems(Inventory.Items, 2)
};

string itemList = string.Join(", ", randomItems.Items.Select(i => i.Name));

Console.WriteLine($"The chest contains {itemList}.");

static List<Item> PickRandomItems(
  List<Item> items,
  int count)
{
    if (count > items.Count)
    {
        throw new ArgumentException("Not enough items");
    }

    Random rng = Random.Shared;

    return [.. items
    .OrderBy(_ => rng.Next())
    .Take(count)];
}