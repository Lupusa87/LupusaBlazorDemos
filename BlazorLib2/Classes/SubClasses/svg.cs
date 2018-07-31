using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class svg
    {
        public string id { get; set; } = null;
        public double width { get; set; } = double.NaN;
        public double height { get; set; } = double.NaN;
        public string xmlns { get; set; } = null;
        public ICollection<object> Children { get; set; } = new List<object>(); 
    }
}
