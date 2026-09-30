namespace Lab3_3.DAL.Entities;

public abstract class Person
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected Person()
    {
        FirstName = "";
        LastName = "";
    }

    protected Person(
        int id,
        string firstName,
        string lastName)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public abstract string[] GetFileData();
}