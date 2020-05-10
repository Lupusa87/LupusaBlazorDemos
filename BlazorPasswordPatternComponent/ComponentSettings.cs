using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPasswordPatternComponent
{
    public class ComponentSettings
    {
        public static int width { get; set; }
        public static int heigh { get; set; }


        public static double w { get; set; }
        public static double h { get; set; }
        public static double r { get; set; }


        public static double compWidth { get; set; }
        public static double compHeight { get; set; }

        public static int CountHorizontal { get; set; } = 3; //max 9
        public static int CountVertical { get; set; } = 3; //max 9

  

        public static string BG_Color { get; set; } = "#7FB0D3";

        public static string SelectCircle_Color { get; set; } = "#5AE619";

        public static string BigCircle_Color { get; set; } = "#2C2E23";
        public static string SmallCircle_Color { get; set; } = "#DEEAD8";


        public static List<string> SelectedCircles_List = new List<string>();

       

    }
}
