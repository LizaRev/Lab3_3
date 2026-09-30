namespace Lab3_3.DAL.Entities;

public class Tailor : Person, ISew
{
    public bool IsSewing { get; set; }

    public string Experience { get; set; }

    public string SewingType { get; set; }

    public Tailor()
        : base()
    {
        Experience = "";
        SewingType = "";
        IsSewing = false;
    }

    public Tailor(
        int id,
        string firstName,
        string lastName,
        string experience,
        string sewingType)
        : base(id, firstName, lastName)
    {
        Experience = experience;
        SewingType = sewingType;
        IsSewing = false;
    }

    public void Sew()
    {
        IsSewing = true;
    }

    public override string[] GetFileData()
    {
        return new string[]
        {
            "experience", Experience,
            "sewingType", SewingType
        };
    }
}