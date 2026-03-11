using System.Xml.Serialization;

namespace CSharpPractice.DTOs.CharacterDtos;

[XmlRoot("CharacterDatabase")]
public class CharacterDatabaseDto
{
  [XmlArray("Characters")]
  [XmlArrayItem(typeof(VillagerDto))]
  [XmlArrayItem(typeof(TraderDto))]
  public List<CharacterDto> Characters { get; set; } = [];
}

