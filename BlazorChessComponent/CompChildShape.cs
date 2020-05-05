using BlazorChessComponent.Engine;
using BlazorSvgHelper.Classes.SubClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChessComponent
{
    public class CompChildShape : ComponentBase
    {
        [Parameter]
        public ChessEngine ChessEngine1 { get; set; }

        bool IsCompLoaded = false;

        List<text> texts_list = new List<text>();
        List<rect> rects_list = new List<rect>();

        protected override void OnInitialized()
        {
            if (IsCompLoaded == false)
            {
                if (ChessEngine1.compSettings.Curr_Comp_Shape is null)
                {
                    ChessEngine1.compSettings.Curr_Comp_Shape = this;
                }
                IsCompLoaded = true;
            }

            base.OnInitialized();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

           
            texts_list = new List<text>();
            rects_list = new List<rect>();

            paint_shape();

            Cmd_Render(0, builder);
            texts_list = new List<text>();
            rects_list = new List<rect>();

            base.BuildRenderTree(builder);


        }

        public void Refresh()
        {
            StateHasChanged();
        }

        public void paint_shape()
        {
            myPoint MyPoint = new myPoint();

            int i = 0;
            foreach (string item in ChessEngine1.Board_Array_Letters)
            {
              
                texts_list.Add(new text()
                {
                    x = i * ChessEngine1.MyCell.width + ChessEngine1.MyCell.width * 0.9,
                    y = ChessEngine1.MyCell.height * 0.3,
                    content = item,
                    dominant_baseline = "middle",
                });

                texts_list.Add(new text()
                {
                    x = i * ChessEngine1.MyCell.width + ChessEngine1.MyCell.width * 0.9,
                    y = ChessEngine1.compSettings.CompHeight - ChessEngine1.MyCell.height * 0.25,
                    content = item,
                    dominant_baseline = "middle",
                });

      

                int k = 8 - i;

                texts_list.Add(new text()
                {
                    x = ChessEngine1.MyCell.width * 0.25,
                    y = i * ChessEngine1.MyCell.height  + ChessEngine1.MyCell.height * 1.1,
                    content = k.ToString(),
                    text_anchor = "middle",
                });


                texts_list.Add(new text()
                {
                    x = ChessEngine1.compSettings.CompWidth - ChessEngine1.MyCell.width * 0.25,
                    y = i * ChessEngine1.MyCell.height + ChessEngine1.MyCell.height * 1.1,
                    content = k.ToString(),
                    text_anchor = "middle",
                });

                i++;

            }

            int row_index = 0;
            int column_index = 0;

            string tmp_color = string.Empty;



            rects_list.Add(new rect
            {
                x = ChessEngine1.MyCell.width / 2,
                y = ChessEngine1.MyCell.height / 2,
                width = ChessEngine1.compSettings.CompWidth - ChessEngine1.MyCell.width,
                height = ChessEngine1.compSettings.CompHeight - ChessEngine1.MyCell.height,
                stroke = ChessEngine1.MyCell.black_color,
                stroke_width = ChessEngine1.MylineWidths.dafis_charcho,
            });

            for (int index = 0; index < ChessEngine1.Board_Array.Length; index++)
            {

                if (index > 7)
                {
                    column_index = (index) % 8;
                    row_index = (index - column_index) / 8;
                }
                else
                {
                    column_index = index;
                    row_index = 0;
                }

                MyPoint.X = ChessEngine1.MyCell.width * column_index;
                MyPoint.Y = ChessEngine1.MyCell.height * row_index;


                if (MyFunctions.Get_Cell_Color_By_Index(index))
                {
                    tmp_color = ChessEngine1.MyCell.black_color;
                }
                else
                {
                    tmp_color = ChessEngine1.MyCell.white_color;
                }

                rects_list.Add(new rect
                {
                    x = MyPoint.X + ChessEngine1.MyCell.width / 2,
                    y = MyPoint.Y + ChessEngine1.MyCell.height / 2,
                    width = ChessEngine1.MyCell.width,
                    height = ChessEngine1.MyCell.height,
                    fill = tmp_color,
                });

            }

           

        }

        public void Cmd_Render(int k, RenderTreeBuilder builder)
        {
  
            builder.OpenElement(k++, "g");
            builder.AddAttribute(k++, "style", "font-family:Georgia;font-size=14px");
            builder.AddAttribute(k++, "fill", "saddlebrown");

            foreach (var item in texts_list)
            {
                builder.OpenElement(k++, "text");
                builder.AddAttribute(k++, "x", item.x);
                builder.AddAttribute(k++, "y", item.y);
                if (!string.IsNullOrEmpty(item.text_anchor))
                {
                    builder.AddAttribute(k++, "text-anchor", item.text_anchor);
                }
                if (!string.IsNullOrEmpty(item.dominant_baseline))
                {
                    builder.AddAttribute(k++, "dominant-baseline", item.dominant_baseline);
                }
                builder.AddContent(k++, item.content);
                builder.CloseElement();
            }


            foreach (var item in rects_list)
            {
                builder.OpenElement(k++, "rect");
                builder.AddAttribute(k++, "x", item.x);
                builder.AddAttribute(k++, "y", item.y);
                builder.AddAttribute(k++, "width", item.width);
                builder.AddAttribute(k++, "height", item.height);
                if (!string.IsNullOrEmpty(item.fill))
                {
                    builder.AddAttribute(k++, "fill", item.fill);
                }
                if (!string.IsNullOrEmpty(item.stroke))
                {
                    builder.AddAttribute(k++, "stroke", item.stroke);
                }
                if (!double.IsNaN(item.stroke_width))
                {
                    builder.AddAttribute(k++, "stroke-width", item.stroke_width);
                }
              
                builder.CloseElement();
            }


            builder.CloseElement();

        }



       

        public void Dispose()
        {

        }
    }
}