using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent
{
    public class BGSnakeCJsInterop
    {
        public static IJSRuntime jsRuntime;

        public static ValueTask<bool> Alert(string a)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BGSnakeCJsInterop.Alert", a);
        }


        public static ValueTask<bool> InitializeSound(int id, string path, bool loop)
        {

            return jsRuntime.InvokeAsync<bool>(
                "BGSnakeCJsInterop.InitializeSound", new {id, path, loop });
        }


        public static ValueTask<bool> ManageSound(int id, string command)
        {
            id = id - 1;
            return jsRuntime.InvokeAsync<bool>(
                "BGSnakeCJsInterop.ManageSound", new { id, command});
        }


        
    }
}
