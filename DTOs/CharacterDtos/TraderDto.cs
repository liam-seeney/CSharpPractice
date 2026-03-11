using System.Xml.Serialization;

namespace CSharpPractice.DTOs.CharacterDtos;

[XmlType("Trader")]
public class TraderDto : CharacterDto
{
  [XmlAttribute("TraderType")]
  public string TraderType { get; set; } = string.Empty;
}
