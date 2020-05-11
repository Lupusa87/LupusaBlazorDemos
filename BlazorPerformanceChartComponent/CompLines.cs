using BlazorPerformanceChartComponent.classes;
using BlazorSvgHelper;
using BlazorSvgHelper.Classes.SubClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPerformanceChartComponent
{
    public class CompLines : ComponentBase, IDisposable
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

            SvgHelper1.Cmd_Render<g>(Paint_Points(), 0, builder);

            base.BuildRenderTree(builder);
        }

        private g Paint_Points()
        {
            g g1 = new g();

            if (_parent.Points_List_Private.Count > 0)
            {

                MyPoint p = new MyPoint(0, MyFunctions.Calculate_Y_Coordinate(_parent,_parent.Points_List_Private.Where(x => x.IsShown).First().Percentage));
                MyPoint p2 = new MyPoint(0, 0);

               
                int counter = 0;
                foreach (MyChartPoint item in _parent.Points_List_Private.Where(x=>x.IsShown))
                {
                    

                    p2 = new MyPoint(counter * _parent.ChartSettings.StackWidth, MyFunctions.Calculate_Y_Coordinate(_parent, item.Percentage));
                 

                    line l = new line
                    {
                        x1 = p.X,
                        y1 = p.Y,
                        x2 = p2.X,
                        y2 = p2.Y,
                        stroke = _parent.ChartSettings.LineColor,
                        stroke_width = _parent.ChartSettings.LineWidth,
                    };
                    g1.Children.Add(l);

                    p.X = p2.X;
                    p.Y = p2.Y;

                    counter++;
                }

            }


            return g1;
        }


        public void Dispose()
        {

        }
    }
}
