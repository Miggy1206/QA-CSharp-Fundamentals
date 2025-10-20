

class Account
{
    private decimal balance;

    public void withdrawal(decimal amount)
    {
        this.balance -= amount;
    }
    public void deposit(decimal amount)
    {
        this.balance += amount;
    }
    public decimal getBalance(){ return this.balance; }
    public void setBalance(decimal balance) { this.balance = balance; }
}

using System;

class Program
{
    static void Main(string[] args)
    {
        
        try
        {
            Console.WriteLine("Please enter your bank balance:");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            Account account = new Account();
            account.setBalance(balance);
            bool valid_choice = false;
            while (!valid_choice)
            {
                try
                {
                    Console.WriteLine("Choose an option below:\n[1] Deposit\n[2] Withdrawal\n[3] View Balance\n[]");
                    int choice = Convert.ToInt16(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            valid_choice = true;
                            break;
                        case 2:
                            valid_choice = true;
                            break;
                        case 3:
                            valid_choice = true;
                            Console.WriteLine($"Your balance is {account.getBalance()}");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid choice");
                }
            }

        }
        catch (Exception)
        {
            Console.WriteLine("Invalid Balance");
        }
    }
}