using System.IO;
using System.Text;

namespace Lab3_3.DAL.DataProviders;

public abstract class BinaryDataProvider<T> : DataProvider
{
    public override byte[] Serialize(object data)
    {
        using MemoryStream stream = new MemoryStream(); 
        using BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8); 

        if (data is T entity)
        {
            writer.Write(1); 
            WriteObject(writer, entity); 
        }
        else if (data is T[] entities)
        {
            writer.Write(entities.Length);
            foreach (T item in entities)
                WriteObject(writer, item);
        }
        else
            throw new ArgumentException("Непідтримуваний тип.");

        writer.Flush(); 
        return stream.ToArray();
    }

    public override object Deserialize(byte[] data, Type type) 
    {
        using MemoryStream stream = new MemoryStream(data);
        using BinaryReader reader = new BinaryReader(stream, Encoding.UTF8);

        if (type == typeof(T))
        {
            reader.ReadInt32();
            return ReadObject(reader);
        }

        if (type == typeof(T[]))
        {
            int count = reader.ReadInt32();
            T[] result = new T[count];

            for (int i = 0; i < count; i++)
                result[i] = ReadObject(reader); 

            return result;
        }

        throw new ArgumentException("Непідтримуваний тип.");
    }

    protected abstract void WriteObject(BinaryWriter writer, T entity);
    protected abstract T ReadObject(BinaryReader reader);
}

