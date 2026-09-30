using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Lab3_3.DAL.DataProviders;

public class JsonDataProvider : DataProvider
{
    public override byte[] Serialize(object data)
    {
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });

        return Encoding.UTF8.GetBytes(json);
    }

    public override object Deserialize(byte[] data, Type type)
    {
        string json = Encoding.UTF8.GetString(data);

        return JsonSerializer.Deserialize(json, type)!;
    }
}