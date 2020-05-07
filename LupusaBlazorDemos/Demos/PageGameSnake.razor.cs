using BlazorGameSnakeComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageGameSnake
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }


        protected override void OnInitialized()
        {


            BGSnakeCJsInterop.jsRuntime = jsRuntime;

            base.OnInitialized();
        }
    }
}
