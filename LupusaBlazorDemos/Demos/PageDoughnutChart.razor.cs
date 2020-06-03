﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageDoughnutChart
    {
        int CurrValue = 75;


        string Color1 = "#fc3807";
        string Color2 = "#52d044";


        private void cmdOnInput(ChangeEventArgs a)
        {
            CurrValue = int.Parse(a.Value.ToString());
        }
    }
}
