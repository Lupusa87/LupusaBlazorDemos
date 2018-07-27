using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class text
    {
        public double x { get; set; }
        public double y { get; set; }
        //public int dx { get; set; }
        //public int dy { get; set; }
        public string fill { get; set; }
        

        public double font_size { get; set; }
        public string font_weight { get; set; }

        public string text_anchor { get; set; }
        public string dominant_baseline { get; set; }
        public double opacity { get; set; }

        public string transform { get; set; }

        //should be on last position because renderer addcontent should happend after attributes set - lupusa 7/26/2018
        public string content { get; set; }
    }
}
