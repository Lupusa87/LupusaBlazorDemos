using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class rect:strokeBase
    {
        public double x { get; set; }
        public double y { get; set; }
        public double rx { get; set; }
        public double ry { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public string style { get; set; }
        public string fill { get; set; }
       
    }
}
