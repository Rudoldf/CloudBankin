using System;
using System.Collections.Generic;
using System.Text;

namespace CloudBanking.Core.Entities
{
    public class Loan
    {
        public double Amount { get; set; }
        public int Duration { get; set; }
        public double AnnualInterest { get; set; }
        public double Aop { get; set; }
        public double MonthlyCost { get; set; }
        public double TotalAmountInterest { get; set; }
        public double TotalAdminFee { get; set; }

    }


}
