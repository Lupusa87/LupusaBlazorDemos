using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public static class BApp1JsInterop
    {
        public static Task<int> CalcFib(int num)
        {
            return JSRuntime.Current.InvokeAsync<int>(
                "BApp1JsFunctions.calcfib",
                num);
        }

        public static Task<string> GenerateNewUser()
        {
            return JSRuntime.Current.InvokeAsync<string>("BApp1JsFunctions.generateNewUser");
        }
    }
}
