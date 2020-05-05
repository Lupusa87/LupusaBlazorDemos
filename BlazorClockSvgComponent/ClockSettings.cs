using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClockSvgComponent
{
    public static class ClockSettings
    {

        public static int width { get; set; }
        public static int heigh { get; set; }
        public static string Image_Url { get; set; } = "content/1.png";


        public static double radius_Origin { get; set; } = 0;
        public static double radius_2_Times { get; set; } = 0;
        public static double radius_90_Percent { get; set; } = 0;


        public static int currentCount { get; set; } = 0;

        public static string BG_Color { get; set; } = "wheat";
        public static string Clock_Border_Color { get; set; } = "Blue";
        public static string Clock_BG_Color { get; set; } = "wheat";
        public static string Clock_Center_Small_Point_Color { get; set; } = "DarkSlateBlue";

        public static string Clock_Second_Arrow_Color { get; set; } = "tomato"; // "DarkSlateBlue";

        public static string Clock_Numbers_Font { get; set; } = "10px arial";


        public static bool OnlyOneDraw { get; set; } = false;

        public static bool FastMode { get; set; } = true;
        public static int FastMode_Increment { get; set; } = 1;
        public static bool SecondOnlyOneStep { get; set; } = false;  // if it is true timeinterval should be 1000
        public static int timerInterval { get; set; } = 1000;


        public static double Hour_Hand_Lenght { get; set; } = 0.35;
        public static double Minute_Hand_Lenght { get; set; } = 0.55;
        public static double Second_Hand_Lenght { get; set; } = 0.64;


    }
}
