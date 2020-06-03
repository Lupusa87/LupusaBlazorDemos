using BlazorSvgHelper;
using BlazorSvgHelper.Classes.SubClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPerformanceChartComponent
{
    public class CompBorder : ComponentBase, IDisposable
    {
        bool IsLoaded = false;

        [Parameter]
        public ComponentBase parent { get; set; }


        CompBlazorPerformanceChart _parent;

        protected override void OnInitialized()
        {
            _parent = parent as CompBlazorPerformanceChart;

            base.OnInitialized();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                IsLoaded = true;
            }

            base.OnAfterRender(firstRender);
        }


        public void Refresh()
        {
            if (IsLoaded)
            {
                StateHasChanged();
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            SvgHelper SvgHelper1 = new SvgHelper();

            rect r1 = new rect
            {
                x = 0,
                y = 0,
                width = _parent.ChartSettings.ExtendedWidth,
                height = _parent.ChartSettings.InitialHeight,
                fill = "none",
                stroke = _parent.ChartSettings.BoardBorderColor,
                stroke_width = _parent.ChartSettings.BoardBorderWidth,
            };

            SvgHelper1.Cmd_Render(r1,0, builder);

            base.BuildRenderTree(builder);
        }

        public void Dispose()
        {

        }
    }
}
