using BlazorSvgHelper;
using BlazorSvgHelper.Classes.SubClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace BlazorPerformanceChartComponent
{
    public class CompStack : ComponentBase, IDisposable
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
            if (_parent.ChartSettings.DrawStack)
            {
                SvgHelper SvgHelper1 = new SvgHelper();

                SvgHelper1.Cmd_Render<g>(Paint_Stack(), 0, builder);
            }

            base.BuildRenderTree(builder);
        }

        private g Paint_Stack()
        {
            g g1 = new g();




            for (double i = _parent.ChartSettings.StackHeight; i < _parent.ChartSettings.InitialHeight; i = i + _parent.ChartSettings.StackHeight)
            {
                line l = new line
                {
                    x1 = 0,
                    y1 = i,
                    x2 = _parent.ChartSettings.ExtendedWidth,
                    y2 = i,
                    stroke = _parent.ChartSettings.StackColor,
                    stroke_width = _parent.ChartSettings.StackLineWidth,
                };
                g1.Children.Add(l);

            }

            for (double i = _parent.ChartSettings.StackWidth; i < _parent.ChartSettings.ExtendedWidth; i = i + _parent.ChartSettings.StackWidth)
            {
                line l = new line
                {
                    x1 = i,
                    y1 = 0,
                    x2 = i,
                    y2 = _parent.ChartSettings.InitialHeight,
                    stroke = _parent.ChartSettings.StackColor,
                    stroke_width = _parent.ChartSettings.StackLineWidth,
                };
                g1.Children.Add(l);
            }



            return g1;
        }

        public void Dispose()
        {

        }
    }
}
