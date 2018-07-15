using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;


namespace BlazorLib1.Classes
{
    public class City
    {
        public Component1 component1_related;
        [Parameter]
        public int ID { get; set; }
        [Parameter]
        public string Name { get; set; }
        [Parameter]
        public int WidthAndHeight { get; set; } = 400;
        [Parameter]
        public int TimeDiff { get; set; }
        [Parameter]
        public string CanvasID { get; set; }


        public City()
        {
            Generate_Canvas_ID();
        }
        void Generate_Canvas_ID()
        {

            CanvasID = "myCanvas_" + Guid.NewGuid().ToString("d").Substring(1, 4);

            if (!LocalData.Canvases_List.Any(x => x.Equals(CanvasID, StringComparison.InvariantCultureIgnoreCase)))
            {
                LocalData.Canvases_List.Add(CanvasID);
            }
            else
            {
                Generate_Canvas_ID();
            }
        }


    }
}
