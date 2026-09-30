using System.IO;
using Lab3_3.DAL.Entities;

namespace Lab3_3.DAL.DataProviders;

public class TailorBinaryDataProvider : BinaryDataProvider<Tailor>
{
    protected override void WriteObject(BinaryWriter writer, Tailor entity)
    {
        writer.Write(entity.ID);
        writer.Write(entity.FirstName);
        writer.Write(entity.LastName);
        writer.Write(entity.Experience);
        writer.Write(entity.SewingType);
    }

    protected override Tailor ReadObject(BinaryReader reader)
    {
        return new Tailor(
            reader.ReadInt32(),
            reader.ReadString(),
            reader.ReadString(),
            reader.ReadString(),
            reader.ReadString()
        );
    }
}