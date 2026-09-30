using Lab3_3.BLL.Entities;
using Lab3_3.BLL.Exceptions;
using Lab3_3.DAL.Context;
using Lab3_3.DAL.DataProviders;

namespace Lab3_3.BLL;

public class EntityService
{
    private EntityContext context;

    public string CurrentSerialization { get; private set; } 

    public EntityService(string serializationType)
    {
        CurrentSerialization = serializationType;
        DataProvider provider = DataProviderFactory.Create(serializationType, "Student");
        context = new EntityContext(provider);
    }

    private void SetProvider(string entityType) 
    {
        DataProvider provider = DataProviderFactory.Create(CurrentSerialization, entityType);
        context = new EntityContext(provider);
    }

    public void SaveStudents(string fileName, Student[] students)
    {
        SetProvider("Student"); 

        Lab3_3.DAL.Entities.Student[] dalStudents = new Lab3_3.DAL.Entities.Student[students.Length]; 

        for (int i = 0; i < students.Length; i++)
        {
            ValidateStudent(students[i]); 

            dalStudents[i] = new Lab3_3.DAL.Entities.Student( 
                students[i].ID,
                students[i].FirstName,
                students[i].LastName,
                students[i].Course,
                students[i].StudentID,
                students[i].AverageMark,
                students[i].Country,
                students[i].PassportNumber);
        }

        context.Save(fileName, dalStudents);
    }

    public Student[] LoadStudents(string fileName)
    {
        SetProvider("Student");

        Lab3_3.DAL.Entities.Student[] dalStudents =
            (Lab3_3.DAL.Entities.Student[])context.Load(
                fileName,
                typeof(Lab3_3.DAL.Entities.Student[])); 

        Student[] students = new Student[dalStudents.Length];

        for (int i = 0; i < dalStudents.Length; i++)
        {
            ValidateStudentData(dalStudents[i]);

            students[i] = new Student(
                dalStudents[i].ID,
                dalStudents[i].FirstName,
                dalStudents[i].LastName,
                dalStudents[i].Course,
                dalStudents[i].StudentID,
                dalStudents[i].AverageMark,
                dalStudents[i].Country,
                dalStudents[i].PassportNumber);
        }

        return students;
    }

    public Student[] GetForeignFirstYearExcellentStudents(string fileName)
    {
        Student[] students = LoadStudents(fileName);
        List<Student> result = new List<Student>();

        foreach (Student student in students)
        {
            if (student.Course == 1 &&
                student.Country != "Ukraine" &&
                student.AverageMark >= 90)
            {
                result.Add(student);
            }
        }

        return result.ToArray();
    }


    public void Save(string fileName, Tailor tailor)
    {
        SetProvider("Tailor");

        Lab3_3.DAL.Entities.Tailor dalTailor =
            new Lab3_3.DAL.Entities.Tailor(
                tailor.ID,
                tailor.FirstName,
                tailor.LastName,
                tailor.Experience,
                tailor.SewingType);

        context.Save(fileName, dalTailor);
    }

    public Tailor LoadTailor(string fileName)
    {
        SetProvider("Tailor");

        Lab3_3.DAL.Entities.Tailor dalTailor =
            (Lab3_3.DAL.Entities.Tailor)context.Load(
                fileName,
                typeof(Lab3_3.DAL.Entities.Tailor));

        return new Tailor(
            dalTailor.ID,
            dalTailor.FirstName,
            dalTailor.LastName,
            dalTailor.Experience,
            dalTailor.SewingType);
    }


    public void Save(string fileName, Singer singer)
    {
        SetProvider("Singer");

        Lab3_3.DAL.Entities.Singer dalSinger =
            new Lab3_3.DAL.Entities.Singer(
                singer.ID,
                singer.FirstName,
                singer.LastName,
                singer.SongType,
                singer.SongCount);

        context.Save(fileName, dalSinger);
    }

    public Singer LoadSinger(string fileName)
    {
        SetProvider("Singer");

        Lab3_3.DAL.Entities.Singer dalSinger =
            (Lab3_3.DAL.Entities.Singer)context.Load(
                fileName,
                typeof(Lab3_3.DAL.Entities.Singer));

        return new Singer(
            dalSinger.ID,
            dalSinger.FirstName,
            dalSinger.LastName,
            dalSinger.SongType,
            dalSinger.SongCount);
    }

    private void ValidateStudent(Student student)
    {
        if (student.Course < 1)
        {
            throw new StudentDataException("Курс студента не може бути меншим за 1.");
        }

        if (student.AverageMark < 0 || student.AverageMark > 100)
        {
            throw new StudentDataException("Середній бал повинен бути від 0 до 100.");
        }
    }

    private void ValidateStudentData(Lab3_3.DAL.Entities.Student student)
    {
        if (student.Course < 1)
        {
            throw new StudentDataException("У файлі знайдено студента з некоректним курсом.");
        }

        if (student.AverageMark < 0 || student.AverageMark > 100)
        {
            throw new StudentDataException("У файлі знайдено студента з некоректним середнім балом.");
        }
    }
}