# Bank Account Activity

A `BankAccount` class built with **Test-Driven Development (TDD)** using **NUnit**, for the
ALU Programming in C# group activity.

## Requirements implemented

- `Deposit(decimal amount)` — adds money to the account
- `Withdraw(decimal amount)` — removes money from the account
- `GetBalance()` — returns the current balance
- No negative or zero deposits / withdrawals (throws `ArgumentException`)
- No overdrafts — cannot withdraw more than the balance (throws `InvalidOperationException`)

## Project structure

```
BankAccountActivity.sln
├── src/BankAccount/            # the BankAccount class library
│   └── BankAccount.cs
└── tests/BankAccount.Tests/    # NUnit test project
    └── BankAccountTests.cs     # 15 tests
```

## How to build and run the tests

```bash
dotnet build      # compile the solution
dotnet test       # run all NUnit tests
```

## TDD approach (Red → Green → Refactor)

1. **Red** — the tests in `BankAccountTests.cs` were written first and failed to compile
   because the `BankAccount` class did not exist yet.
2. **Green** — the minimal implementation in `BankAccount.cs` was written to make all 15
   tests pass.
3. **Refactor** — the code was tidied (clear validation, XML doc comments) while keeping
   the tests green.

## Suggested two-person task split

The work divides cleanly into two halves so each member contributes:

| Member       | Responsibility                                                                 |
|--------------|--------------------------------------------------------------------------------|
| **Person A** | Project setup + `Deposit` and `GetBalance`: tests and implementation, plus the "no negative/zero deposit" rule. |
| **Person B** | `Withdraw`: tests and implementation, plus the "no negative/zero withdrawal" and "no overdraft" rules. |

Both members follow the same Red → Green → Refactor cycle for their part.
