using NUnit.Framework;
using System;

namespace BankAccount.Tests;

public class BankAccountTests
{
    private Banking.BankAccount account;

    [SetUp]
    public void SetUp()
    {
        account = new Banking.BankAccount();
    }

    [Test]
    public void Deposit_Zero_Fails()
    {
        Assert.Throws<ArgumentException>(() => account.Deposit(0));
    }

    [Test]
    public void Deposit_NegativeAmount_Fails()
    {
        Assert.Throws<ArgumentException>(() => account.Deposit(-10));
    }

    [Test]
    public void Withdraw_Zero_Fails()
    {
        account.Deposit(100);
        Assert.Throws<ArgumentException>(() => account.Withdraw(0));
    }

    [Test]
    public void Withdraw_NegativeAmount_Fails()
    {
        account.Deposit(100);
        Assert.Throws<ArgumentException>(() => account.Withdraw(-10));
    }

    [Test]
    public void Withdraw_MoreThanBalance_Fails()
    {
        account.Deposit(50);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(60));
    }
}
