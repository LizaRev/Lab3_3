using System.IO;
using Lab3_3.DAL.Entities;

namespace Lab3_3.DAL.DataProviders; //як зберігати студента в байнері файлі і потім як отримувати його

public class StudentBinaryDataProvider : BinaryDataProvider<Student>
{
    protected override void WriteObject(BinaryWriter writer, Student entity)
    {
        writer.Write(entity.ID);
        writer.Write(entity.FirstName);
        writer.Write(entity.LastName);
        writer.Write(entity.Course);
        writer.Write(entity.StudentID);
        writer.Write(entity.AverageMark);
        writer.Write(entity.Country);
        writer.Write(entity.PassportNumber);
    }

    protected override Student ReadObject(BinaryReader reader)
    {
        return new Student(
            reader.ReadInt32(),
            reader.ReadString(),
            reader.ReadString(),
            reader.ReadInt32(),
            reader.ReadString(),
            reader.ReadDouble(),
            reader.ReadString(),
            reader.ReadString()
        );
    }
}



