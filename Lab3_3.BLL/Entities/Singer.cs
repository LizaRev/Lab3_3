namespace Lab3_3.BLL.Entities;

public class Singer
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SongType { get; set; }
    public int SongCount { get; set; }

    public Singer(
        int id,
        string firstName,
        string lastName,
        string songType,
        int songCount)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        SongType = songType;
        SongCount = songCount;
    }
}