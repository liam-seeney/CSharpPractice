using System.Xml.Serialization;

namespace CSharpPractice.DTOs.ItemDtos;

public abstract class ItemDto
{
  [XmlAttribute("id")]
  public string Id { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public int Value { get; set; }
}
