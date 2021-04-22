using CloudBanking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudBanking.Core.Interfaces
{
    public interface IBankingRepository
    {
        Task<Loan> SaveLoan(Loan loan); 
    }
}
