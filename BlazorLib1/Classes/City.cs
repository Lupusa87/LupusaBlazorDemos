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
        [Parameter]
        public string BgCanvasID { get; set; }
        [Parameter]
        public string TopCanvasID { get; set; }

        [Parameter]
        public string DivClass { get; set; } = "position:relative; width:300px; height:300px;";



        [Parameter]
        public bool FastMode { get; set; } = false;


        [Parameter]
        public int TimerInterval { get; set; } = 100;


        [Parameter]
        public int FastMode_Increment { get; set; } = 1;


        public City()
        {
            Generate_Canvas_ID();

           
        }
        void Generate_Canvas_ID()
        {
            string a = Guid.NewGuid().ToString("d").Substring(1, 4);
            CanvasID = "myCanvas_" + a;

            if (!LocalData.Canvases_List.Any(x => x.Equals(CanvasID, StringComparison.InvariantCultureIgnoreCase)))
            {

                BgCanvasID = "myBgCanvas_" + a;
                TopCanvasID = "myTopCanvas_" + a;
                LocalData.Canvases_List.Add(CanvasID);
            }
            else
            {
                Generate_Canvas_ID();
            }
        }


    }
}
