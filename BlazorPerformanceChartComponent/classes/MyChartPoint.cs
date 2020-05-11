using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPerformanceChartComponent.classes
{
    public class MyChartPoint
    {
        public double Percentage { get; set; }
        public double Value { get; set; }
        public bool IsProcessRunning { get; set; }
        public string Time { get; set; }
        public bool IsShown { get; set; }
    }
}
