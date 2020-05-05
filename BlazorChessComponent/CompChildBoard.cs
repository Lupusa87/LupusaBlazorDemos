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
    public class CompChildBoard : ComponentBase
    {
        bool IsCompLoaded = false;

        [Parameter]
        public ChessEngine ChessEngine1 { get; set; }


        List<image> images_list = new List<image>();


        protected override void OnInitialized()
        {

            if (IsCompLoaded == false)
            {
                if (ChessEngine1.compSettings.Curr_Comp_Board is null)
                {
                    ChessEngine1.compSettings.Curr_Comp_Board = this;
                }
                IsCompLoaded = true;
            }

            base.OnInitialized();
        }






        public void Refresh()
        {
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            
            images_list = new List<image>();
           
            paint_Board();

            Cmd_Render(0, builder);

            images_list = new List<image>();
            

            base.BuildRenderTree(builder);

           
        }


        void paint_Board()
        {
            myPoint MyPoint = new myPoint();

            int row_index = 0;
            int column_index = 0;
            string Image_Name = string.Empty;

            string tmp_color = string.Empty;

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


                string element = ChessEngine1.Board_Array[index];



                if (element != "e")
                {


                    if (MyFunctions.is_lower_case(element))
                    {
                        Image_Name = "2" + element.ToUpper();
                    }
                    else
                    {
                        Image_Name = "1" + element.ToUpper();
                    }


                    images_list.Add(new image
                    {
                        x = MyPoint.X + ChessEngine1.MyCell.width / 2 + ChessEngine1.MyCell.width * 0.1, //(1-0.8 qvemot rac iqneba /2 radgan unda gasashualovdes)
                        y = MyPoint.Y + ChessEngine1.MyCell.height / 2 + ChessEngine1.MyCell.height * 0.1,
                        width = ChessEngine1.MyCell.width * 0.8,
                        height = ChessEngine1.MyCell.height * 0.8,
                        href = "content/images/style3/" + Image_Name + ".png",
                        onclick = "notempty",
                    });

                    
                }

            }


            ChessEngine1.acxadebs_shaxs_an_gardes(ChessEngine1.PlayerColor);
            ChessEngine1.acxadebs_shaxs_an_gardes(ChessEngine1.OppositeColor);




        }


        public void Cmd_Render(int k, RenderTreeBuilder builder)
        {

            builder.OpenElement(k++, "g");


            if (!ChessEngine1.ar_avantot_ujrebi)
            {
                foreach (var item in ChessEngine1.compSettings.rects_list)
                {
                    builder.OpenElement(k++, "rect");
                    builder.AddAttribute(k++, "x", item.x);
                    builder.AddAttribute(k++, "y", item.y);
                    builder.AddAttribute(k++, "width", item.width);
                    builder.AddAttribute(k++, "height", item.height);
                    //if (!string.IsNullOrEmpty(item.fill))
                    //{
                    builder.AddAttribute(k++, "fill", item.fill);
                    //}
                    //if (!string.IsNullOrEmpty(item.stroke))
                    //{
                    builder.AddAttribute(k++, "stroke", item.stroke);
                    //}
                    //if (!double.IsNaN(item.stroke_width))
                    //{
                    builder.AddAttribute(k++, "stroke-width", item.stroke_width);
                    //}

                   

                    builder.CloseElement();
                }
            }


            foreach (var item in images_list)
            {
                builder.OpenElement(k++, "image");
                builder.AddAttribute(k++, "x", item.x);
                builder.AddAttribute(k++, "y", item.y);
                builder.AddAttribute(k++, "width", item.width);
                builder.AddAttribute(k++, "height", item.height);
                builder.AddAttribute(k++, "href", item.href);

                builder.CloseElement();
            }

            builder.CloseElement();

        }


       



        public void Dispose()
        {

        }
    }
}