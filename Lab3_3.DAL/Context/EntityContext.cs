using Lab3_3.DAL.DataProviders;

namespace Lab3_3.DAL.Context;

public class EntityContext
{
    private DataProvider dataProvider;

    public EntityContext(DataProvider dataProvider) 
    {
        this.dataProvider = dataProvider; 
    }

    public void Save(string fileName, object data)
    {
        byte[] bytes = dataProvider.Serialize(data);
        File.WriteAllBytes(fileName, bytes);
    }

    public object Load(string fileName, Type type)
    {
        byte[] bytes = File.ReadAllBytes(fileName);
        return dataProvider.Deserialize(bytes, type);
    }
}