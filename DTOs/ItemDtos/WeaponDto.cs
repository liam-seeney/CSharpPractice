using System.Xml.Serialization;

namespace CSharpPractice.DTOs.ItemDtos;

[XmlType("Weapon")]
public class WeaponDto : ItemDto
{
  public int Damage { get; set; }
}

