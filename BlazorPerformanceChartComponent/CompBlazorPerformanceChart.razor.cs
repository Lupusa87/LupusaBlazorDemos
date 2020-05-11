using BlazorPerformanceChartComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace BlazorPerformanceChartComponent
{
    public partial class CompBlazorPerformanceChart: IDisposable
    {

        [Parameter]
        public BpcSettings ChartSettings { get; set; } = new BpcSettings();

        [Parameter]
        public List<MyChartPoint> PointsList
        {
            set
            {
                Points_List_Private = value;
                Normalize_PointsList();
            }
        }


        public Action OnRenderDone { get; set; }

        public CompRect CompRect1 = new CompRect();
        public CompPolygone CompPolygone1 = new CompPolygone();
        public CompPoints CompPoints1 = new CompPoints();
        public CompLines CompLines1 = new CompLines();
        public CompStack CompStack1 = new CompStack();
        public CompBorder CompBorder1 = new CompBorder();


        public string CompID = "BPC" + Guid.NewGuid().ToString("d").Substring(1, 4);

        

        public bool IsUserScrolling = false;



        public List<MyChartPoint> Points_List_Private = new List<MyChartPoint>();

        public bool Is_Percentage_Or_Min_Max_Mode = true;


        public void Dispose()
        {
        }


        public void InvokeOnRenderDone()
        {
           // OnRenderDone?.Invoke();
        }





        public void AdjustChartWidth()
        {
            if (Points_List_Private.Count * ChartSettings.StackWidth > ChartSettings.InitialWidth)
            {

                ChartSettings.ExtendedWidth = (Points_List_Private.Count + 1) * ChartSettings.StackWidth;
            }
            else
            {
                if (ChartSettings.ExtendedWidth > ChartSettings.InitialWidth)
                {
                    ChartSettings.ExtendedWidth = ChartSettings.InitialWidth;
                }
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            InvokeOnRenderDone();

            base.OnAfterRender(firstRender);
        }



        //public void OnScroll(UIEventArgs e)
        //{
        //    IsUserScrolling = true;

        //}

        public void Redraw()
        {
            //AdjustChartWidth();

            

            CompRect1.Refresh();
            CompPolygone1.Refresh();
            CompStack1.Refresh();
            CompLines1.Refresh();
            CompPoints1.Refresh();
            CompBorder1.Refresh();

            //StateHasChanged();

            //BpcJsInterop.ScrollRight("MainDiv", ChartSettings.ExtendedWidth);
        }

       



        //    public void Paint(double Par_Height,
        //                  double Par_Width,
        //                  Brush Par_Stack_Color,
        //                  Brush Par_Line_Color,
        //                  Brush Par_Area_Color, bool Par_Is_Percentage_Or_Min_Max_Mode)
        //{

        //    Is_Percentage_Or_Min_Max_Mode = Par_Is_Percentage_Or_Min_Max_Mode;

        //    Stack_Height = Par_Height / 5;
        //    Stack_Width = MyGlobalVariables.StackWidth;

        //    Initial_Height = Par_Height;
        //    Initial_Width = Par_Width;

        //    LayoutRoot.Height = Initial_Height;
        //    LayoutRoot.Width = Initial_Width;

        //    Path_1.Stroke = Par_Stack_Color;

        //    Path_2.Fill = Par_Area_Color;
        //    Path_2.Stroke = Par_Line_Color;

        //    Paint_Stack();


        //}



        public void Normalize_PointsList()
        {

            if (Points_List_Private.Count > 100)
            {

                for (int i = 100; i < Points_List_Private.Count; i++)
                {
                    Points_List_Private.RemoveAt(i-100);
                }

                
            }


            int k = (int)(ChartSettings.InitialWidth / ChartSettings.StackWidth);
            int m = Points_List_Private.Count;


            foreach (var item in Points_List_Private)
            {
                item.IsShown = true;
            }

            foreach (var item in Points_List_Private.Take(m - k))
            {
                item.IsShown = false;
            }


            //if (ReDraw && ContextMenu1.IsOpen == false && Is_User_Scrolling == false)
            //if (ReDraw && IsUserScrolling == false)
            //{
                Redraw();
            //}
            
        }






        //private void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{

        //    Point p = e.GetPosition(this);




        //    int _index = (int)((p.X + ScrollViewer_1.HorizontalOffset - 2) / MyGlobalVariables.StackWidth);

        //    if (Points_List_Private.Count > _index)
        //    {
        //        MenuItem_Number.Header = "ელემენტი - N" + (_index + 1);
        //        if (Points_List_Private[_index].Value > -1)
        //        {

        //            MenuItem_Percentage.Header = "მნიშვნელობა - " + Math.Round(Points_List_Private[_index].Value, 2).ToString() + " (" + (Math.Round(Points_List_Private[_index].Percentage, 2)).ToString() + "%)";
        //        }
        //        else
        //        {
        //            MenuItem_Percentage.Header = "მნიშვნელობა - " + Math.Round(Points_List_Private[_index].Percentage, 2).ToString() + "%";
        //        }
        //        MenuItem_Time.Header = "დრო - " + Points_List_Private[_index].Time.ToString();
        //        MenuItem_Count.Header = "რ-ბა - " + Points_List_Private.Count;

        //        if (Points_List_Private[_index].Value > -1)
        //        {

        //            MenuItem_Percentage.Header = "მნიშვნელობა - " + Math.Round(Points_List_Private[_index].Value, 2).ToString() + " (" + Math.Round(Points_List_Private[_index].Percentage, 2).ToString() + "%)";
        //            MenuItem_MAX.Header = "Max - " + Math.Round(Points_List_Private.Max(x => x.Value), 2) + " (" + Math.Round(Points_List_Private.Max(x => x.Percentage), 2) + "%)";
        //            MenuItem_MIN.Header = "Min - " + Math.Round(Points_List_Private.Min(x => x.Value), 2) + " (" + Math.Round(Points_List_Private.Min(x => x.Percentage), 2) + "%)";
        //            MenuItem_AVG.Header = "Avg - " + Math.Round(Points_List_Private.Average(x => x.Value), 2) + " (" + Math.Round(Points_List_Private.Average(x => x.Percentage), 2) + "%)";
        //        }
        //        else
        //        {
        //            MenuItem_MAX.Header = "Max - " + Math.Round(Points_List_Private.Max(x => x.Percentage), 2) + "%";
        //            MenuItem_MIN.Header = "Min - " + Math.Round(Points_List_Private.Min(x => x.Percentage), 2) + "%";
        //            MenuItem_AVG.Header = "Avg - " + Math.Round(Points_List_Private.Average(x => x.Percentage), 2) + "%";
        //        }
        //    }
        //    else
        //    {
        //        MenuItem_Number.Header = "ელემენტი - N";
        //        MenuItem_Percentage.Header = "მნიშვნელობა - ";
        //        MenuItem_Time.Header = "დრო - ";
        //        MenuItem_Count.Header = "რ-ბა - ";
        //        MenuItem_MAX.Header = "Max - ";
        //        MenuItem_MIN.Header = "Mim - ";
        //        MenuItem_AVG.Header = "Avg - ";
        //    }


        //    TimeSpan ts = TimeSpan.FromSeconds(Points_List_Private.Count);

        //    MenuItem_TimeAll.Header = "სიგრძე - " + ts.ToString(@"hh\:mm\:ss");

        //    MenuItem_DisplayedSeconds.Header = "ნაჩვენებია - " + Math.Round(this.Width / MyGlobalVariables.StackWidth, 0).ToString() + " წამი";

        //    CheckBox_DrawStack.IsChecked = MyGlobalVariables.My_Chart_DrawStack;


        //    RadioButton_1.IsChecked = Is_Percentage_Or_Min_Max_Mode;
        //    RadioButton_2.IsChecked = !Is_Percentage_Or_Min_Max_Mode;

        //    ContextMenu1.IsOpen = true;

        //    ContextMenuItem_Slider.Value = MyGlobalVariables.StackWidth;

        //    e.Handled = true;
        //}



        //private void LayoutRoot_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    e.Handled = true;
        //}



        //private void ScrollViewer_1_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Is_User_Scrolling = true;
        //}

        //private void ScrollViewer_1_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    Is_User_Scrolling = false;
        //}

        //private void ContextMenuItem_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    MenuItem_SliderValue.Header = "დიაპაზონი - " + Math.Round(ContextMenuItem_Slider.Value, 0).ToString() + " px";
        //    MenuItem_DisplayedSeconds.Header = "ნაჩვენებია - " + Math.Round(this.Width / MyGlobalVariables.StackWidth, 0).ToString() + " წამი";
        //    if (MyGlobalVariables.StackWidth != Math.Round(ContextMenuItem_Slider.Value, 0))
        //    {
        //        MyGlobalVariables.StackWidth = Math.Round(ContextMenuItem_Slider.Value, 0);


        //        if (Points_List_Private.Count > 0)
        //        {
        //            Paint_Stack();
        //            Draw_Points();
        //        }
        //    }
        //}

        //private void CheckBox_DrawStack_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (MyGlobalVariables.My_Chart_DrawStack == false)
        //    {
        //        MyGlobalVariables.My_Chart_DrawStack = true;

        //        if (Points_List_Private.Count > 0)
        //        {
        //            Paint_Stack();
        //            Draw_Points();
        //        }
        //    }
        //}

        //private void CheckBox_DrawStack_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    if (MyGlobalVariables.My_Chart_DrawStack == true)
        //    {
        //        MyGlobalVariables.My_Chart_DrawStack = false;

        //        if (Points_List_Private.Count > 0)
        //        {
        //            Paint_Stack();
        //            Draw_Points();
        //        }
        //    }
        //}

        //private void RadioButton_1_Checked(object sender, RoutedEventArgs e)
        //{


        //    if (Is_Percentage_Or_Min_Max_Mode == false)
        //    {
        //        Is_Percentage_Or_Min_Max_Mode = true;

        //        if (Points_List_Private.Count > 0)
        //        {
        //            Paint_Stack();
        //            Draw_Points();
        //        }
        //    }
        //}

        //private void RadioButton_2_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (Is_Percentage_Or_Min_Max_Mode == true)
        //    {
        //        Is_Percentage_Or_Min_Max_Mode = false;

        //        if (Points_List_Private.Count > 0)
        //        {
        //            Paint_Stack();
        //            Draw_Points();
        //        }
        //    }

        //}
    }
}
