using CSharpPractice.DTOs.CharacterDtos;
using CSharpPractice.DTOs.ItemDtos;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpPractice.Data;

public static class SeedData
{
  public static CharacterDatabaseDto LoadCharacters(string path)
  {
    XmlSerializer serializer = new(typeof(CharacterDatabaseDto));
    using FileStream stream = File.OpenRead(path);

    XmlReaderSettings settings = new()
    {
      DtdProcessing = DtdProcessing.Prohibit,
      XmlResolver = null
    };

    using XmlReader reader = XmlReader.Create(stream, settings);

    CharacterDatabaseDto? dto = (CharacterDatabaseDto?)serializer.Deserialize(reader);
    return dto ?? throw new InvalidOperationException("Failed to deserialize CharacterDatabase.xml");
  }

  public static ItemDatabaseDto LoadItems(string path)
  {
    XmlSerializer serializer = new(typeof(ItemDatabaseDto));
    using FileStream stream = File.OpenRead(path);

    XmlReaderSettings settings = new()
    {
      DtdProcessing = DtdProcessing.Prohibit,
      XmlResolver = null
    };

    using XmlReader reader = XmlReader.Create(stream, settings);

    ItemDatabaseDto? dto = (ItemDatabaseDto?)serializer.Deserialize(reader);
    return dto ?? throw new InvalidOperationException("Failed to deserialize ItemDatabase.xml");
  }
}
