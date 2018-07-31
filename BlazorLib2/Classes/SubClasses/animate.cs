using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class animate
    {
        public string id { get; set; } = null;
        public string attributeName { get; set; } = null;
        public string attributeType { get; set; } = null;
        public double from { get; set; } = double.NaN;
        public double to { get; set; } = double.NaN;
        public double dur { get; set; } = double.NaN;
        public string repeatCount { get; set; } = null;
        public string fill { get; set; } = null;
        public string values { get; set; } = null;
        public string keyTimes { get; set; } = null;
    }
}
