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

    public class CompPolygone : ComponentBase, IDisposable
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
            if (_parent.ChartSettings.DrawArea)
            {
                SvgHelper SvgHelper1 = new SvgHelper();

                SvgHelper1.Cmd_Render<g>(Paint_Points(), 0, builder);
            }
            base.BuildRenderTree(builder);
        }

        private g Paint_Points()
        {
            g g1 = new g();



            if (_parent.Points_List_Private.Count > 0)
            {


                List<MyPoint> Points_for_Polygon = new List<MyPoint>();

                MyPoint p = new MyPoint(0, MyFunctions.Calculate_Y_Coordinate(_parent, _parent.Points_List_Private.Where(x => x.IsShown).First().Percentage));
                MyPoint p2 = new MyPoint(0, 0);

                Points_for_Polygon.Add(new MyPoint(0, _parent.ChartSettings.InitialHeight));
                Points_for_Polygon.Add(new MyPoint(p.X, p.Y));

                int counter = 0;
                foreach (MyChartPoint item in _parent.Points_List_Private.Where(x => x.IsShown))
                {
                   

                    p2 = new MyPoint(counter * _parent.ChartSettings.StackWidth, MyFunctions.Calculate_Y_Coordinate(_parent, item.Percentage));
                    Points_for_Polygon.Add(p2);

                    counter++;
                }




                Points_for_Polygon.Add(new MyPoint(p2.X, _parent.ChartSettings.InitialHeight));


                StringBuilder sb = new StringBuilder();

                foreach (var item in Points_for_Polygon)
                {
                    sb.Append(item.X);
                    sb.Append(",");
                    sb.Append(item.Y);
                    sb.Append(" ");
                }


                polygon pl = new polygon
                {
                    points = sb.ToString().Trim(),
                    style = "fill:"+ _parent.ChartSettings.AreaColor,

                };

                g1.Children.Add(pl);


            }


            return g1;
        }


        public void Dispose()
        {

        }
    }
}
