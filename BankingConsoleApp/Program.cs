// See https://aka.ms/new-console-template for more information
using BankingConsoleApp;
using BankingConsoleApp.Models;
using System.Collections.Generic;

var Accounts = new List<Account>();

while (true) 
{
    Console.WriteLine("What do you want to? Key in 1 for Even Number checking, 2 for Odd Number checking, 3 to do RoundUp," +
        " 4 for Word Count, 0 to Exit:");
    var inputNum = int.Parse(Console.ReadLine());
    if (inputNum == 1)
    {
        Console.WriteLine("Please enter your number to check Even Number or not...");
        Int32 inputValue = int.Parse(Console.ReadLine());
        Console.WriteLine($"your input values is {inputValue} and it's {inputValue.IsEven()}.");
    }
    else if (inputNum == 2)
    {
        Console.WriteLine("Please enter your number to check Odd Number or not...");
        Int32 inputValue = int.Parse(Console.ReadLine());
        Console.WriteLine($"your input values is {inputValue} and it's {inputValue.IsOdd()}.");
    }
    else if (inputNum == 3)
    {
        Console.WriteLine("Please enter your decimal number to convert round up value...");
        decimal inputValue = decimal.Parse(Console.ReadLine());
        Console.WriteLine($"your input values is {inputValue} and after round up - {inputValue.RoundUp()}.");
    }
    else if (inputNum == 4)
    {
        Console.WriteLine("Please enter a word...");
        string inputValue = Console.ReadLine();
        Console.WriteLine($"your input string is '{inputValue}' and total length is {inputValue.WordCount()}.");
    }
    else if (inputNum == 0)
    {
        Console.WriteLine("Thank you for your effort!");
        return;
    }
}


for (int i = 0; i < 10; i++)
{
    var acc = new Account($"AA-{i}", 100000);
    Accounts.Add(acc);
}

Account SearchAccountByAccNo(string accNo) {
    foreach (var acc in Accounts) {
        if (acc.AccNo == accNo)
            return acc;
    }
    return null;
}

Console.WriteLine("Welcome To CLI Banking Application");
Console.WriteLine("----------------------");
while (true)
{
    Console.WriteLine("What do you want to? Key in 1 to Deposite, 2 to Withdraw, 3 to Transfer, 4 to Open Account, 5 to List Accounts, 0 to Exit:");
    var choice = int.Parse(Console.ReadLine());
    if (choice == 1)
    {
        Console.WriteLine("Account No?:");
        var accNo = Console.ReadLine();

        Console.WriteLine("Amount ?:");
        var amount = decimal.Parse(Console.ReadLine());

        var acc = SearchAccountByAccNo(accNo);
        if (acc == null) {
            Console.WriteLine($"Invalid acc no. {accNo}");
            continue;
        }
        acc.Deposite(amount);
       
        Console.WriteLine($"After Deposite => {acc}");
    }
    if (choice == 2)
    {
        Console.WriteLine("Account No?:");
        var accNo = Console.ReadLine();

        Console.WriteLine("Amount ?:");
        var amount = decimal.Parse(Console.ReadLine());

        var acc = SearchAccountByAccNo(accNo);
        if (acc == null)
        {
            Console.WriteLine($"Invalid acc no. {accNo}");
            continue;
        }
        acc.Withdraw(amount);

        Console.WriteLine($"After Withdraw => {acc}");
    }
    else if (choice == 3)
    {
        Console.WriteLine("From Account No?:");
        var fromAccNo = Console.ReadLine();

        Console.WriteLine("To Account No?:");
        var toAccNo = Console.ReadLine();

        Console.WriteLine("Amount ?:");
        var amount = decimal.Parse(Console.ReadLine());

        var fromAcc = SearchAccountByAccNo(fromAccNo);
        var toAcc = SearchAccountByAccNo(toAccNo);
        AccountTransferService.Transfer(fromAcc, toAcc, amount);

        Console.WriteLine($"After Transfer at From Account => {fromAcc}");
        Console.WriteLine($"After Transfer at To Account => {toAcc}");
    }
    else if (choice == 4)
    {
        Console.WriteLine("Account No?:");
        var accNo = Console.ReadLine();

        Console.WriteLine("Deposite ?:");
        var depositeAmt = decimal.Parse(Console.ReadLine());

        var newAcc = new Account(accNo, depositeAmt);
        Accounts.Add(newAcc);

    }
    else if (choice == 5) {
        var no = 1;
        foreach (var acc in Accounts)
        {
            Console.WriteLine($"{no++}:{acc}");
        }
    }
    else if (choice == 0)
    {
        Console.WriteLine("Thank you for using our banking app. See you later. Bye");
        return;
    }
    else
    {
        Console.WriteLine("Invalid choice!");
    }
}