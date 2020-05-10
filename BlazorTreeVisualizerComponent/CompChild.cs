using BlazorSvgHelper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorTreeVisualizerComponent
{
    public class CompChild : ComponentBase, IDisposable
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        [Parameter]
        public string Comp_ID { get; set; }

        [Parameter]
        public int Par_ID { get; set; } = 0;

        private SvgHelper SvgHelper1 = new SvgHelper();

        protected override void OnAfterRender(bool firstRender)
        {
            SvgHelper1.ActionSelected = Cmd_Tree_Icon_Click;
            base.OnAfterRender(firstRender);
        }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int k = -1;

            TreeItem item = LocalData.dynamic_List.Single(x => x.Tree_ID == Par_ID);

            builder.OpenElement(k++, "div");
            builder.AddAttribute(k++, "id", Comp_ID);
            builder.AddAttribute(k++, "style", "width:400px;max-height:26px;position:relative;");

            SvgHelper1.Cmd_Render(LocalTreeFunctions.Cmd_Create_Dynamic_Icon(item), k, builder, item.Tree_ID);

            builder.OpenElement(k++, "span");


            //Console.WriteLine("abc " + item.Tree_Column + " " + DateTime.Now.ToString("mm:ss.fff"));

            if (item.Tree_IsSelected)
            {
                //Console.WriteLine("abc is selected");
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;background-color:yellow;color:blue;border-style:solid;border-width:1px;border-color:red;");
            }
            else
            {
                //Console.WriteLine("abc is not selected");
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;");
            }


            builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create(this, e => Cmd_Tree_Item_Select(item.Tree_ID)));

            builder.AddContent(k++, item.Tree_Column);

            builder.CloseElement();

            builder.CloseElement();


            base.BuildRenderTree(builder);
        }

        private void Cmd_Tree_Item_Select(int Par_ID)
        {


            LocalData.Current_Tree_ID = Par_ID;

            LocalData.dynamic_List.Where(x => x.Tree_IsSelected).ToList().ForEach(x => x.Tree_IsSelected = false);


            LocalData.dynamic_List.Single(x => x.Tree_ID == Par_ID).Tree_IsSelected = true;


            LocalData.compBlazorTreeVisualizer.update();
        }


        public void Cmd_Tree_Icon_Click(int Par_ID)
        {
            svg_click(Par_ID);

            LocalData.compBlazorTreeVisualizer.update();
        }



        private void svg_click(int Par_ID)
        {
            TreeItem Curr_Item = LocalData.dynamic_List.Single(x => x.Tree_ID == Par_ID);
            if (Curr_Item.Tree_HasChildren)
            {

                Curr_Item.Tree_IsExpanded = !Curr_Item.Tree_IsExpanded;

               LocalTreeFunctions.Cmd_ChangeVisibility(Curr_Item.Tree_ID, Curr_Item.Tree_IsExpanded, true);


            }
        }


        public void ComponentClicked(MouseEventArgs e)
        {
            jsRuntime.InvokeVoidAsync("alert", e.ScreenX.ToString());
        }

        public void Dispose()
        {
           
        }
    }
}
