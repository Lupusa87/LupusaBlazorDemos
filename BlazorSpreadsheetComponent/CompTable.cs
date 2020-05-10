using BlazorSpreadsheetComponent.BussinesLayer;
using BlazorSpreadsheetComponent.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSpreadsheetComponent
{
    public class CompTable:ComponentBase,IDisposable
    {
        [Parameter]
        public ComponentBase parent { get; set; }


        protected void Cmd_RenderTable(RenderTreeBuilder builder)
        {
            List<BCell> table_list = (parent as CompBlazorSpreadsheet).Current_BTable.Table_List;


            int MaxCol = table_list.Max(x => x.Column);
            int MaxRow = table_list.Max(x => x.Row);


            int k = -1;
            builder.OpenElement(k++, "table");

            builder.OpenElement(k++, "thead");
            builder.OpenElement(k++, "tr");

            builder.OpenElement(k++, "th");

            builder.AddAttribute(k++, "style", "width:20px;height:35px;margin:1px;padding:2px");
            builder.AddContent(k++, "");

            builder.CloseElement(); //th

            for (int i = 0; i <= MaxCol; i++)
            {
                builder.OpenElement(k++, "th");

                builder.AddAttribute(k++, "style", "text-align:center;height:35px;margin:1px;padding:2px");

                builder.AddContent(k++, MyFunctions.GetLetter(i));

                builder.CloseElement(); //th
            }

            builder.CloseElement(); //tr
            builder.CloseElement(); //thead

            builder.OpenElement(k++, "tbody");

            for (int i = 0; i <= MaxRow; i++)
            {

                builder.OpenElement(k++, "tr");



                builder.OpenElement(k++, "td");


                builder.AddAttribute(k++, "style", "text-align:right;width:20px;height:35px;padding:2px;");
                builder.AddContent(k++, i + 1);

                builder.CloseElement();

                for (int j = 0; j <= MaxCol; j++)
                {

                    BCell b = table_list.Single(x => x.Row == i && x.Column == j);


                    builder.OpenComponent<CompCell>(k++);
                    builder.AddAttribute(k++, "bcell", b);
                    builder.AddAttribute(k++, "parent", this);
                    builder.CloseComponent();

                }


                builder.CloseElement(); //tr

            }


            builder.CloseElement(); //tbody

            builder.CloseElement(); //table  

        }



        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {


            Cmd_RenderTable(builder);


            base.BuildRenderTree(builder);
        }

        public void Dispose()
        {

        }
    }
}
