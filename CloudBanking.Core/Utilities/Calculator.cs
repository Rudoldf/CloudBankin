using CloudBanking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudBanking.Core.Utilities
{
    public class Calculator : ICalculator
    {
        private const double MAX_LOAN_TERM_IN_MONTHS = 1200;
        public  double CalculateMonthlyPaymentForLoan(double amountBorrowed, double loanTermInMonths, double yearlyFixedInterestRate)
        {
            // Validate arguments
            if (yearlyFixedInterestRate > 1)
            {
                throw new ArgumentException("Yearly fixed interest rate must be expressed as a decimal, not a percentage.");
            }
            else if (amountBorrowed <= 0 || loanTermInMonths <= 0 || yearlyFixedInterestRate <= 0)
            {
                throw new ArgumentException("Arguments must be greater than zero.");
            }
            else if (loanTermInMonths > MAX_LOAN_TERM_IN_MONTHS)
            {
                throw new ArgumentException(String.Format("Loan term cannot be greater than {0} months.", MAX_LOAN_TERM_IN_MONTHS));
            }

            double r = yearlyFixedInterestRate / 12;
            double n = loanTermInMonths;
            double p = amountBorrowed;

            // Calculate monthly payment
            double monthlyPayment = (p * r * Math.Pow(1 + r, n)) / (Math.Pow(1 + r, n) - 1);

            // Round result to 2 decimal places
            return Math.Round(monthlyPayment, 2);
        }
    }
}
