using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorPaintComponent
{
    public class BPaintCJsInterop
    {
        public static IJSRuntime jsRuntime;

        public static ValueTask<string> alert(string message)
        {

            return jsRuntime.InvokeAsync<string>(
                "BPaintCJsInterop.alert",
                message);
        }


        public static ValueTask<string> log(string message)
        {

            return jsRuntime.InvokeAsync<string>(
                "BPaintCJsInterop.log",
                message);
        }

        public static ValueTask<bool> GetElementBoundingClientRect(string id, DotNetObjectReference<CompBlazorPaint> dotnethelper)
        {

            return jsRuntime.InvokeAsync<bool>(
                "BPaintCJsInterop.GetElementBoundingClientRect",
                new { id, dotnethelper });
        }

        public static ValueTask<bool> UpdateSVGPosition(string id)
        {
     
            return jsRuntime.InvokeAsync<bool>(
                "BPaintCJsInterop.UpdateSVGPosition", id);
        }


        public static ValueTask<bool> SetCursor(string cursorStyle = "default")
        {

            return jsRuntime.InvokeAsync<bool>(
                "BPaintCJsInterop.SetCursor",
                cursorStyle);
        }
    }
}
