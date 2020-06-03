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
    public class CompPoints: ComponentBase, IDisposable
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
            if (_parent.ChartSettings.DrawPoints)
            {
                SvgHelper SvgHelper1 = new SvgHelper();

                SvgHelper1.Cmd_Render<g>(Paint_Points(),0, builder);
            }

            base.BuildRenderTree(builder);
        }




        private g Paint_Points()
        {
            g g1 = new g();



            if (_parent.Points_List_Private.Count > 0)
            {

                int counter = 0;
                foreach (MyChartPoint item in _parent.Points_List_Private.Where(x => x.IsShown))
                {
                    

                    g1.Children.Add(Add_Visual_Point(new MyPoint(counter * _parent.ChartSettings.StackWidth, MyFunctions.Calculate_Y_Coordinate(_parent, item.Percentage)), item.IsProcessRunning));
                    counter++;
                }

            }

            return g1;
        }

        public circle Add_Visual_Point(MyPoint p, bool b)
        {
            circle c = new circle
            {
                cx = p.X,
                cy = p.Y,
                stroke = _parent.ChartSettings.PointStroke,
                fill = _parent.ChartSettings.PointFill,
                stroke_width = _parent.ChartSettings.PointLineWidth,
            };


            if (b)
            {
                c.r = _parent.ChartSettings.PointRadius;
               
            }
            else
            {
                c.r = _parent.ChartSettings.PointRadius*0.8;
            }

            return c;
        }


        public void Dispose()
        {

        }
    }
}
