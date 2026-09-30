public class Account
{
    public int OwnerCode { get; set; }
    public double Amount { get; set; }

    public void IncreaseBalance(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума має бути > 0");

        Amount += amount;
    }

    public void DecreaseBalance(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума має бути > 0");

        if (amount > Amount)
            throw new InvalidOperationException("Недостатньо коштів.");

        Amount -= amount;
    }

    public void TransferMoneyToAnotherOwner(Account anotherOwner, double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума має бути > 0");

        if (amount > Amount)
            throw new InvalidOperationException("Недостатньо коштів.");

        Amount -= amount;
        anotherOwner.Amount += amount;
    }

    public double ConvertByRate(double rate)
    {
        if (rate <= 0)
            throw new ArgumentException("Курс повинен бути більшим за 0.");

        return Amount * rate;
    }

    public string InfoAboutAccount()
    {
        return "Код власника: " + OwnerCode + ", Баланс на рахунку: " + Amount;
    }
}