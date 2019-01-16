using BlazorWebWorkerHelper.classes;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Components
{
    public class CompWwMessage : BlazorComponent, IDisposable
    {

        [Parameter]
        protected BwwMessage bwwMessage { get; set; }


        [Parameter]
        protected BlazorComponent parent { get; set; }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {


            int k = -1;



            builder.OpenElement(k++, "div");
            builder.AddAttribute(k++, "id", "listitem" + bwwMessage.ID); // + Guid.NewGuid().ToString("d").Substring(1, 4));
            builder.AddAttribute(k++, "style", "width:800px;max-height:26px;position:relative;margin:5px");
            builder.OpenElement(k++, "span");





            if (bwwMessage.MessageType == BwwEnums.BwwMessageType.send)
            {
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;color:blue");
            }
            else
            {
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;color:green");
            }

            builder.AddContent(k++, bwwMessage.MessageType.ToString() + " " + bwwMessage.Message);

            builder.CloseElement();

            builder.CloseElement();


            base.BuildRenderTree(builder);
        }



        public void Dispose()
        {

        }
    }
}
