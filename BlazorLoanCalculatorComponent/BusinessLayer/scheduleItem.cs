using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLoanCalculatorComponent.BusinessLayer
{
    public class scheduleItem
    {
        public int scheduleItemID { get; set; }
        public DateTime paymentDate { get; set; }
        public double startBalance { get; set; }
        public double payment { get; set; }
        public double principal { get; set; }
        public double principalPercent { get; set; }
        public double interest { get; set; }
        public double interestPercent { get; set; }
        public double endBalance { get; set; }
    }

}