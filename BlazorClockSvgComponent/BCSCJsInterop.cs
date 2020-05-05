using BlazorClockSvgComponent.Classes;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorClockSvgComponent
{
    public static class BCSCJsInterop
    {

        public static ValueTask<bool> Run(TransferParameters _params, IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BCSCJsInterop.Run", _params);
        }
    }
}
