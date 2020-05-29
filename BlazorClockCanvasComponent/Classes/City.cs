using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorClockCanvasComponent.Classes
{
    public class City
    {

        public CompClockCanvas CompClockCanvas_related;

        public int ID { get; set; }

        public string Name { get; set; }

        public int WidthAndHeight { get; set; } = 400;

        public int TimeDiff { get; set; }

        public string CanvasID { get; set; }

        public string BgCanvasID { get; set; }

        public string TopCanvasID { get; set; }

        public string DivClass { get; set; } = "position:relative; width:300px; height:300px;";


        public bool FastMode { get; set; } = false;

        public int TimerInterval { get; set; } = 100;

        public int FastMode_Increment { get; set; } = 1;


        public City()
        {
            Generate_Canvas_ID();

           
        }
        void Generate_Canvas_ID()
        {
            string a = Guid.NewGuid().ToString("d").Substring(1, 4);
            CanvasID = "myCanvas_" + a;

            if (!BCCCLocalData.Canvases_List.Any(x => x.Equals(CanvasID, StringComparison.InvariantCultureIgnoreCase)))
            {

                BgCanvasID = "myBgCanvas_" + a;
                TopCanvasID = "myTopCanvas_" + a;
                BCCCLocalData.Canvases_List.Add(CanvasID);
            }
            else
            {
                Generate_Canvas_ID();
            }
        }


    }
}
