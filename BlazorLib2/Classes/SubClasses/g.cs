using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class g:strokeBase
    {

        public int font_size { get; set; }
        public string font_family { get; set; }
        public string text_anchor { get; set; }
        
        public string fill { get; set; }

        public ICollection<object> Children { get; set; } = new List<object>();
    }
}
