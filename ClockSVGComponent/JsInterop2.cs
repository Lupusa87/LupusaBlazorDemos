using ClockSVGComponent.Classes;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockSVGComponent
{
    public static class JsInterop2
    {

        public static bool Run(TransferParameters _params)
        {
            return RegisteredFunction.Invoke<bool>(
                "ClockSVGComponent.JsInterop2.Run", _params);
        }
    }
}
