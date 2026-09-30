namespace Lab3_3.DAL.DataProviders;

public abstract class DataProvider 
{
    public abstract byte[] Serialize(object data);

    public abstract object Deserialize(byte[] data, Type type);
}