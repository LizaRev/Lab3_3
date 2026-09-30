using System.IO;
using System.Text.Json;

public static class JsonSerialization
{
    public static void Serialize(Account[] accounts, string fileName)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(accounts, options);

        File.WriteAllText(fileName, json);
    }

    public static Account[] Deserialize(string fileName)
    {
        string json = File.ReadAllText(fileName);

        return JsonSerializer.Deserialize<Account[]>(json)!;
    }
}