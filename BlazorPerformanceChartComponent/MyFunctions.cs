using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPerformanceChartComponent
{
    public static class MyFunctions
    {
        public static double Calculate_Y_Coordinate(CompBlazorPerformanceChart _parent, double Par_Percentage)
        {
            double Tmp_Y_Coordinate = 0;

            if (_parent.Is_Percentage_Or_Min_Max_Mode)
            {
                Tmp_Y_Coordinate = _parent.ChartSettings.InitialHeight - (Par_Percentage * _parent.ChartSettings.InitialHeight / 100);
            }
            else
            {
                Tmp_Y_Coordinate = _parent.ChartSettings.InitialHeight - (Par_Percentage / _parent.Points_List_Private.Max(x => x.Percentage) * _parent.ChartSettings.InitialHeight);
            }

            return Tmp_Y_Coordinate;
        }
    }
}
