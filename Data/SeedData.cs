using CSharpPractice.DTOs.CharacterDtos;
using CSharpPractice.DTOs.ItemDtos;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpPractice.Data;

public static class SeedData
{
  public static T Load<T>(string path)
  {
    XmlSerializer serializer = new(typeof(T));
    
    using FileStream stream = File.OpenRead(path);

    XmlReaderSettings settings = new()
    {
      DtdProcessing = DtdProcessing.Prohibit,
      XmlResolver = null,
    };

    using XmlReader reader = XmlReader.Create(stream, settings);

    T? dto = (T?)serializer.Deserialize(reader);

    return dto ?? throw new InvalidOperationException($"Failed to deserialize {typeof(T).Name}");
  }

  public static string DataFilePath(string fileName)
  {
    string path = Path.Combine(AppContext.BaseDirectory, "Data", fileName);

    if (!File.Exists(path))
    {
      throw new FileNotFoundException($"Could not locate {fileName} at {path}.");
    }

    return path;
  }
}
