namespace Banking;

public class BankAccount
{
    private decimal balance = 0;

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");

        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Please withdraw real amount!");

        if (amount > balance)
            throw new InvalidOperationException("Unsufficient balance, please topup your account!");

        balance -= amount;
    }
    public decimal GetBalance()
    {
        return balance;
    }
}
