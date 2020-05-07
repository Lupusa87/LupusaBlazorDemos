using BlazorPaintComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PagePaint
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        protected override void OnInitialized()
        {

            BPaintCJsInterop.jsRuntime = jsRuntime;

            base.OnInitialized();
        }
    }
}
