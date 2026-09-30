namespace Lab3_3.DAL.Entities;

public class Student : Person, IStudy, IDiver
{
    public int Course { get; set; }
    public string StudentID { get; set; }
    public double AverageMark { get; set; }
    public string Country { get; set; }
    public string PassportNumber { get; set; }

    public bool IsStudying { get; private set; }
    public bool IsDiving { get; private set; }

    public Student()
        : base()
    {
        StudentID = "";
        Country = "";
        PassportNumber = "";
    }

    public Student(
        int id,
        string firstName,
        string lastName,
        int course,
        string studentID,
        double averageMark,
        string country,
        string passportNumber)
        : base(id, firstName, lastName)
    {
        Course = course;
        StudentID = studentID;
        AverageMark = averageMark;
        Country = country;
        PassportNumber = passportNumber;
    }

    public void Study()
    {
        IsStudying = true;
    }

    public void Dive()
    {
        IsDiving = true;
    }

    public override string[] GetFileData()
    {
        return new string[]
        {
            "course", Course.ToString(),
            "studentId", StudentID,
            "averageMark", AverageMark.ToString(),
            "country", Country,
            "passportNumber", PassportNumber
        };
    }
}