using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp.Models
{
    public class Account
    {
        const decimal MIN_BALANCE = 1000;
        public readonly string AccNo ;
        private decimal _balance;
        //public decimal GetBalance() { return _balance; }
        //public decimal Balance { get { return _balance; } set { _balance = value; } }
        public decimal Balance { 
            get { return _balance; } 
            private set { if (value >= MIN_BALANCE) _balance = value; } 
        }

        public Account(string accNo, decimal balance) {
            this.AccNo = accNo;
            this.Balance = balance;
        }

        public void Deposite(decimal amount) {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount) { 
            this.Balance -= amount;
        }
      
    }
}
