using Lab3_3.DAL.Entities;

namespace Lab3_3.DAL.DataProviders;

public class SingerCustomDataProvider : CustomDataProvider<Singer>
{
    protected override string WriteObject(Singer entity)
    {
        return
            "ID=" + entity.ID + "\n" +
            "FirstName=" + entity.FirstName + "\n" +
            "LastName=" + entity.LastName + "\n" +
            "SongType=" + entity.SongType + "\n" +
            "SongCount=" + entity.SongCount;
    }

    protected override Singer ReadObject(string text)
    {
        string[] lines = text.Split('\n');

        int id = int.Parse(lines[0].Split('=')[1]);
        string firstName = lines[1].Split('=')[1];
        string lastName = lines[2].Split('=')[1];
        string songType = lines[3].Split('=')[1];
        int songCount = int.Parse(lines[4].Split('=')[1]);

        return new Singer(
            id,
            firstName,
            lastName,
            songType,
            songCount);
    }
}