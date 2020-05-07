using BlazorCounterHelper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Pages
{
    public partial class Index
    {

        private List<TSReport1> report1;

        private int CurrComboFilterOptionsIndex = 0;


        private DateTime LastRefreshDate { get; set; } = DateTime.Now;

        private DateTime fromDate { get; set; } = DateTime.Now.AddHours(-1);
        private DateTime toDate { get; set; } = DateTime.Now;

        private bool DisableEdit = true;

        private bool DisableButton = false;


        private readonly List<string> FilterOptions = new List<string>()
        {
            "Last hour",
            "Last 2 hours",
            "Last 3 hours",
            "Last 12 hours",
            "Last 24 hours",
            "Last 2 Days",
            "Last 3 Days",
            "Last Week",
            "Last Month",
            "All time",
            "Custom",
        };


        protected override void OnAfterRender(bool firstRender)
        {

            if (firstRender)
            {
                CmdGetReport();
            }

            base.OnAfterRender(firstRender);
        }


        private async void CmdGetReport()
        {

            DisableButton = true;

           

            report1 = await CounterHelper.CmdGetReport1(CurrComboFilterOptionsIndex == 9, fromDate, toDate);

            LastRefreshDate = DateTime.Now;

            DisableButton = false;

            StateHasChanged();
        }


        public void fromDateOnChange(ChangeEventArgs e)
        {
            if (DateTime.TryParse(e.Value.ToString(), out _))
            {
                StateHasChanged();
            }

        }

        public void toDateOnChange(ChangeEventArgs e)
        {
            if (DateTime.TryParse(e.Value.ToString(), out _))
            {
                StateHasChanged();
            }

        }

        public void ComboFilterOptionsSelectionChanged(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int val))
            {
                CurrComboFilterOptionsIndex = val;

                DisableEdit = true;

                toDate = DateTime.Now;

                switch (val)
                {
                    case 0:
                        fromDate = toDate.AddHours(-1);
                        break;
                    case 1:
                        fromDate = toDate.AddHours(-2);
                        break;
                    case 2:                      
                        fromDate = toDate.AddHours(-3);
                        break;
                    case 3:
                        fromDate = toDate.AddHours(-12);
                        break;
                    case 4:
                        fromDate = toDate.AddDays(-1);
                        break;
                    case 5:
                        fromDate = toDate.AddDays(-2);
                        break;
                    case 6:
                        fromDate = toDate.AddDays(-3);
                        break;
                    case 7:
                        fromDate = toDate.AddDays(-7);
                        break;
                    case 8:
                        fromDate = toDate.AddDays(-30);
                        break;
                    case 9:
                        fromDate = new DateTime(1900,1,1);
                        break;
                    case 10:
                        DisableEdit = false;
                        break;
                    default:
                        fromDate = toDate.AddHours(-1);
                        break;
                }


            }

        }
    }
}
