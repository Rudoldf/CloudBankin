using System;
using System.Collections.Generic;
using System.Text;

namespace CloudBanking.Core.Interfaces
{
    public interface ICalculator
    {
         public double CalculateMonthlyPaymentForLoan(double amountBorrowed, double loanTermInMonths, double yearlyFixedInterestRate);

    }
}
