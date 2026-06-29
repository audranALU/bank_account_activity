namespace Banking;

/// <summary>A bank account you can deposit to, withdraw from, and check the balance of.</summary>
public class BankAccount
{
    private decimal _balance;

    /// <summary>Creates an account, optionally with a starting balance.</summary>
    public BankAccount(decimal openingBalance = 0m)
    {
        if (openingBalance < 0m)
            throw new ArgumentException("Opening balance cannot be negative.", nameof(openingBalance));

        _balance = openingBalance;
    }

    /// <summary>Adds money to the account. The amount must be positive.</summary>
    public void Deposit(decimal amount)
    {
        if (amount <= 0m)
            throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));

        _balance += amount;
    }

    /// <summary>Takes money out. The amount must be positive and not more than the balance.</summary>
    public void Withdraw(decimal amount)
    {
        if (amount <= 0m)
            throw new ArgumentException("Withdrawal amount must be greater than zero.", nameof(amount));

        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds: cannot withdraw more than the current balance.");

        _balance -= amount;
    }

    /// <summary>Returns the current balance.</summary>
    public decimal GetBalance() => _balance;
}
