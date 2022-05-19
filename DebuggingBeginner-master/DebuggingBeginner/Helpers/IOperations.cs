using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingBeginner.Helpers
{
    public interface IOperations
    {
        public void Withdraw(double ammount);
        public void Deposit(double amount);

        public void GetCurrentBalance();

      
    }  
}
