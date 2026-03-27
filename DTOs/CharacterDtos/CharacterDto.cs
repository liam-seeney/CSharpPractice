using System.Xml.Serialization;

namespace CSharpPractice.DTOs.CharacterDtos;

[XmlInclude(typeof(VillagerDto))]
[XmlInclude(typeof(TraderDto))]
public abstract class CharacterDto
{
  [XmlAttribute("id")]
  public string Id { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
}

