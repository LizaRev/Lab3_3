using Lab3_3.DAL.Entities;

namespace Lab3_3.DAL.DataProviders;

public class StudentCustomDataProvider : CustomDataProvider<Student>
{
    protected override string WriteObject(Student entity)
    {
        return
            "ID=" + entity.ID + "\n" +
            "FirstName=" + entity.FirstName + "\n" +
            "LastName=" + entity.LastName + "\n" +
            "Course=" + entity.Course + "\n" +
            "StudentID=" + entity.StudentID + "\n" +
            "AverageMark=" + entity.AverageMark + "\n" +
            "Country=" + entity.Country + "\n" +
            "PassportNumber=" + entity.PassportNumber;
    }

    protected override Student ReadObject(string text)
    {
        string[] lines = text.Split('\n');

        int id = int.Parse(lines[0].Split('=')[1]);
        string firstName = lines[1].Split('=')[1];
        string lastName = lines[2].Split('=')[1];
        int course = int.Parse(lines[3].Split('=')[1]);
        string studentId = lines[4].Split('=')[1];
        double averageMark = double.Parse(lines[5].Split('=')[1]);
        string country = lines[6].Split('=')[1];
        string passportNumber = lines[7].Split('=')[1];

        return new Student(
            id,
            firstName,
            lastName,
            course,
            studentId,
            averageMark,
            country,
            passportNumber);
    }
}