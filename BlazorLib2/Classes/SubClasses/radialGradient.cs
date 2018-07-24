using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class radialGradient
    {
        public string id { get; set; }
        public string cx { get; set; }
        public string cy { get; set; }
        public string r { get; set; }
        public string fx { get; set; }
        public string fy { get; set; }
        public string fr { get; set; }

        public ICollection<object> Children { get; set; } = new List<object>();
    }
}
