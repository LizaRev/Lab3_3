using System.Xml.Serialization;

namespace Lab3_3.DAL.DataProviders;

public class XmlDataProvider : DataProvider
{
    public override byte[] Serialize(object data)
    {
        XmlSerializer serializer = new XmlSerializer(data.GetType()); 
        using MemoryStream stream = new MemoryStream();

        serializer.Serialize(stream, data); 

        return stream.ToArray();
    }

    public override object Deserialize(byte[] data, Type type)
    {
        XmlSerializer serializer = new XmlSerializer(type);
        using MemoryStream stream = new MemoryStream(data);

        return serializer.Deserialize(stream)!;
    }
}

