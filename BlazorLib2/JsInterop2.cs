using BlazorLib2.Classes;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2
{
    public static class JsInterop2
    {

        public static bool Run(TransferParameters _params)
        {
            return RegisteredFunction.Invoke<bool>(
                "BlazorLib2.JsInterop2.Run", _params);
        }
    }
}
