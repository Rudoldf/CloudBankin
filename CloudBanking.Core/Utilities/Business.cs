using CloudBanking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudBanking.Core.Utilities
{
    public static class Business
    {
        public static double GetAop(double Amount, double Fee, double Total)
        {
            double aop = ((Total + Fee) / Amount) *100;
            return aop;
        }

        public static double GetAdminFee(AppParameters param,double Amount)
        {

            var fee = Amount*(param.Fee / 100);
            if (fee > param.LimitFee)
            {
                fee = param.LimitFee;
            }

            return fee;

        }
    }
}
