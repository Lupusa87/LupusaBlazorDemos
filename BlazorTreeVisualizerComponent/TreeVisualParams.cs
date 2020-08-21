using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTreeVisualizerComponent
{
    public class TreeVisualParams
    {
        public double TreeIconBoxSize { get; set; } = 50;

        public int SmalestSizeUnit { get; set; } = 1;


        public bool IsLineDashed { get; set; } = false;
        public double DashArrayValue { get; set; } = 1;
        public Color LineColor { get; set; } = Color.Red;
        public Color MinusOrPlusColor { get; set; } = Color.Blue;
        public Color MinusOrPlusBorderColor { get; set; } = Color.Black;


        public double LineStrokeThickness { get; set; } = 1;
        public double MinusOrPlusStrokeThickness { get; set; } = 2;
        public double MinusOrPlusBorderStrokeThickness { get; set; } = 2;
    }
}
