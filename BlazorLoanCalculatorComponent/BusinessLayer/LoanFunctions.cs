using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLoanCalculatorComponent.BusinessLayer
{
    public static class LoanFunctions
    {
        public static double Get_PMT(double rate, int period, double loanAmount)
        {
            return (rate + (rate / (Math.Pow((1 + rate), period) - 1))) * loanAmount;
        }


        public static List<scheduleItem> calculate_schedule_Declining(double par_rate, int par_period, double par_Amount, double Par_PMT)
        {

            List<scheduleItem> tmp_schedule = new List<scheduleItem>();

            DateTime tmp_Datetime = DateTime.Today;


            tmp_Datetime = tmp_Datetime.AddMinutes(1);

            double tmp_Amount = par_Amount;



           
            for (int i = 1; i <= par_period; i++)
            {
                scheduleItem tmp_scheduleItem = new scheduleItem();
                tmp_scheduleItem.paymentDate = tmp_Datetime;
                tmp_scheduleItem.scheduleItemID = tmp_schedule.Count + 1;
                tmp_scheduleItem.startBalance = tmp_Amount;
                tmp_scheduleItem.interest = tmp_scheduleItem.startBalance * par_rate;
                tmp_scheduleItem.payment = Par_PMT;
                tmp_scheduleItem.principal = tmp_scheduleItem.payment - tmp_scheduleItem.interest;

                tmp_scheduleItem.principalPercent = tmp_scheduleItem.principal * 100.0 / tmp_scheduleItem.payment;

                tmp_scheduleItem.interestPercent = tmp_scheduleItem.interest * 100.0 / tmp_scheduleItem.payment;

                tmp_scheduleItem.endBalance = tmp_scheduleItem.startBalance - tmp_scheduleItem.principal;



                tmp_schedule.Add(tmp_scheduleItem);
                tmp_Amount = tmp_scheduleItem.endBalance;
                tmp_Datetime = tmp_Datetime.AddMonths(1);
            }

            if (tmp_schedule.Any())
            {
                if (Math.Abs(tmp_schedule.Last().endBalance) < 0.1)
                {
                    tmp_schedule.Last().endBalance = 0;
                }
            }


            return tmp_schedule;
        }


        public static scheduleItem calculate_stat(List<scheduleItem> Par_Schedule)
        {
            scheduleItem result = new scheduleItem();

            result.scheduleItemID  = Par_Schedule.Count;
            result.startBalance = Par_Schedule.First().startBalance;
            result.interest = Par_Schedule.Sum(x=>x.interest);
            result.payment = Par_Schedule.Sum(x => x.payment);
            result.principal = Par_Schedule.Sum(x => x.principal); 
           // result.endBalance = Par_Schedule.Last().endBalance;

            if (Math.Abs(result.principal - result.startBalance) < 0.1)
            {
                result.principal = result.startBalance;
            }



            return result;
        }

    }
}
