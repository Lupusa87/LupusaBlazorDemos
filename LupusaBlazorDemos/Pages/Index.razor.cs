using BlazorCounterHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Pages
{
    public partial class Index
    {
        private List<TSCounter> counters;

        protected override void OnAfterRender(bool firstRender)
        {

            if (firstRender)
            {
                Timer timer1 = new Timer(Timer1Callback, null, 1, 10000);
            }


            base.OnAfterRender(firstRender);
        }


        private async void Timer1Callback(object o)
        {

            counters = await CounterHelper.CmdGetNewestCounters();
            StateHasChanged();
        }
    }
}
