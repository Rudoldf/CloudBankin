using CloudBanking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudBanking.Core.Interfaces
{
    public interface IBankingService
    {
        Task<Loan> SimulateLoan(ICalculator calculator, Info info, AppParameters param);

    }
}
