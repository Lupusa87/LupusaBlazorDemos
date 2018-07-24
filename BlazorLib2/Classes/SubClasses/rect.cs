using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class rect:strokeBase
    {
        public int x { get; set; }
        public int y { get; set; }
        public int rx { get; set; }
        public int ry { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string style { get; set; }
        public string fill { get; set; }
       
    }
}
