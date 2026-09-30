using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Account[] accounts = new Account[4];

        Console.WriteLine("Введіть дані 4 рахунків.");

        for (int i = 0; i < accounts.Length; i++)
        {
            Console.WriteLine();
            Console.WriteLine("Рахунок №" + (i + 1));

            Console.Write("Введіть код власника: ");
            int ownerCode = int.Parse(Console.ReadLine()!);

            Console.Write("Введіть суму: ");
            double amount = double.Parse(Console.ReadLine()!);

            accounts[i] = new Account
            {
                OwnerCode = ownerCode,
                Amount = amount
            };
        }

        Console.WriteLine();
        Console.WriteLine("Інформація про рахунки");

        for (int i = 0; i < accounts.Length; i++)
        {
            Console.WriteLine(
                "Рахунок №" + (i + 1) + ": " +
                accounts[i].InfoAboutAccount());
        }

        Console.WriteLine();
        Console.WriteLine("Поповнення рахунку");

        Console.Write("Виберіть номер рахунку: ");
        int increaseIndex = int.Parse(Console.ReadLine()!) - 1;

        Console.Write("Введіть суму для поповнення: ");
        double increaseAmount = double.Parse(Console.ReadLine()!);

        accounts[increaseIndex].IncreaseBalance(increaseAmount);

        Console.WriteLine("Новий стан рахунку:");
        Console.WriteLine(accounts[increaseIndex].InfoAboutAccount());

        Console.WriteLine();
        Console.WriteLine("Зняття коштів");

        Console.Write("Виберіть номер рахунку: ");
        int decreaseIndex = int.Parse(Console.ReadLine()!) - 1;

        Console.Write("Введіть суму для зняття: ");
        double decreaseAmount = double.Parse(Console.ReadLine()!);

        accounts[decreaseIndex].DecreaseBalance(decreaseAmount);

        Console.WriteLine("Новий стан рахунку:");
        Console.WriteLine(accounts[decreaseIndex].InfoAboutAccount());

        Console.WriteLine();
        Console.WriteLine("Переказ коштів на іншого власника");

        Console.Write("Виберіть рахунок, з якого перевести кошти: ");
        int senderIndex = int.Parse(Console.ReadLine()!) - 1;

        Console.Write("Виберіть рахунок, на який перевести кошти: ");
        int receiverIndex = int.Parse(Console.ReadLine()!) - 1;

        Console.Write("Введіть суму переказу: ");
        double transferAmount = double.Parse(Console.ReadLine()!);

        accounts[senderIndex].TransferMoneyToAnotherOwner(
            accounts[receiverIndex],
            transferAmount);

        Console.WriteLine();
        Console.WriteLine("Рахунок відправника:");
        Console.WriteLine(accounts[senderIndex].InfoAboutAccount());

        Console.WriteLine("Рахунок отримувача:");
        Console.WriteLine(accounts[receiverIndex].InfoAboutAccount());

        Console.WriteLine();
        Console.WriteLine("Перерахування за курсом");

        Console.Write("Виберіть номер рахунку: ");
        int convertIndex = int.Parse(Console.ReadLine()!) - 1;

        Console.Write("Введіть курс: ");
        double rate = double.Parse(Console.ReadLine()!);

        double convertedAmount =
            accounts[convertIndex].ConvertByRate(rate);

        Console.WriteLine(
            "Сума після перерахування: " + convertedAmount);

        Console.WriteLine();
        Console.WriteLine("JSON серіалізація та десеріалізація");

        JsonSerialization.Serialize(
            accounts,
            "accounts.json");

        Account[] jsonAccounts =
            JsonSerialization.Deserialize(
                "accounts.json");

        foreach (Account account in jsonAccounts)
        {
            Console.WriteLine(account.InfoAboutAccount());
        }

        Console.WriteLine();
        Console.WriteLine("XML серіалізація та десеріалізація");

        XmlSerialization.Serialize(
            accounts,
            "accounts.xml");

        Account[] xmlAccounts =
            XmlSerialization.Deserialize(
                "accounts.xml");

        foreach (Account account in xmlAccounts)
        {
            Console.WriteLine(account.InfoAboutAccount());
        }

        Console.WriteLine();
        Console.WriteLine("Binary серіалізація та десеріалізація");

        BinarySerialization.Serialize(
            accounts,
            "accounts.bin");

        Account[] binaryAccounts =
            BinarySerialization.Deserialize(
                "accounts.bin");

        foreach (Account account in binaryAccounts)
        {
            Console.WriteLine(account.InfoAboutAccount());
        }

        Console.WriteLine();
        Console.WriteLine("Custom серіалізація та десеріалізація");

        CustomSerialization.Serialize(
            accounts,
            "accounts.txt");

        Account[] customAccounts =
            CustomSerialization.Deserialize(
                "accounts.txt");

        foreach (Account account in customAccounts)
        {
            Console.WriteLine(account.InfoAboutAccount());
        }

        Console.WriteLine();
        Console.WriteLine("Серіалізація та десеріалізація List<Account>");

        List<Account> accountList =
            new List<Account>();

        foreach (Account account in accounts)
        {
            accountList.Add(account);
        }

        string listJson =
            JsonSerializer.Serialize(
                accountList,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

        File.WriteAllText(
            "accounts-list.json",
            listJson);

        string restoredListJson =
            File.ReadAllText(
                "accounts-list.json");

        List<Account> restoredAccountList =
            JsonSerializer.Deserialize<List<Account>>(
                restoredListJson)!;

        Console.WriteLine();
        Console.WriteLine("Відновлена колекція:");

        foreach (Account account in restoredAccountList)
        {
            Console.WriteLine(account.InfoAboutAccount());
        }

        Console.WriteLine();
        Console.WriteLine("Порівняння масиву та колекції");

        bool areEqual = true;

        for (int i = 0; i < accounts.Length; i++)
        {
            if (accounts[i].OwnerCode != restoredAccountList[i].OwnerCode ||
                accounts[i].Amount != restoredAccountList[i].Amount)
            {
                areEqual = false;
                break;
            }
        }

        if (areEqual)
        {
            Console.WriteLine(
                "Масив і колекція містять однакові дані.");
        }
        else
        {
            Console.WriteLine(
                "Масив і колекція містять різні дані.");
        }

        Console.WriteLine();
        Console.WriteLine("Усі операції виконано.");
    }
}