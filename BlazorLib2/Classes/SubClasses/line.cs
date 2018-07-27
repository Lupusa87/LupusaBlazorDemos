using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class line: strokeBase
    {
        public double x1 { get; set; }
        public double y1 { get; set; }
        public double x2 { get; set; }
        public double y2 { get; set; }
        public string style { get; set; }
        public string transform { get; set; }
        public double opacity { get; set; }
        public ICollection<object> Children { get; set; } = new List<object>();
    }
}
