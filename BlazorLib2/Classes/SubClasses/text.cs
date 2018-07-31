using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class text
    {
        public string id { get; set; } = null;
        public double x { get; set; } = double.NaN;
        public double y { get; set; } = double.NaN;

        public string fill { get; set; } = null;


        public double font_size { get; set; } = double.NaN;
        public string font_weight { get; set; } = null;

        public string text_anchor { get; set; } = null;
        public string dominant_baseline { get; set; } = null;
        public double opacity { get; set; } = double.NaN;


        public string transform_origin { get; set; } = null;
        public string transform { get; set; } = null;
        public ICollection<object> Children { get; set; } = new List<object>();


        //should be on last position because renderer addcontent should happend after attributes set - lupusa 7/26/2018
        public string content { get; set; } = null;
    }
}
