using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class svg
    {
        public int width { get; set; }
        public int height { get; set; }
        public string xmlns { get; set; }
        public ICollection<object> Children { get; set; } = new List<object>(); 
    }
}
