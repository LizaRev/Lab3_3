using System.IO;
using System.Xml.Serialization;

public static class XmlSerialization
{
    public static void Serialize(Account[] accounts, string fileName)
    {
        XmlSerializer serializer =
            new XmlSerializer(typeof(Account[]));

        using (FileStream stream = File.Create(fileName))
        {
            serializer.Serialize(stream, accounts);
        }
    }

    public static Account[] Deserialize(string fileName)
    {
        XmlSerializer serializer =
            new XmlSerializer(typeof(Account[]));

        using (FileStream stream = File.OpenRead(fileName))
        {
            return (Account[])serializer.Deserialize(stream)!;
        }
    }
}