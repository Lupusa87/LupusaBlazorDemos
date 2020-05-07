using BlazorGameSnakeComponent.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent
{
    public class CompChildBoard: ComponentBase
    {
        List<rect> rects_list = new List<rect>();


        protected override void OnAfterRender(bool firstRender)
        {
            
            if (LocalData.Curr_Comp_Board is null)
            {
                LocalData.Curr_Comp_Board = this;
            }

            base.OnAfterRender(firstRender);
        }


        public void Refresh()
        {
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            rects_list = new List<rect>();
            Paint_Matrix();
            Cmd_Render(0, builder);
            rects_list = new List<rect>();

            base.BuildRenderTree(builder);

           
        }


       


        public void Paint_Matrix()
        {

            for (var index_x = 0; index_x < Game.x_Length; index_x++)
            {
                for (var index_y = 0; index_y < Game.y_Length; index_y++)
                {

                    if (Board.Matrix[index_x, index_y].MyValue != MyValueType.free)
                    {
                        if (Board.Matrix[index_x, index_y].MyValue != MyValueType.wall)
                        {
                            paint_Board_Element(Board.Matrix[index_x, index_y]);
                        }
                    }
                }
            }

            if (Game.Is_Bot_Mode)
            {
                for (var index = 0; index < Game.Right_Path.Count; index++)
                {
                    select_cell(Game.Right_Path[index].x, Game.Right_Path[index].y);
                }
            }



        }

        public void select_cell(int x, int y)
        {
            string _style = "fill:none;stroke:green;stroke-width=2";
            
            rects_list.Add(new rect
            {
                x = Math.Round(x * Game.point_Width, 2),
                y = Math.Round(y * Game.point_Height, 2),
                width = Game.point_Width,
                height = Game.point_Height,
                style = _style,
            });



        }

        public void paint_Board_Element(Board_Element par_Board_Element)
        {
            
            string _style= "fill:red";


            if (par_Board_Element.MyValue == MyValueType.snake)
            {
                _style = "fill:blue";


                Snake_Element Main_element = Game.SnakeElements.Where(x => x.Is_Main).ToList()[0];

                if (Main_element.Point.x ==par_Board_Element.Point.x && Main_element.Point.y == par_Board_Element.Point.y)
                {
                    _style = "fill:blue;stroke:red;stroke-width:3";
                }

            }
           

            rects_list.Add(new rect
            {
                x = Math.Round(par_Board_Element.Point.x * Game.point_Width,2),
                y = Math.Round(par_Board_Element.Point.y * Game.point_Height,2),
                width = Game.point_Width,
                height = Game.point_Height,
                style = _style,
            });


        }



        public void Cmd_Render(int k, RenderTreeBuilder builder)
        {

            builder.OpenElement(k++, "g");

            
            foreach (var item in rects_list)
            {
                builder.OpenElement(k++, "rect");
                builder.AddAttribute(k++, "x", item.x);
                builder.AddAttribute(k++, "y", item.y);
                builder.AddAttribute(k++, "width", item.width);
                builder.AddAttribute(k++, "height", item.height);
                builder.AddAttribute(k++, "style", item.style);
                builder.CloseElement();
            }

            builder.CloseElement();

        }

        public void Dispose()
        {

        }
    }


    

}
