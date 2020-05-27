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
        public string CompID { get; set; }

        [Parameter]
        public int ParID { get; set; } = 0;

        private SvgHelper SvgHelper1 = new SvgHelper();

        protected override void OnAfterRender(bool firstRender)
        {
            SvgHelper1.ActionSelected = CmdIconClick;
            base.OnAfterRender(firstRender);
        }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int k = -1;

            TreeItem item = LocalData.dynamicList.Single(x => x.ID == ParID);

            builder.OpenElement(k++, "div");
            builder.AddAttribute(k++, "id", CompID);
            builder.AddAttribute(k++, "style", "width:400px;max-height:26px;position:relative;");

            SvgHelper1.Cmd_Render(LocalTreeFunctions.CmdCreateDynamicIcon(item), k, builder, item.ID);


            //      < img width = "24" height = "24" title = "Ready State" style = "margin:3px;" src = "icons/Connected.png" />


            int marginLeft = 0;
            if (item.HasIcon)
            {
                builder.OpenElement(k++, "img");
                builder.AddAttribute(k++, "width", "20");
                builder.AddAttribute(k++, "height", "20");
                builder.AddAttribute(k++, "src", item.IconSource);
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;margin:0px;");
                builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create(this, e => CmdItemSelect(item.ID)));
                builder.CloseElement();

                marginLeft = 25;
            }

            builder.OpenElement(k++, "span");


            //Console.WriteLine("abc " + item.Column + " " + DateTime.Now.ToString("mm:ss.fff"));

            if (item.IsSelected)
            {
                //Console.WriteLine("abc is selected");
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;margin-left:" + marginLeft + "px;background-color:yellow;color:blue;border-style:solid;border-width:1px;border-color:red;");
            }
            else
            {
                //Console.WriteLine("abc is not selected");
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;margin-left:"+marginLeft+"px;cursor:pointer;");
            }


            builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create(this, e => CmdItemSelect(item.ID)));

            builder.AddContent(k++, item.Column);

            builder.CloseElement();

            builder.CloseElement();


            base.BuildRenderTree(builder);
        }

        private void CmdItemSelect(int ParID)
        {


            LocalData.CurrentID = ParID;

            LocalData.dynamicList.Where(x => x.IsSelected).ToList().ForEach(x => x.IsSelected = false);


            LocalData.dynamicList.Single(x => x.ID == ParID).IsSelected = true;


            LocalData.compBlazorTreeVisualizer.update();
        }


        public void CmdIconClick(int ParID)
        {
            svgclick(ParID);

            LocalData.compBlazorTreeVisualizer.update();
        }



        private void svgclick(int ParID)
        {
            TreeItem CurrItem = LocalData.dynamicList.Single(x => x.ID == ParID);
            if (CurrItem.HasChildren)
            {

                CurrItem.IsExpanded = !CurrItem.IsExpanded;

               LocalTreeFunctions.CmdChangeVisibility(CurrItem.ID, CurrItem.IsExpanded, true);


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
