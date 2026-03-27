namespace CSharpPractice.Models.Characters;

public class Trader(string id, string name, string traderType) : Character(id, name)
{
  public string TraderType { get; } = traderType;
}
