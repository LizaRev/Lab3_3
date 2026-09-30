using Lab3_3.DAL.Entities;

namespace Lab3_3.DAL.DataProviders;

public class TailorCustomDataProvider : CustomDataProvider<Tailor>
{
    protected override string WriteObject(Tailor entity)
    {
        return
            "ID=" + entity.ID + "\n" +
            "FirstName=" + entity.FirstName + "\n" +
            "LastName=" + entity.LastName + "\n" +
            "Experience=" + entity.Experience + "\n" +
            "SewingType=" + entity.SewingType;
    }

    protected override Tailor ReadObject(string text)
    {
        string[] lines = text.Split('\n');

        int id = int.Parse(lines[0].Split('=')[1]);
        string firstName = lines[1].Split('=')[1];
        string lastName = lines[2].Split('=')[1];
        string experience = lines[3].Split('=')[1];
        string sewingType = lines[4].Split('=')[1];

        return new Tailor(
            id,
            firstName,
            lastName,
            experience,
            sewingType);
    }
}