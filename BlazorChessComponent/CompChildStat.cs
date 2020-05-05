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
    public class CompChildStat : ComponentBase
    {

        [Parameter]
        public ChessEngine ChessEngine1 { get; set; }

        bool IsCompLoaded = false;

        List<text> texts_list = new List<text>();


        protected override void OnInitialized()
        {
            if (IsCompLoaded == false)
            {
                if (ChessEngine1.compSettings.Curr_Comp_Stat is null)
                {
                    ChessEngine1.compSettings.Curr_Comp_Stat = this;
                }
                IsCompLoaded = true;
            }

            base.OnInitialized();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {


            texts_list = new List<text>();
           
            paint_stat();

            Cmd_Render(0, builder);
            texts_list = new List<text>();
          

            base.BuildRenderTree(builder);


        }

        public void Refresh()
        {
            StateHasChanged();
        }

        public void paint_stat()
        {
            int PlayerScore = ChessEngine1.GetPlayerScore();
            int OppositeScore = ChessEngine1.GetOppositeScore();

            if (PlayerScore > 0 || OppositeScore > 0)
            {
                int diff = Math.Abs(PlayerScore - OppositeScore);


                Add_Text("black"," " + PlayerScore, 8.6 * ChessEngine1.MyCell_Moklulebi.width, 0.9 * ChessEngine1.MyCell_Moklulebi.height);
                Add_Text("black", " " + OppositeScore, 8.6 * ChessEngine1.MyCell_Moklulebi.width, 2.9 * ChessEngine1.MyCell_Moklulebi.height);


                if (diff != 0)
                {
                    if (diff > 0)
                    {
                        Add_Text(ChessEngine1.MyColors.selected_cell, "-" + diff, 8.6 * ChessEngine1.MyCell_Moklulebi.width, 1.9 * ChessEngine1.MyCell_Moklulebi.height);
                        Add_Text(ChessEngine1.MyColors.selected_cell, "+" + diff, 8.6 * ChessEngine1.MyCell_Moklulebi.width, 3.9 * ChessEngine1.MyCell_Moklulebi.height);
                    }
                    else
                    {
                        Add_Text(ChessEngine1.MyColors.selected_cell, "+" + diff, 8.6 * ChessEngine1.MyCell_Moklulebi.width, 1.9 * ChessEngine1.MyCell_Moklulebi.height);
                        Add_Text(ChessEngine1.MyColors.selected_cell, "-" + diff, 8.6 * ChessEngine1.MyCell_Moklulebi.width, 3.9 * ChessEngine1.MyCell_Moklulebi.height);
                    }
                }
            }

        }


        void Add_Text(string _color, string _content, double _x, double _y)
        {
            texts_list.Add(new text()
            {
                x = _x,
                y = _y,
                fill = _color,
                content = _content,
                dominant_baseline = "middle",
            });
        }

        public void Cmd_Render(int k, RenderTreeBuilder builder)
        {

            builder.OpenElement(k++, "g");
            builder.AddAttribute(k++, "style", "font-family:Georgia;font-size=22px");

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


           

            builder.CloseElement();


            builder.OpenElement(k++, "g");
            foreach (var item in ChessEngine1.compSettings.KilledFigures_list)
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