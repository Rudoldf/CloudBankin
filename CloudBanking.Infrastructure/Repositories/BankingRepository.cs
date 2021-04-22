using CloudBanking.Core.Entities;
using CloudBanking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudBanking.Infrastructure.Repositories
{
    public class BankingRepository : IBankingRepository
    {
      

        public async Task<Loan> SaveLoan(Loan loan)
        {

            //here we mock saving in a BD
            await Task.Delay(2000);
            return loan;

        }
    }
}
