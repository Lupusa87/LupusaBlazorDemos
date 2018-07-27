using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2
{
    public static class JsInterop2
    {

        public static bool Run()
        {
            return RegisteredFunction.Invoke<bool>(
                "BlazorLib2.JsInterop2.Run");
        }
    }
}
