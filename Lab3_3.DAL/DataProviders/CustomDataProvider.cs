using System.Text;

namespace Lab3_3.DAL.DataProviders;

public abstract class CustomDataProvider<T> : DataProvider
{
    public override byte[] Serialize(object data)
    {
        if (data is T entity)
        {
            string text = WriteObject(entity); 
            return Encoding.UTF8.GetBytes(text); 
        }

        if (data is T[] entities)
        {
            StringBuilder text = new StringBuilder(); 
            text.AppendLine("COUNT=" + entities.Length);

            foreach (T item in entities)
            {
                text.AppendLine(WriteObject(item));
                text.AppendLine("---");
            }

            return Encoding.UTF8.GetBytes(text.ToString());
        }

        throw new ArgumentException("Непідтримуваний тип.");
    }

    public override object Deserialize(byte[] data, Type type)
    {
        string text = Encoding.UTF8.GetString(data); 

        if (type == typeof(T))
            return ReadObject(text);

        if (type == typeof(T[]))
        {
            string[] blocks = text.Split(
                "---",
                StringSplitOptions.RemoveEmptyEntries); 

            int count = blocks.Length;

            if (blocks.Length > 0 && blocks[0].StartsWith("COUNT="))
                count--; 

            T[] result = new T[count];
            int index = 0; 

            foreach (string block in blocks)
            {
                string currentBlock = block.Trim();

                if (currentBlock.StartsWith("COUNT="))
                    continue; 

                result[index] = ReadObject(currentBlock);
                index++;
            }

            return result;
        }

        throw new ArgumentException("Непідтримуваний тип.");
    }

    protected abstract string WriteObject(T entity);
    protected abstract T ReadObject(string text);
}

