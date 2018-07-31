using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class g:strokeBase
    {

        public double font_size { get; set; } = double.NaN;
        public string font_family { get; set; } = null;
        public string text_anchor { get; set; } = null;

        public string fill { get; set; } = null;
        public string transform { get; set; } = null;
        public ICollection<object> Children { get; set; } = new List<object>();
    }
}
