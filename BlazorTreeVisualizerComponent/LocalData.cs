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
        internal static int Current_Tree_ID = 0;

        internal static CompBlazorTreeVisualizer compBlazorTreeVisualizer = null;

        internal static Color MyColorPicker_Color = Color.White;


        internal static List<TreeItem> dynamic_List = new List<TreeItem>();
        //internal static List<CompChild> Components_List = new List<CompChild>();

        internal static List<string> Column_Headers_List = new List<string>();
        internal static List<string> Columns_List = new List<string>();




        internal static bool My_Set_Bold_To_Parents = true;

        internal static int My_Levels_Count = 0;
        internal static int My_MaxLevel = 0;
        internal static int My_MinLevel = 0;
        internal static int My_Tree_Icon_With_And_Heigth = 26;


        internal static bool My_Show_All_Rows = false;
        internal static bool Fill_Full_List = true;

        internal static bool My_IsLineDashed = false;
        internal static double My_DashArray_Value = 4;
        internal static Color MyTree_Line_Color = Color.Red;
        internal static Color MyTree_MinusOrPlus_Color = Color.Blue;
        internal static Color MyTree_MinusOrPlus_Border_Color = Color.Black;

        internal static bool MyTree_Use_Gradinet = true;

        internal static Color MyTree_Gradinet_Color_1 = Color.White;
        internal static Color MyTree_Gradinet_Color_2 = Color.LightGreen;
        internal static Color MyTree_Gradinet_Color_3 = Color.Green;


        internal static double MyTree_Line_StrokeThickness = 1;
        internal static double MyTree_MinusOrPlus_StrokeThickness = 3;
        internal static double MyTree_MinusOrPlus_Border_StrokeThickness = 2;

        internal static g Tree_Icon_Minus = null;
        internal static g Tree_Icon_Minus_Top = null;
        internal static g Tree_Icon_Minus_Bottom = null;
        internal static g Tree_Icon_Minus_Top_Bottom = null;

        internal static g Tree_Icon_Plus = null;
        internal static g Tree_Icon_Plus_Top = null;
        internal static g Tree_Icon_Plus_Bottom = null;
        internal static g Tree_Icon_Plus_Top_Bottom = null;

        internal static g Tree_Icon_Item = null;
        internal static g Tree_Icon_Line = null;
        internal static g Tree_Icon_LastItem = null;

        // internal static LinearGradientBrush My_LinearGradientBrush = null;
    }
    
}
