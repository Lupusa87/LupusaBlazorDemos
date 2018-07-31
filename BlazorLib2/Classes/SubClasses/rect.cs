using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class rect:strokeBase
    {
        public double x { get; set; } = double.NaN;
        public double y { get; set; } = double.NaN;
        public double rx { get; set; } = double.NaN;
        public double ry { get; set; } = double.NaN;
        public double width { get; set; } = double.NaN;
        public double height { get; set; } = double.NaN;
        public string style { get; set; } = null;
        public string fill { get; set; } = null;

    }
}
