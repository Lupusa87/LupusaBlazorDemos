using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib1
{
    public static class Clock
    {

        #region Properties
        public static string BG_Color { get; set; } = "wheat";
        public static string Clock_Border_Color { get; set; } = "Blue";
        public static string Clock_BG_Color { get; set; } = "wheat";
        public static string Clock_Center_Small_Point_Color { get; set; } = "DarkSlateBlue";

        public static string Clock_Second_Arrow_Color { get; set; } = "tomato"; // "DarkSlateBlue";

        public static string Clock_Numbers_Font { get; set; } = "10px arial";
        public static BlazorLib1.TextBaseline Clock_Numbers_TextBaseline { get; set; } = BlazorLib1.TextBaseline.Middle;
        public static BlazorLib1.TextAlign Clock_Numbers_TextAlign { get; set; } = BlazorLib1.TextAlign.Center;
        #endregion

    }
}
