# Bank Account Activity

We have `BankAccount` class built with **Test-Driven Development (TDD)** using **NUnit**.

## Rules applied

The `BankAccount` enforces these rules:

- Deposits must be greater than zero (no zero or negative deposits)
- Withdrawals must be greater than zero (no zero or negative withdrawals)
- You cannot withdraw more than the balance (no overdrafts)

## How to build and run the tests

```bash
dotnet build      # compile the solution
dotnet test       # run all NUnit tests
```

