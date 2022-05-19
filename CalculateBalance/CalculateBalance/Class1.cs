using System;

namespace CalculateBalance
{
    public class CalculateBalance
    {
        public double DepositBalance(double currentBalance, double depositBalance)
        {
            return currentBalance + depositBalance;
        }

        public double Withdraw(double currentBalance, double withdrawBalance)
        {
            return currentBalance + withdrawBalance;
        }
    }
}
