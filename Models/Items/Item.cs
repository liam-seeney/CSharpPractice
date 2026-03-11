namespace CSharpPractice.Models.Items;

public abstract class Item(string id, string name, int value)
{
    public string Id { get; } = id;
    public string Name { get; } = name;
    public int Value { get; } = value;
}

