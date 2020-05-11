using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPerformanceChartComponent.classes
{
    public class MyPoint
    {
        public double X { get; set; }
        public double Y { get; set; }


        public MyPoint(double P_X, double P_Y)
        {
            X = P_X;
            Y = P_Y;
        }

    }
}
