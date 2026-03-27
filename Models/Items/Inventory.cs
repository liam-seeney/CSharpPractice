namespace CSharpPractice.Models.Items;

public class Inventory
{
  private readonly List<Item> _items = [];
  public IReadOnlyList<Item> Items => _items;

  public void Add(Item item) => _items.Add(item);

  public List<Item> PickRandomItems(int count)
  {
    if (count > _items.Count)
    {
      throw new ArgumentException("Not enough items", nameof(count));
    }

    Random rng = Random.Shared;

    return [.. _items.OrderBy(_ => rng.Next()).Take(count)];
  }
}