using NUnit.Framework;
using System;

namespace BankAccount.Tests;

[TestFixture]
public class BankAccountTests
{
    private Banking.BankAccount _account = null!;

    [SetUp]
    public void SetUp()
    {
        _account = new Banking.BankAccount();
    }

    // ---------- GetBalance ----------

    [Test]
    public void GetBalance_OnNewAccount_ReturnsZero()
    {
        Assert.That(_account.GetBalance(), Is.EqualTo(0m));
    }

    [Test]
    public void GetBalance_AfterConstructingWithOpeningBalance_ReturnsOpeningBalance()
    {
        var account = new Banking.BankAccount(100m);
        Assert.That(account.GetBalance(), Is.EqualTo(100m));
    }

    [Test]
    public void Constructor_WithNegativeOpeningBalance_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Banking.BankAccount(-1m));
    }

    // ---------- Deposit ----------

    [Test]
    public void Deposit_PositiveAmount_IncreasesBalance()
    {
        _account.Deposit(50m);
        Assert.That(_account.GetBalance(), Is.EqualTo(50m));
    }

    [Test]
    public void Deposit_MultipleTimes_AccumulatesBalance()
    {
        _account.Deposit(50m);
        _account.Deposit(25.50m);
        Assert.That(_account.GetBalance(), Is.EqualTo(75.50m));
    }

    [Test]
    public void Deposit_ZeroAmount_Throws()
    {
        Assert.Throws<ArgumentException>(() => _account.Deposit(0m));
    }

    [Test]
    public void Deposit_NegativeAmount_Throws()
    {
        Assert.Throws<ArgumentException>(() => _account.Deposit(-10m));
    }

    [Test]
    public void Deposit_NegativeAmount_DoesNotChangeBalance()
    {
        _account.Deposit(100m);
        Assert.Throws<ArgumentException>(() => _account.Deposit(-10m));
        Assert.That(_account.GetBalance(), Is.EqualTo(100m));
    }

    // ---------- Withdraw ----------

    [Test]
    public void Withdraw_PositiveAmountWithinBalance_DecreasesBalance()
    {
        _account.Deposit(100m);
        _account.Withdraw(40m);
        Assert.That(_account.GetBalance(), Is.EqualTo(60m));
    }

    [Test]
    public void Withdraw_EntireBalance_LeavesZero()
    {
        _account.Deposit(100m);
        _account.Withdraw(100m);
        Assert.That(_account.GetBalance(), Is.EqualTo(0m));
    }

    [Test]
    public void Withdraw_ZeroAmount_Throws()
    {
        _account.Deposit(100m);
        Assert.Throws<ArgumentException>(() => _account.Withdraw(0m));
    }

    [Test]
    public void Withdraw_NegativeAmount_Throws()
    {
        _account.Deposit(100m);
        Assert.Throws<ArgumentException>(() => _account.Withdraw(-10m));
    }

    [Test]
    public void Withdraw_MoreThanBalance_Throws()
    {
        _account.Deposit(50m);
        Assert.Throws<InvalidOperationException>(() => _account.Withdraw(50.01m));
    }

    [Test]
    public void Withdraw_FromEmptyAccount_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => _account.Withdraw(10m));
    }

    [Test]
    public void Withdraw_Overdraft_DoesNotChangeBalance()
    {
        _account.Deposit(50m);
        Assert.Throws<InvalidOperationException>(() => _account.Withdraw(100m));
        Assert.That(_account.GetBalance(), Is.EqualTo(50m));
    }
}
