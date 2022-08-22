// See https://aka.ms/new-console-template for more information
using BankingConsoleApp;
using BankingConsoleApp.Models;

Console.WriteLine("Welcome To CLI Banking Application");
Console.WriteLine("----------------------");
while (true)
{
    Console.WriteLine("What do you want to? Key in 1 to Deposite, 2 to Withdraw, 3 to Transfer, 0 to Exit:");
    var choice = int.Parse(Console.ReadLine());
    if (choice == 1)
    {
        Console.WriteLine("Account No?:");
        var accNo = Console.ReadLine();

        Console.WriteLine("Amount ?:");
        var amount = decimal.Parse(Console.ReadLine());

        var acc = new Account(accNo, 100000);
        acc.Deposite(amount);

        Console.WriteLine($"After Deposite => Acc No:{acc.AccNo}, Balance:{acc.Balance}");

    }
    if (choice == 2)
    {
        Console.WriteLine("Account No?:");
        var accNo = Console.ReadLine();

        Console.WriteLine("Amount ?:");
        var amount = decimal.Parse(Console.ReadLine());

        var acc = new Account(accNo, 100000);
        acc.Withdraw(amount);

        Console.WriteLine($"After Withdraw => Acc No:{acc.AccNo}, Balance:{acc.Balance}");

    }
    else if (choice == 3)
    {
        Console.WriteLine("From Account No?:");
        var fromAccNo = Console.ReadLine();

        Console.WriteLine("To Account No?:");
        var toAccNo = Console.ReadLine();

        Console.WriteLine("Amount ?:");
        var amount = decimal.Parse(Console.ReadLine());

        var fromAcc = new Account(fromAccNo, 100000);
        var toAcc = new Account(toAccNo, 100000);
        AccountTransferService.Transfer(fromAcc, toAcc, amount);

        Console.WriteLine($"After Transfer => Acc No:{fromAcc.AccNo}, Balance:{fromAcc.Balance}");
        Console.WriteLine($"After Transfer => Acc No:{toAcc.AccNo}, Balance:{toAcc.Balance}");

    }
    else if (choice == 0) {
        Console.Write("Thank you for using our banking app. See you later. Please come again. Bye Bye");
        return;
    }
     else if (choice == -1) {
        return;
    }
    else
    {
        Console.WriteLine("Invalid choice!");
    }
}

//var accA = new Account("Account-A", 100000);
//var accB = new Account("Account-B", 100000);
//AccountTransferService.Transfer(accA, accB, 50000);

//Console.WriteLine($"After Transfer => Acc No:{accA.AccNo}, Balance:{accA.Balance}");
//Console.WriteLine($"After Transfer => Acc No:{accB.AccNo}, Balance:{accB.Balance}");