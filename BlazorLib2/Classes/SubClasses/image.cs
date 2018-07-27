using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class image
    {
        public double x { get; set; }
        public double y { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public string href { get; set; }
        public string transform { get; set; }
        public double opacity { get; set; }
        public ICollection<object> Children { get; set; } = new List<object>();
    }
}
