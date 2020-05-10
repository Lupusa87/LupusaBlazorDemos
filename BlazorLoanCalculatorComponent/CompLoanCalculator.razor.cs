using BlazorLoanCalculatorComponent.BusinessLayer;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLoanCalculatorComponent
{
    public partial class CompLoanCalculator: IDisposable
    {

        private double _curr_Amount = 30000;
        protected int _curr_Period { get; set; } = 60;
        protected double _curr_InterestRate { get; set; } = 8;


        protected double Curr_Amount { get; set; } 
       
        protected int Curr_Period { get; set; }
        protected double Curr_InterestRate { get; set; }
       

        protected double Curr_MonthlyPayment { get; set; }


        protected bool Hide_ValidationMessage_Amount { get; set; } = true;
        protected bool Hide_ValidationMessage_Period { get; set; } = true;
        protected bool Hide_ValidationMessage_InterestRate { get; set; } = true;



        protected List<scheduleItem> Curr_Schedule { get; set; }


        protected scheduleItem Curr_Stat { get; set; }

        protected override void OnInitialized()
        {
            Curr_Amount = _curr_Amount;
            Curr_Period = _curr_Period;
            Curr_InterestRate = _curr_InterestRate;

            Calculate();

            base.OnInitialized();
        }

        public bool validate()
        {
            bool result = true;


            if (Curr_Amount >= 1000 && Curr_Amount <= 1000000)
            {
                _curr_Amount = Curr_Amount;
                Hide_ValidationMessage_Amount = true;
            }
            else
            {
                result = false;
                Hide_ValidationMessage_Amount = false;
            }



            if (Curr_Period >= 3 && Curr_Period <= 360)
            {
                _curr_Period = Curr_Period;
                Hide_ValidationMessage_Period = true;
            }
            else
            {
                result = false;
                Hide_ValidationMessage_Period = false;
            }

            if (Curr_InterestRate >= 1.0 && Curr_InterestRate <= 24.0)
            {
                _curr_InterestRate = Curr_InterestRate;
                Hide_ValidationMessage_InterestRate = true;
            }
            else
            {
                result = false;
                Hide_ValidationMessage_InterestRate = false;
            }

            return result;
        }


        public string Get_Row_Color(int id)
        {

            if (id % 2 == 0)
            {

                return "white";
            }
            else
            {

                return "lightblue";
            }
        }

        public void Calculate()
        {
            if (validate())
            {

                Curr_Amount = _curr_Amount;
                Curr_Period = _curr_Period;
                Curr_InterestRate = _curr_InterestRate;

                Curr_MonthlyPayment = Math.Round(LoanFunctions.Get_PMT(_curr_InterestRate / 12 / 100.0, _curr_Period, _curr_Amount), 3);

                Curr_Schedule = LoanFunctions.calculate_schedule_Declining(_curr_InterestRate / 12 / 100.0, _curr_Period, _curr_Amount, Curr_MonthlyPayment);

                Curr_Stat = LoanFunctions.calculate_stat(Curr_Schedule);
            }
            else
            {

                Curr_Amount = _curr_Amount;
                Curr_Period = _curr_Period;
                Curr_InterestRate = _curr_InterestRate;

            }

            StateHasChanged();
        }





        public void Dispose()
        {

        }
    }
}
