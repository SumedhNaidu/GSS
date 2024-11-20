using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//abc
namespace Encapsulation4
{
    public class DigitalWallet
    {
        private decimal balance;
        private string walletPassword;
        private List<string> transactionLog = new List<string>();
        public DigitalWallet(string initialPassword)
        {
            balance = 0m;
            walletPassword = initialPassword;
        }
        private void LogTransaction(string transactionDetail)
        {
            transactionLog.Add(transactionDetail);
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount should be positive");
            }
            balance += amount;
            LogTransaction($"Deposited {amount}. Current Balance:{balance}");
        }
        public bool Withdraw(decimal amount, string password)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount should be positive");
            }
            if (walletPassword != password)
            {
                LogTransaction($"Failed withdrawal attempt of {amount}. Incorrect password.");
                return false;
            }
            if (balance - amount < 0)
            {
                LogTransaction($"Failed withdrawal attempt of {amount}. Insufficient funds.");
                return false;
            }
            balance -= amount;
            LogTransaction($"Withdrew {amount}. Current Balance : {balance}");
            return true;
        }
        public decimal CheckBalance(string password)
        {
            if (walletPassword == password)
            {
                return balance;
            }
            else
            {
                throw new UnauthorizedAccessException("Incorrect password.");
            }
        }
        public List<string> GetTransactionLog(string password)
        {
            if (walletPassword == password)
            {
                return new List<string>(transactionLog);
            }
            else
            {
                throw new UnauthorizedAccessException("Incorrect password");
            }
        }
    }
    public class Program
    {
        public static void Main(String[] args)
        {
            DigitalWallet wallet = new DigitalWallet("Pwd@123");
            wallet.Deposit(200m);
            bool isWithdrawn = wallet.Withdraw(50m, "Pwd@123");
            decimal currentBalance = wallet.CheckBalance("Pwd@123");

            Console.ReadKey();
        }
    }
}
