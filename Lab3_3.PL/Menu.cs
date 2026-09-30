using Lab3_3.BLL;
using Lab3_3.BLL.Exceptions;
using BLLStudent = Lab3_3.BLL.Entities.Student;
using BLLTailor = Lab3_3.BLL.Entities.Tailor;
using BLLSinger = Lab3_3.BLL.Entities.Singer;

namespace Lab3_3.PL;

public static class Menu
{
    public static void MainMenu()
    {
        Console.WriteLine("Оберіть тип серіалізації:");
        Console.WriteLine("1 - Binary");
        Console.WriteLine("2 - JSON");
        Console.WriteLine("3 - XML");
        Console.WriteLine("4 - Custom");

        Console.Write("Ваш вибір: ");
        string serializationChoice = Console.ReadLine()!;

        try
        {
            if (serializationChoice != "1" && serializationChoice != "2" &&
                serializationChoice != "3" && serializationChoice != "4")
                throw new ArgumentException("Невірний тип серіалізації.");

            EntityService service = new EntityService(serializationChoice);

            Console.WriteLine("Оберіть сутність:");
            Console.WriteLine("1 - Student");
            Console.WriteLine("2 - Tailor");
            Console.WriteLine("3 - Singer");

            Console.Write("Ваш вибір: ");
            string entityChoice = Console.ReadLine()!;

            if (entityChoice != "1" && entityChoice != "2" && entityChoice != "3")
                throw new ArgumentException("Невірний тип сутності.");

            Console.Write("Введіть шлях та назву файлу: ");
            string fileName = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Назва файлу не може бути порожньою.");


            if (entityChoice == "1")
            {

                Console.WriteLine("Student");

                Console.WriteLine("1 - Ввести та зберегти студентів");
                Console.WriteLine("2 - Завантажити студентів з файлу");
                Console.WriteLine("3 - Знайти іноземних студентів-відмінників 1-го курсу");

                Console.Write("Ваш вибір: ");
                string operation = Console.ReadLine()!;

                if (operation == "1")
                {
                    Console.WriteLine();
                    Console.Write("Введіть кількість студентів: ");

                    int count = int.Parse(Console.ReadLine()!);

                    if (count <= 0)
                        throw new ArgumentException("Кількість студентів повинна бути більшою за 0.");

                    BLLStudent[] students = new BLLStudent[count];

                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Студент №{i + 1}");

                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine()!);

                        Console.Write("Ім'я: ");
                        string firstName = Console.ReadLine()!;

                        Console.Write("Прізвище: ");
                        string lastName = Console.ReadLine()!;

                        Console.Write("Курс: ");
                        int course = int.Parse(Console.ReadLine()!);

                        Console.Write("Студентський квиток: ");
                        string studentID = Console.ReadLine()!;

                        Console.Write("Середній бал: ");
                        double averageMark = double.Parse(Console.ReadLine()!);

                        Console.Write("Країна: ");
                        string country = Console.ReadLine()!;

                        Console.Write("Номер закордонного паспорту: ");
                        string passportNumber = Console.ReadLine()!;

                        students[i] = new BLLStudent(
                            id, firstName, lastName, course,
                            studentID, averageMark, country, passportNumber);
                    }

                    service.SaveStudents(fileName, students);

                    Console.WriteLine();
                    Console.WriteLine("Студентів  збережено у файл: " + fileName); 
                }
                else if (operation == "2")
                {
                    BLLStudent[] students = service.LoadStudents(fileName);

                    Console.WriteLine(" Десеріалізовані дані ");

                    Console.WriteLine($"Кількість студентів: {students.Length}");

                    for (int i = 0; i < students.Length; i++)
                    {
                        BLLStudent student = students[i];

                        Console.WriteLine();
                        Console.WriteLine($" Студент №{i + 1} ");
                        Console.WriteLine($"ID: {student.ID}");
                        Console.WriteLine($"Ім'я: {student.FirstName}");
                        Console.WriteLine($"Прізвище: {student.LastName}");
                        Console.WriteLine($"Курс: {student.Course}");
                        Console.WriteLine($"Студентський квиток: {student.StudentID}");
                        Console.WriteLine($"Середній бал: {student.AverageMark}");
                        Console.WriteLine($"Країна: {student.Country}");
                        Console.WriteLine($"Номер закордонного паспорту: {student.PassportNumber}");
                    }
                }
                else if (operation == "3")
                {
                    BLLStudent[] students =
                        service.GetForeignFirstYearExcellentStudents(fileName);

                    Console.WriteLine();
                    Console.WriteLine("Результат пошуку");
                    Console.WriteLine(
                        "Кількість іноземних студентів-відмінників 1-го курсу: "
                        + students.Length);

                    if (students.Length == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Таких студентів не знайдено.");
                    }
                    else
                    {
                        foreach (BLLStudent student in students)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"ID: {student.ID}");
                            Console.WriteLine($"Ім'я: {student.FirstName}");
                            Console.WriteLine($"Прізвище: {student.LastName}");
                            Console.WriteLine($"Курс: {student.Course}");
                            Console.WriteLine($"Студентський квиток: {student.StudentID}");
                            Console.WriteLine($"Середній бал: {student.AverageMark}");
                            Console.WriteLine($"Країна: {student.Country}");
                            Console.WriteLine($"Номер закордонного паспорту: {student.PassportNumber}");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Невідома операція.");
                }
            }

