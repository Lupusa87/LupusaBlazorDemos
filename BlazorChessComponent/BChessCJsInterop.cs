using BlazorChessComponent.Engine;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorChessComponent
{
    public class BChessCJsInterop
    {
        public static IJSRuntime jsRuntime;

        public static ValueTask<string> alert(string message)
        {

            return jsRuntime.InvokeAsync<string>(
                "BChessCJsInterop.alert",
                message);
        }

        //public static Task<bool> GetElementBoundingClientRect(string id)
        //{

        //    return JSRuntime.Current.InvokeAsync<bool>(
        //        "JsInteropChessComp.GetElementBoundingClientRect",
        //        id);
        //}

        public static ValueTask<bool> GetElementBoundingClientRect(string id, DotNetObjectReference<ChessEngine> dotnethelper)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BChessCJsInterop.GetElementBoundingClientRect",
                new { id, dotnethelper });
        }


        public static ValueTask<bool> SetCursor(string cursorStyle = "default")
        {

            return jsRuntime.InvokeAsync<bool>(
                "BChessCJsInterop.SetCursor",
                cursorStyle);
        }
    }
}
