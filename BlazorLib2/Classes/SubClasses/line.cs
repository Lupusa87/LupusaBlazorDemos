using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class line: strokeBase
    {
        public double x1 { get; set; } = double.NaN;
        public double y1 { get; set; } = double.NaN;
        public double x2 { get; set; } = double.NaN;
        public double y2 { get; set; } = double.NaN;
        public string style { get; set; } = null;
        public string transform { get; set; } = null;
        public double opacity { get; set; } = double.NaN;
        public ICollection<object> Children { get; set; } = new List<object>();
    }
}
