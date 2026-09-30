using System.IO;
using Lab3_3.DAL.Entities;

namespace Lab3_3.DAL.DataProviders;

public class SingerBinaryDataProvider : BinaryDataProvider<Singer>
{
    protected override void WriteObject(BinaryWriter writer, Singer entity)
    {
        writer.Write(entity.ID);
        writer.Write(entity.FirstName);
        writer.Write(entity.LastName);
        writer.Write(entity.SongType);
        writer.Write(entity.SongCount);
    }

    protected override Singer ReadObject(BinaryReader reader)
    {
        return new Singer(
            reader.ReadInt32(),
            reader.ReadString(),
            reader.ReadString(),
            reader.ReadString(),
            reader.ReadInt32()
        );
    }
}