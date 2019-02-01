using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorApp1.Pages
{
    public class VirtualizedListPage_Logic : BlazorComponent
    {
        private int _CurrValue = 1;
        public int CurrValue
        {
            get
            {
                return _CurrValue;
            }

            set
            {
                _CurrValue = value;
                OnScroll(value);
            }
        }



        private int _RequestedValue = 0;
        public int RequestedValue
        {
            get
            {
                return _RequestedValue;
            }

            set
            {
                _RequestedValue = value;
                if (value > 0)
                {
                    CmdBringIntoView(value);
                }

            }
        }

        public string LogMessage = string.Empty;


        public List<MyItem> List1 = new List<MyItem>();


        public List<MyItem> List_Displayed = new List<MyItem>();

        public int Curr_Take = 20;

        public int Curr_Items_Count = 10000;

        protected override void OnInit()
        {

            for (int i = 1; i <= Curr_Items_Count; i++)
            {
                List1.Add(new MyItem
                {
                    id = i,
                    Name = Guid.NewGuid().ToString("d").Substring(1, 4),
                });
            }

            List_Displayed = new List<MyItem>();
            List_Displayed.AddRange(List1.Take(Curr_Take));

            base.OnInit();
        }


        //onchange="@CmdSlide" 



        public void OnScroll(int Par_Value)
        {

            int Curr_Skip = Par_Value - Curr_Take;

            List_Displayed = new List<MyItem>();
            if (Curr_Skip > 0)
            {

                List_Displayed.AddRange(List1.Skip(Curr_Skip).Take(Curr_Take));
            }
            else
            {

                List_Displayed.AddRange(List1.Take(Curr_Take));
            }
        }


        public void CmdSlide(UIChangeEventArgs e)
        {
            LogMessage = "abc" + CurrValue + "    " + e.Value.ToString();
            StateHasChanged();
        }


        public void CmdBringIntoView(int k)
        {

            k = k + Curr_Take - 1;


            if (k < 0)
            {
                k = 0;
            }


            if (k > Curr_Items_Count)
            {
                k = Curr_Items_Count;
            }

            OnScroll(k);




        }

    }

    public class MyItem
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}