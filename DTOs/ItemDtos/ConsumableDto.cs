using System.Xml.Serialization;

namespace CSharpPractice.DTOs.ItemDtos;

[XmlType("Consumable")]
public class ConsumableDto : ItemDto
{
  public string Effect { get; set; } = string.Empty;
  public int EffectAmount { get; set; }
  public int StackSize { get; set; }
}

