using System;
using System.Collections.Generic;

public class MainProgram
{
    public static void Main()
    {
        var command = Console.ReadLine().Split();

        var accounts = new Dictionary<int, BankAccount>();
        while (command[0] != "End")
        {
            switch (command[0])
            {
                case "Create":
                    Create(command, accounts);
                    break;

                case "Deposit":
                    Deposit(command, accounts);
                    break;

                case "Withdraw":
                    Withdraw(command, accounts);
                    break;

                case "Print":
                    Print(command, accounts);
                    break;
            }

            command = Console.ReadLine().Split();
        }
    }

    private static void Create(string[] command, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(command[1]);
        if (!accounts.ContainsKey(id))
        {
            var acc = new BankAccount();
            acc.ID = id;
            accounts.Add(id, acc);
        }
        else
        {
            Console.WriteLine("Account already exists");
        }
    }

    private static void Deposit(string[] command, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(command[1]);
        var amount = double.Parse(command[2]);
        if (accounts.ContainsKey(id))
        {
            accounts[id].Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(string[] command, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(command[1]);
        var amount = double.Parse(command[2]);
        if (accounts.ContainsKey(id))
        {
            if (accounts[id].Balance >= amount)
            {
                accounts[id].Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Print(string[] command, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(command[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine(accounts[id].ToString());
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }
}