using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class animateTransform
    {
        public string attributeName { get; set; } = "transform";
        public string attributeType { get; set; } = "xml";
        public string type { get; set; } = "rotate";
        public int by { get; set; } = 360;
        public int dur { get; set; }
        public string repeatCount { get; set; } = "indefinite";
    }
}
