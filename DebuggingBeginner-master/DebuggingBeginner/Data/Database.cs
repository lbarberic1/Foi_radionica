using DebuggingBeginner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingBeginner.Data
{
    internal class Database
    {
        public List<BankAccount> InitializeData()
        {
            var bankAccounts = new List<BankAccount>()
            {
                new BankAccount(){id = 1, FirstName = "Marko", LastName = "Markic", Balance = 50000},
                new BankAccount(){id = 2, FirstName ="Ivan", LastName ="Ivic", Balance = 10000},
                new BankAccount(){id = 3, FirstName = "Pero", LastName = "Peric", Balance = 15000}
            };

            return bankAccounts;
        }
    }
}
