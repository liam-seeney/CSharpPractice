using System.Xml.Serialization;

namespace CSharpPractice.DTOs.ItemDtos;

[XmlRoot("ItemDatabase")]
public class ItemDatabaseDto
{
  [XmlArray("Items")]
  [XmlArrayItem(typeof(WeaponDto))]
  [XmlArrayItem(typeof(ConsumableDto))]
  public List<ItemDto> Items { get; set; } = [];
}

