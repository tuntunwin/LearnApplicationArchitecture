using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp.Models
{
    internal class AccountTransferService
    {
        public static void Transfer(Account from, Account to, decimal amount) {
            from.Withdraw(amount);
            to.Deposite(amount);
        }
    }
}
