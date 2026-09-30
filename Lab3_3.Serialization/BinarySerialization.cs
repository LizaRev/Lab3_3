using System;
using System.IO;

public static class BinarySerialization
{
    public static void Serialize(Account[] accounts, string fileName)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Create(fileName)))
        {
            writer.Write(accounts.Length);

            foreach (Account account in accounts)
            {
                writer.Write(account.OwnerCode);
                writer.Write(account.Amount);
            }
        }
    }

    public static Account[] Deserialize(string fileName)
    {
        using (BinaryReader reader =
               new BinaryReader(File.OpenRead(fileName)))
        {
            int count = reader.ReadInt32();

            Account[] accounts = new Account[count];

            for (int i = 0; i < count; i++)
            {
                accounts[i] = new Account
                {
                    OwnerCode = reader.ReadInt32(),
                    Amount = reader.ReadDouble()
                };
            }

            return accounts;
        }
    }
}