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
        internal static int CurrentID = 0;

        internal static CompBlazorTreeVisualizer compBlazorTreeVisualizer = null;

        internal static Color MyColorPickerColor = Color.White;


        internal static List<TreeItem> dynamicList = new List<TreeItem>();
        //internal static List<CompChild> ComponentsList = new List<CompChild>();

        internal static List<string> ColumnHeadersList = new List<string>();
        internal static List<string> ColumnsList = new List<string>();




        internal static bool SetBoldToParents = true;

        internal static int LevelsCount = 0;
        internal static int MaxLevel = 0;
        internal static int MinLevel = 0;
        internal static int IconWithAndHeigth = 26;


        internal static bool ShowAllRows = false;
        internal static bool FillFullList = true;

        internal static bool IsLineDashed = false;
        internal static double DashArrayValue = 4;
        internal static Color LineColor = Color.Red;
        internal static Color MinusOrPlusColor = Color.Blue;
        internal static Color MinusOrPlusBorderColor = Color.Black;

        internal static bool UseGradinet = true;

        internal static Color GradinetColor1 = Color.White;
        internal static Color GradinetColor2 = Color.LightGreen;
        internal static Color GradinetColor3 = Color.Green;


        internal static double LineStrokeThickness = 1;
        internal static double MinusOrPlusStrokeThickness = 3;
        internal static double MinusOrPlusBorderStrokeThickness = 2;

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

        // internal static LinearGradientBrush LinearGradientBrush = null;
    }
    
}
