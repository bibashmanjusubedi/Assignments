using System;

// Custom exception for insufficient funds

public class  InsufficientFundsException : Exception
{
    public InsufficientFundsException():base("Insufficient funds for this operation.")
    {
    }
    public InsufficientFundsException(string message)
    : base(message)
    {
    }
}

public class BankAccount
{
    public string AccountNo { get; set; }
    public string OwnerName { get;set; }

    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        private set
        {
            if (value < 0)
                throw new InvalidOperationException("Balance cannot be negative.");
            balance = value;
        }
    }

    public BankAccount(string accountNo, string ownerName, decimal initialBalance=0)
    {
        AccountNo = accountNo;
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.");
        if (amount > Balance)
            throw new InsufficientFundsException("Insufficient funds.");
        Balance -= amount;
    }

    public decimal GetBalance()
    {
        return Balance;
    }

}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount("ACC001", "John Doe", 1000);

        try
        {
            account.Deposit(500);
            account.Withdraw(2000); // This will trigger InsufficientFundsException
            Console.WriteLine($"Account No: {account.AccountNo} with Current Balance: {account.GetBalance()} belongs to {account.OwnerName}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Argument error: {ex.Message}");
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"Custom error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Operation error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error: {ex.Message}");
        }
    }
}