
namespace Lab3_3.DAL.DataProviders;

public static class DataProviderFactory //відповидає за вибір нашох серіалізації,який потім обере користувач
{
    public static DataProvider Create(
        string serializationType,
        string entityType)
    {
        if (serializationType == "1")
        {
            if (entityType == "Student")
            {
                return new StudentBinaryDataProvider();
            }

            if (entityType == "Tailor")
            {
                return new TailorBinaryDataProvider();
            }

            if (entityType == "Singer")
            {
                return new SingerBinaryDataProvider();
            }
        }

        if (serializationType == "2")
        {
            return new JsonDataProvider();
        }

        if (serializationType == "3")
        {
            return new XmlDataProvider();
        }

        if (serializationType == "4")
        {
            if (entityType == "Student")
            {
                return new StudentCustomDataProvider();
            }

            if (entityType == "Tailor")
            {
                return new TailorCustomDataProvider();
            }

            if (entityType == "Singer")
            {
                return new SingerCustomDataProvider();
            }
        }

        throw new ArgumentException(
            "Непідтримуваний тип серіалізації або сутності.");
    }
}

