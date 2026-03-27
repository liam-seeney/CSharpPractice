using CSharpPractice.DTOs.ItemDtos;

namespace CSharpPractice.Models.Items;

public abstract class Item(string id, string name, int value)
{
    public string Id { get; } = id;
    public string Name { get; } = name;
    public int Value { get; } = value;

  public static Item MapItem(ItemDto dto) => dto switch
  {
    WeaponDto w => new Weapon(w.Id, w.Name, w.Damage, w.Value),
    ConsumableDto c => new Consumable(c.Id, c.Name, c.Value, c.Effect, c.EffectAmount, c.StackSize),
    _ => throw new InvalidOperationException($"Unknown item DTO type: {dto.GetType().FullName}")
  };
}

