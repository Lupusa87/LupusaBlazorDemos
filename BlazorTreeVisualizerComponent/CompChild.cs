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
        [Parameter]
        public CompTreeView parent { get; set; }

        [Parameter]
        public string CompID { get; set; }

        [Parameter]
        public int ParID { get; set; } = 0;

        private SvgHelper SvgHelper1 = new SvgHelper();


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                SvgHelper1.ActionClicked = CmdIconClick;
            }
            base.OnAfterRender(firstRender);
        }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int k = 0;

            TreeItem item =parent.SourceList.Single(x => x.ID == ParID);

            builder.OpenRegion(k++);
            builder.OpenElement(k++, "div");
            builder.AddAttribute(k++, "id", CompID);
            builder.AddAttribute(k++, "class", parent.CssClasses.Div);
            builder.OpenRegion(k++);
            SvgHelper1.Cmd_Render(LocalTreeFunctions.CmdCreateDynamicIcon(parent.SourceList,item),0, builder, item.ID);
            builder.CloseRegion();

 
            int marginLeft = parent.VisualParams.SmalestSizeUnit;
            if (item.HasIcon)
            {
                builder.OpenElement(k++, "img");
                builder.AddAttribute(k++, "src", item.IconSource);
                builder.AddAttribute(k++, "class", parent.CssClasses.Icon);
                builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create(this, e => CmdItemSelect(item.ID)));
                builder.CloseElement();

                marginLeft = parent.VisualParams.SmalestSizeUnit*5;
            }

            builder.OpenElement(k++, "span");


            builder.AddAttribute(k++, "class", CmdGetSpanClass(item));
            builder.AddAttribute(k++, "style", "margin-left:" + marginLeft + "px;");

            builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create(this, e => CmdItemSelect(item.ID)));

            builder.AddContent(k++, item.Text);

            builder.CloseElement();

            builder.CloseElement();

            builder.CloseRegion();

            base.BuildRenderTree(builder);
        }


        private async Task CmdItemSelect(int ParID)
        {
            await parent.ItemOnClick.InvokeAsync(ParID);

            parent.CurrentID = ParID;

            parent.SourceList.Where(x => x.IsSelected).ToList().ForEach(x => x.IsSelected = false);


            parent.SourceList.Single(x => x.ID == ParID).IsSelected = true;


            parent.Refresh();
        }


        public void CmdIconClick(MouseEventArgs a, int ParID)
        {
            svgclick(ParID);

            parent.Refresh();
        }


        public string CmdGetSpanClass(TreeItem item)
        {
            string result = parent.CssClasses.Span;

            if (item.IsSelected)
            {
                result += " " + parent.CssClasses.SpanSelected;
            }

            if (item.HasChildren)
            {
                result += " " + parent.CssClasses.SpanWithChildren;
            }

            return result;
        }



        private void svgclick(int ParID)
        {
            TreeItem CurrItem = parent.SourceList.Single(x => x.ID == ParID);
            if (CurrItem.HasChildren)
            {

                CurrItem.IsExpanded = !CurrItem.IsExpanded;

               LocalTreeFunctions.CmdChangeVisibility(parent.SourceList, CurrItem.ID, CurrItem.IsExpanded, true);


            }
        }


        public void Dispose()
        {
           
        }
    }
}
