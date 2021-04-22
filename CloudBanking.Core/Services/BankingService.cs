using CloudBanking.Core.Entities;
using CloudBanking.Core.Interfaces;
using CloudBanking.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudBanking.Core.Services
{
    public class BankingService : IBankingService
    {
        public  async Task<Loan> SimulateLoan(ICalculator calculator, Info info, AppParameters param)
        {
            int duration = info.Duration * 12;
            double annualInterest = param.AnnualInterest / 100;
            double adminFee = Business.GetAdminFee(param, info.Amount);
            double monthlyCost =  calculator.CalculateMonthlyPaymentForLoan(info.Amount, duration, annualInterest);
            double total = duration* monthlyCost;
            double aop = Business.GetAop(info.Amount, adminFee, total);
            double totalAmountInterest = total - info.Amount;

            Loan loan = new Loan
            {
                Amount = info.Amount,
                Duration = duration,
                AnnualInterest= annualInterest,
                Aop=aop,
                MonthlyCost = monthlyCost,
                TotalAmountInterest= totalAmountInterest,
                TotalAdminFee= adminFee,
            };

            await Task.Delay(1);

            return  loan;
        }
    }
}
