using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class animate
    {
        public string attributeName { get; set; }
        public string attributeType { get; set; } = "xml";
        public double from { get; set; }
        public double to { get; set; }
        public int dur { get; set; }
        public string repeatCount { get; set; } = "indefinite";
        public string fill { get; set; } = "freeze";
    }
}
