using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos
{
    public static class LBDJsInterop
    {
        public static ValueTask<int> CalcFib(IJSRuntime jsRuntime, int num)
        {
            return jsRuntime.InvokeAsync<int>(
                "LBDJsFunctions.calcfib",
                num);
        }

        public static ValueTask<string> GenerateNewUser(IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeAsync<string>("LBDJsFunctions.generateNewUser");
        }
    }
}
