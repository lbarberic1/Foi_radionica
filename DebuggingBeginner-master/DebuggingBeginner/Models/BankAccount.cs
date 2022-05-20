using DebuggingBeginner.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingBeginner.Models
{
    internal class BankAccount : IOperations
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }

        public void Deposit(double amount)
        {
            var calculator = new CalculateBalance.CalculateBalance();
            Balance = calculator.DepositBalance(Balance, amount);
            GetCurrentBalance();
        }

        public void GetCurrentBalance()
        {
            Console.WriteLine($"The current balance is: {Balance}");
        }

        public void Withdraw(double amount)
        {
            var calculator = new CalculateBalance.CalculateBalance();
            var balance = calculator.Withdraw(Balance, amount);
            Balance = balance;
            GetCurrentBalance();
        }
    }
}
