namespace Lab3_3.PL.Entities;

public class Student
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public string StudentID { get; set; }
    public double AverageMark { get; set; }
    public string Country { get; set; }
    public string PassportNumber { get; set; }

    public Student(
        int id,
        string firstName,
        string lastName,
        int course,
        string studentID,
        double averageMark,
        string country,
        string passportNumber)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        Course = course;
        StudentID = studentID;
        AverageMark = averageMark;
        Country = country;
        PassportNumber = passportNumber;
    }
}