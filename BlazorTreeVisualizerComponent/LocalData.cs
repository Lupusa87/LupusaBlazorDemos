using BlazorSvgHelper.Classes.SubClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTreeVisualizerComponent
{

    internal static class LocalData
    {

        internal static TreeVisualParams VisualParams { get; set; } = new TreeVisualParams();




        internal static double TreeIconBoxSize25 { get; set; }

        internal static double TreeIconBoxSize37 { get; set; }

        internal static double TreeIconBoxSize50 { get; set; }

        internal static double TreeIconBoxSize62 { get; set; }

        internal static double TreeIconBoxSize75 { get; set; }

        internal static int LevelsCount = 0;
        internal static int MaxLevel = 0;
        internal static int MinLevel = 0;

        internal static g IconMinus = null;
        internal static g IconMinusTop = null;
        internal static g IconMinusBottom = null;
        internal static g IconMinusTopBottom = null;

        internal static g IconPlus = null;
        internal static g IconPlusTop = null;
        internal static g IconPlusBottom = null;
        internal static g IconPlusTopBottom = null;

        internal static g IconItem = null;

        internal static g IconLine = null;
        internal static g IconLastItem = null;

    }
    
}
