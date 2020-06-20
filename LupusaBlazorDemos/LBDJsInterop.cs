using LupusaBlazorDemos.Demos;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos
{
    public static class LBDJsInterop
    {

        public static IJSRuntime jsRuntime;

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

        internal static ValueTask<string> Alert(string message)
        {
            return jsRuntime.InvokeAsync<string>(
                "LBDJsFunctions.Alert", message);
        }

        internal static void ProcessData(string variableName)
        {
            jsRuntime.InvokeVoidAsync("LBDJsFunctions.ProcessData", variableName);
        }


        internal async static ValueTask<bool> HasFile(string inputFileElementID)
        {
            return await jsRuntime.InvokeAsync<bool>("LBDJsFunctions.HasFile", inputFileElementID);

        }

        internal async static ValueTask<bool> ReadFile(string variableName, string inputFileElementID)
        {
            return await jsRuntime.InvokeAsync<bool>("LBDJsFunctions.ReadFile", variableName, inputFileElementID);

        }

        internal async static ValueTask<string> GetFile(string variableName, string inputFileElementID)
        {
            return await jsRuntime.InvokeAsync<string>("LBDJsFunctions.GetFile", variableName, inputFileElementID);

        }

        internal static ValueTask<bool> SetData(string variableName, string t)
        {
            return jsRuntime.InvokeAsync<bool>("LBDJsFunctions.SetData", variableName, t);
        }

        internal static ValueTask<string> GetData(string variableName)
        {
            return jsRuntime.InvokeAsync<string>("LBDJsFunctions.GetData", variableName);
        }

        internal static ValueTask<bool> HandleDrag(IJSRuntime jsRuntime, string elementID, int id, DotNetObjectReference<PageDragAndDrop> dotnetHelper)
        {
            return jsRuntime.InvokeAsync<bool>(
                "LBDJsFunctions.handleDragStart", elementID, id, dotnetHelper);
        }


        internal static ValueTask<bool> HandleDrop(IJSRuntime jsRuntime, string elementID, int id, DotNetObjectReference<PageDragAndDrop> dotnetHelper)
        {
            return jsRuntime.InvokeAsync<bool>(
                "LBDJsFunctions.handleDrop", elementID, id, dotnetHelper);
        }

        public static ValueTask<bool> Beep(int vol, int freq, int duration)
        {
            //https://odino.org/emit-a-beeping-sound-with-javascript/
            return jsRuntime.InvokeAsync<bool>(
                "LBDJsFunctions.Beep", vol, freq, duration);
        }

        public static ValueTask<bool> PianoPlay(char letter, int vol, int freq)
        {
            //https://odino.org/emit-a-beeping-sound-with-javascript/
            return jsRuntime.InvokeAsync<bool>(
                "LBDJsFunctions.PianoPlay", letter, vol, freq);
        }

        public static ValueTask<bool> PianoStop(char letter)
        {
            //https://odino.org/emit-a-beeping-sound-with-javascript/
            return jsRuntime.InvokeAsync<bool>(
                "LBDJsFunctions.PianoStop", letter);
        }
    }
}
