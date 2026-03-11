namespace CSharpPractice.Models.Items;

public class Weapon(string id, string name, int value, int damage) 
  : Item(id, name, value)
{
  public int Damage { get; } = damage;
}

