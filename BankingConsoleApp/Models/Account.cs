using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp.Models
{
    //public delegate void OnBalanceChanged(decimal newBalance);
    public class BalanceChangedEventArgs : EventArgs {
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
    }
    public class Account : object
    {
        const decimal MIN_BALANCE = 1000;
        public readonly string AccNo ;
        private decimal _balance;
        public event EventHandler<BalanceChangedEventArgs> BalanceChanged;
       // public Action<decimal> BalanceChanged { get; set; }
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
            var oldBalance = this.Balance;
            this.Balance += amount;
            BalanceChanged(this, new BalanceChangedEventArgs { OldBalance = oldBalance,  NewBalance = this.Balance});
            //BalanceChanged(this.Balance);
            //Send email/sms/im/noti/iot/..... to customer amount/balance
        }

        public void Withdraw(decimal amount) {
            var oldBalance = this.Balance;
            this.Balance -= amount;
            BalanceChanged(this, new BalanceChangedEventArgs { OldBalance = oldBalance, NewBalance = this.Balance });
            //BalanceChanged(this.Balance);
            //Send email to customer amount/balance
        }

        override public string ToString() {
            return $"Account {this.AccNo} with Balance {this.Balance}";
        }
      
    }
}
