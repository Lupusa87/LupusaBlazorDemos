using BlazorPaintComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent
{
    public class CompListItem : ComponentBase, IDisposable
    {

        [Parameter]
        public int Par_ID { get; set; } = 0;


        [Parameter]
        public ComponentBase parent { get; set; }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            BPaintObject  curr_object = (parent as CompBlazorPaint).ObjectsList.Single(x=>x.ObjectID==Par_ID);

            int k = -1;

           

            builder.OpenElement(k++, "div");
            builder.AddAttribute(k++, "id", "listitem" + Par_ID); // + Guid.NewGuid().ToString("d").Substring(1, 4));
            builder.AddAttribute(k++, "style", "width:400px;max-height:26px;position:relative;margin:5px");
            builder.OpenElement(k++, "span");

            if (curr_object.Selected)
            {
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;background-color:yellow;color:blue;border-style:solid;border-width:1px;border-color:red;");
            }
            else
            {
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;");
            }

            builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create(this, e => Cmd_Item_Select(curr_object.ObjectID)));

            builder.AddContent(k++, curr_object.ObjectID + "_" + curr_object.ObjectType.ToString());

            builder.CloseElement();

            builder.CloseElement();
        

            base.BuildRenderTree(builder);
        }

        private void Cmd_Item_Select(int Par_ID)
        {
            CompBlazorPaint p = parent as CompBlazorPaint;


            if (!p.MultiSelect)
            {
                p.cmd_Clear_Selection();
            }

            p.cmd_Clear_Editing();

            p.ObjectsList.Single(x => x.ObjectID == Par_ID).Selected = true;

            p.cmd_RefreshSVG();
            p.Curr_Mode = BPaintMode.edit;


        }

        public void Dispose()
        {

        }
    }
}
