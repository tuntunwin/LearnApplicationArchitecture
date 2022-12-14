// See https://aka.ms/new-console-template for more information
using BankingConsoleApp;
using BankingConsoleApp.Models;
using System.Collections.Generic;

var Accounts = Enumerable.Range(1, 10).Select(n => { 

    var acc = new Account($"{n}", 100000);
    acc.BalanceChanged += EmailSender;
    acc.BalanceChanged += SMSSender;
    acc.BalanceChanged -= EmailSender;
    return acc;

}).ToList();

void EmailSender(object? sender, BalanceChangedEventArgs e)
{
    var acc = (Account)sender;
    Console.WriteLine($"Email: Your account {acc.AccNo} balance changed from {e.OldBalance} to: { e.NewBalance}");
}

void SMSSender(object? sender, BalanceChangedEventArgs e)
{
    var acc = (Account)sender;
    Console.WriteLine($"SMS: Your account {acc.AccNo} balance changed from {e.OldBalance} to: { e.NewBalance}");
}

//for (int i = 0; i < 10; i++)
//{
//    var acc = new Account($"AA-{i}", 100000);
//    //acc.BalanceChanged = (OnBalanceChanged)Delegate.Combine(new OnBalanceChanged(SendEmail), new OnBalanceChanged(SendSMS)) ;
//    acc.BalanceChanged += new Action<decimal>(balance => Console.WriteLine("Email. Your balnace was updated to " + balance));
//    acc.BalanceChanged += new Action<decimal>(balance => Console.WriteLine("SMS. Your balnace was updated to " + balance));

//    Accounts.Add(acc);
//}


void ShowAccountInfo(Account acc)
{
    //Console.WriteLine($"Acc {acc.AccNo} with Balance:{acc.Balance}");
    Console.WriteLine(acc);
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

        //var acc = new Account(accNo, 100000);
        var acc = Accounts.Where(a => a.AccNo == accNo).First();
        if (acc == null) {
            Console.WriteLine($"Invalid acc no. {accNo}");
            continue;
        }
        acc.Deposite(amount);
       
        Console.Write($"After Deposite=>");
        ShowAccountInfo(acc);

    }
    if (choice == 2)
    {
        Console.WriteLine("Account No?:");
        var accNo = Console.ReadLine();

        Console.WriteLine("Amount ?:");
        var amount = decimal.Parse(Console.ReadLine());

        var acc = Accounts.Where(a => a.AccNo == accNo).First();
        if (acc == null)
        {
            Console.WriteLine($"Invalid acc no. {accNo}");
            continue;
        }
        acc.Withdraw(amount);

        Console.Write($"After Withdraw=>{acc}");
        //ShowAccountInfo(acc);

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
    else if (choice == 4)
    {
        Console.WriteLine("Account No?:");
        var accNo = Console.ReadLine();

        Console.WriteLine("Deposite ?:");
        var depositeAmt = decimal.Parse(Console.ReadLine());

        var newAcc = new Account(accNo, depositeAmt);
        Accounts.Add(newAcc);

    }
    else if (choice == 5)
    {
        foreach (var acc in Accounts) {
            Console.WriteLine(acc);
        }

    }
    else if (choice == 0) {
        Console.Write("Thank you for using our banking app. See you later. Bye");
        return;
    }
    else if (choice == -1)
    {
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