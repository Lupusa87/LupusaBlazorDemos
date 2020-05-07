using BlazorSvgHelper;
using BlazorSvgHelper.Classes.SubClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent
{
    public partial class CompUsedColors: IDisposable
    {
        public List<string> UsedColors_List = new List<string>()
        { "#008000", "#FFFFFF","#FF0000", "#0000FF", "#FFFF00", "#808080", "#C0C0C0","#A52A2A", "#FFD700", "#000000"};
        
        public List<CompChildUsedColor> Curr_CompChildUsedColor_List = new List<CompChildUsedColor>();

        public Action<string> ActionColorClicked { get; set; }


        //protected override void OnInitialized()
        //{
            //for (int i = 0; i < UsedColors_List.Count; i++)
            //{
            //    UsedColors_List[i] = Get_Hex_Code_From_Color_Name(UsedColors_List[i]);
            //}

        //    base.OnInitialzied();
        //}


        private string Get_Hex_Code_From_Color_Name(string name)
        {
           
            Color c = Color.FromName(name);

            return string.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B); ;

        }



        public void ColorSelected(string a)
        {

            ActionColorClicked?.Invoke(a);
        }


        public void Refresh()
        {
            StateHasChanged();
        }


        public void Dispose()
        {

        }
    }
}
