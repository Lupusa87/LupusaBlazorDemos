using BlazorSvgHelper;
using BlazorSvgHelper.Classes.SubClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPasswordPatternComponent
{
    public class ChildLine : ComponentBase
    {

        private SvgHelper SvgHelper1 = new SvgHelper();

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            

            g g1 = new g();

            int i1;
            int j1;

            int i2;
            int j2;

            for (int m = 0; m < ComponentSettings.SelectedCircles_List.Count -1; m++)
            {
                string item1 = ComponentSettings.SelectedCircles_List[m];
                string item2 = ComponentSettings.SelectedCircles_List[m+1];

                i1 = int.Parse(item1.Substring(0, 1));
                j1 = int.Parse(item1.Substring(1, 1));

                i2 = int.Parse(item2.Substring(0, 1));
                j2 = int.Parse(item2.Substring(1, 1));


                g1.Children.Add(new line
                {
                    id = "line" + item1 + item2,
                    x1 = i1 * ComponentSettings.w + ComponentSettings.w * 0.5,
                    y1 = j1 * ComponentSettings.h + ComponentSettings.h * 0.5,
                    x2 = i2 * ComponentSettings.w + ComponentSettings.w * 0.5,
                    y2 = j2 * ComponentSettings.h + ComponentSettings.h * 0.5,
                    stroke_width = ComponentSettings.compWidth * 0.05,
                    stroke = ComponentSettings.SmallCircle_Color,
                });
            }

            SvgHelper1.Cmd_Render(g1,0, builder);

            base.BuildRenderTree(builder);

        }

        public void Update()
        {

                StateHasChanged();
        }
  }
}
