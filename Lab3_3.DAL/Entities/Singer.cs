using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Lab3_3.DAL.Entities;

public class Singer : Person, ISingable
{
    [JsonIgnore]
    [XmlIgnore]
    public bool IsSinging { get; private set; }

    public string SongType { get; set; }
    public int SongCount { get; set; }

    public Singer()
        : base()
    {
        SongType = "";
    }

    public Singer(
        int id,
        string firstName,
        string lastName,
        string songType,
        int songCount)
        : base(id, firstName, lastName)
    {
        SongType = songType;
        SongCount = songCount;
    }

    public void Sing()
    {
        IsSinging = true;
    }

    public override string[] GetFileData()
    {
        return new string[]
        {
            "songType", SongType,
            "songCount", SongCount.ToString()
        };
    }
}