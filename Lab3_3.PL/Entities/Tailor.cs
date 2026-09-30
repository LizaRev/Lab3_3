namespace Lab3_3.PL.Entities;

public class Tailor
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Experience { get; set; }
    public string SewingType { get; set; }

    public Tailor(
        int id,
        string firstName,
        string lastName,
        string experience,
        string sewingType)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        Experience = experience;
        SewingType = sewingType;
    }
}