namespace CSharpPractice.Models.Items;

public class Consumable(
  string id,
  string name,
  int value,
  string effect,
  int effectAmount,
  int stackSize)
  : Item(id, name, value)
{
  public string Effect { get; } = effect;
  public int EffectAmount { get; } = effectAmount;
  public int StackSize { get; } = stackSize;
}

