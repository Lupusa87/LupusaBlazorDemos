using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class image
    {
        public double x { get; set; } = double.NaN;
        public double y { get; set; } = double.NaN;
        public double width { get; set; } = double.NaN;
        public double height { get; set; } = double.NaN;
        public string href { get; set; } = null;
        public string transform { get; set; } = null;
        public double opacity { get; set; } = double.NaN;
        public ICollection<object> Children { get; set; } = new List<object>();
    }
}
