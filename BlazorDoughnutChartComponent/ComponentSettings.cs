using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDoughnutChartComponent
{
    public static class ComponentSettings
    {
        public static int width { get; set; }
        public static int heigh { get; set; }

        public static double radius_Origin { get; set; } = 0;
        public static double radius_2_Times { get; set; } = 0;
        public static double radius_BigCircle { get; set; } = 0;
        public static double radius_SmallCircle { get; set; } = 0;
        public static double CircleWidth { get; set; } = 0;


        public static string BG_Color { get; set; } = "wheat";


        public static string BigCircle_Color { get; set; } = "#FFA8A1A1";


        public static string Text_Color { get; set; } = "green";
    }
}
