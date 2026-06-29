# Bank Account Activity

We have `BankAccount` class built with **Test-Driven Development (TDD)** using **NUnit**.

## What it does

The `BankAccount` class has three methods:

- `Deposit(decimal amount)` — adds money to the account
- `Withdraw(decimal amount)` — takes money out of the account
- `GetBalance()` — returns the current balance

It also enforces these rules:

- Deposits must be greater than zero (no zero or negative deposits)
- Withdrawals must be greater than zero (no zero or negative withdrawals)
- You cannot withdraw more than the balance (no overdrafts)

## Project structure

```
BankAccountActivity.slnx          # solution file
├── BankAccount/                  # the BankAccount class
│   ├── BankAccount.cs
│   └── BankAccount.csproj
└── BankAccount.Tests/            # NUnit tests
    ├── BankAccountTests.cs       # 5 tests
    └── BankAccount.Tests.csproj
```

## How to build and run the tests

```bash
dotnet build      # compile the solution
dotnet test       # run all NUnit tests
```

## The tests

`BankAccountTests.cs` checks the rules of the account:

| Test                             | What it checks                                                      |
| -------------------------------- | ------------------------------------------------------------------- |
| `Deposit_Zero_Fails`             | Depositing 0 Fails `ArgumentException`                              |
| `Deposit_NegativeAmount_Fails`   | Depositing a negative amount Fails `ArgumentException`              |
| `Withdraw_Zero_Fails`            | Withdrawing 0 Fails `ArgumentException`                             |
| `Withdraw_NegativeAmount_Fails`  | Withdrawing a negative amount Fails `ArgumentException`             |
| `Withdraw_MoreThanBalance_Fails` | Withdrawing more than the balance Fails `InvalidOperationException` |

