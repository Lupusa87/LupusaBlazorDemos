using BlazorGameSnakeComponent.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent
{
    public class CompChildWalls : ComponentBase
    {

        List<rect> rects_list = new List<rect>();


        protected override void OnAfterRender(bool firstRender)
        {

            if (LocalData.Curr_Comp_Walls is null)
            {
                LocalData.Curr_Comp_Walls = this;
            }
            base.OnAfterRender(firstRender);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            rects_list = new List<rect>();

            paint_walls();

            Cmd_Render(0, builder);
            rects_list = new List<rect>();

            base.BuildRenderTree(builder);


        }

        public void Refresh()
        {
            StateHasChanged();
        }

        public void paint_walls()
        {

            int w = 0;
            int h = 0;
            foreach (var item in Board.Walls_List)
            {


                if ((int)item.direction > 1)
                {
                    w = item.lenght;
                    h = 1;
                }
                else
                {
                    w = 1;
                    h = item.lenght;
                }


                rects_list.Add(new rect
                {
                    x = Math.Round(item.startpoint.x * Game.point_Width, 2),
                    y = Math.Round(item.startpoint.y * Game.point_Height, 2),
                    width = Game.point_Width * w,
                    height = Game.point_Height * h,
                });

            }

        }

        public void Cmd_Render(int k, RenderTreeBuilder builder)
        {

            builder.OpenElement(k++, "g");
            builder.AddAttribute(k++, "fill", "#999999");

            foreach (var item in rects_list)
            {
                builder.OpenElement(k++, "rect");
                builder.AddAttribute(k++, "x", item.x);
                builder.AddAttribute(k++, "y", item.y);
                builder.AddAttribute(k++, "width", item.width);
                builder.AddAttribute(k++, "height", item.height);
                builder.CloseElement();
            }

            builder.CloseElement();

        }

        public void Dispose()
        {

        }
    }
}