            else if (entityChoice == "2")
            {
                Console.WriteLine();
                Console.WriteLine("Tailor");

                Console.WriteLine("1 - Ввести та зберегти Tailor");
                Console.WriteLine("2 - Завантажити Tailor з файлу");

                Console.Write("Ваш вибір: ");
                string operation = Console.ReadLine()!;

                if (operation == "1")
                {
                    Console.WriteLine();

                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine()!);

                    Console.Write("Ім'я: ");
                    string firstName = Console.ReadLine()!;

                    Console.Write("Прізвище: ");
                    string lastName = Console.ReadLine()!;

                    Console.Write("Досвід: ");
                    string experience = Console.ReadLine()!;

                    Console.Write("Тип шиття: ");
                    string sewingType = Console.ReadLine()!;

                    BLLTailor tailor =
                        new BLLTailor(id, firstName, lastName, experience, sewingType);

                    service.Save(fileName, tailor);

                    Console.WriteLine();
                    Console.WriteLine("Tailor  збережено у файл: " + fileName);
                }
                else if (operation == "2")
                {
                    BLLTailor tailor = service.LoadTailor(fileName);

                    Console.WriteLine("Десеріалізовані дані");
                    Console.WriteLine($"ID: {tailor.ID}");
                    Console.WriteLine($"Ім'я: {tailor.FirstName}");
                    Console.WriteLine($"Прізвище: {tailor.LastName}");
                    Console.WriteLine($"Досвід: {tailor.Experience}");
                    Console.WriteLine($"Тип шиття: {tailor.SewingType}");
                }
                else
                {
                    throw new ArgumentException("Невідома операція.");
                }
            }

            else if (entityChoice == "3")
            {
                Console.WriteLine();
                Console.WriteLine("Singer");
              
                Console.WriteLine("1 - Ввести та зберегти Singer");
                Console.WriteLine("2 - Завантажити Singer з файлу");

                Console.Write("Ваш вибір: ");
                string operation = Console.ReadLine()!;

                if (operation == "1")
                {
                    Console.WriteLine();

                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine()!);

                    Console.Write("Ім'я: ");
                    string firstName = Console.ReadLine()!;

                    Console.Write("Прізвище: ");
                    string lastName = Console.ReadLine()!;

                    Console.Write("Тип пісень: ");
                    string songType = Console.ReadLine()!;

                    Console.Write("Кількість пісень: ");
                    int songCount = int.Parse(Console.ReadLine()!);

                    BLLSinger singer =
                        new BLLSinger(id, firstName, lastName, songType, songCount);

                    service.Save(fileName, singer);

                    Console.WriteLine();
                    Console.WriteLine("Singer успішно збережено у файл: " + fileName);
                }
                else if (operation == "2")
                {
                    BLLSinger singer = service.LoadSinger(fileName);

                    Console.WriteLine();
                    Console.WriteLine("Десеріалізовані дані");
                    
                    Console.WriteLine($"ID: {singer.ID}");
                    Console.WriteLine($"Ім'я: {singer.FirstName}");
                    Console.WriteLine($"Прізвище: {singer.LastName}");
                    Console.WriteLine($"Тип пісень: {singer.SongType}");
                    Console.WriteLine($"Кількість пісень: {singer.SongCount}");
                }
                else
                {
                    throw new ArgumentException("Невідома операція.");
                }
            }
        }
        catch (StudentDataException exception)
        {
            Console.WriteLine();
            Console.WriteLine("Помилка даних студента: " + exception.Message);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine();
            Console.WriteLine("Помилка: " + exception.Message);
        }
        catch (Exception exception)
        {
            Console.WriteLine();
            Console.WriteLine("Сталася помилка: " + exception.Message);
        }
    }
}

