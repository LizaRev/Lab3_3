using System.IO;

public static class CustomSerialization
{
    public static void Serialize(Account[] accounts, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(accounts.Length);

            foreach (Account account in accounts)
            {
                writer.WriteLine(account.OwnerCode);
                writer.WriteLine(account.Amount);
            }
        }
    }

    public static Account[] Deserialize(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            int count = int.Parse(reader.ReadLine()!);

            Account[] accounts = new Account[count];

            for (int i = 0; i < count; i++)
            {
                int ownerCode = int.Parse(reader.ReadLine()!);
                double amount = double.Parse(reader.ReadLine()!);

                accounts[i] = new Account
                {
                    OwnerCode = ownerCode,
                    Amount = amount
                };
            }

            return accounts;
        }
    }
}