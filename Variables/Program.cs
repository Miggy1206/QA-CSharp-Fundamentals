using System;


class Account
{
    private decimal balance;

    public void withdrawal(decimal amount)
    {
        if(amount < 0)
        {
            throw new ArithmeticException("Amount can not be less than 0.");
        }
        else if (amount > this.balance)
        {
            throw new ArithmeticException("Amount is bigger than the balance and you do not have an overdraft.");
        }
        else
        {
            this.balance -= amount;
        }
        }
    public void deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArithmeticException("Amount can not be less than 0.");
        }
        else
        {
            this.balance += amount;
        }
    }
    public decimal getBalance(){ return this.balance; }
    public void setBalance(decimal balance) { this.balance = balance; }
}



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
            bool exit_choice = false;
            while (!exit_choice)
            {
                try
                {
                    Console.WriteLine("Choose an option below:\n[1] Deposit\n[2] Withdrawal\n[3] View Balance\n[4] Exit\n[]");
                    int choice = Convert.ToInt16(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                Console.WriteLine("How much are you wanting to deposit?");
                                decimal deposit_amount = Convert.ToDecimal(Console.ReadLine());
                                account.deposit(deposit_amount);
                            }
                            catch(ArithmeticException err)
                            {
  
                                Console.WriteLine(err.Message);
                            }
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine("How much are you wanting to withdraw?");
                                decimal withdrawal_amount = Convert.ToDecimal(Console.ReadLine());
                                account.withdrawal(withdrawal_amount);
                            }
                            catch (ArithmeticException err)
                            {
                                Console.WriteLine(err.Message);
                            }
                            break;
                        case 3:
                            Console.WriteLine($"Your balance is {account.getBalance()}");
                            break;
                        case 4:
                            exit_choice = true;
                            break;
                        default:
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