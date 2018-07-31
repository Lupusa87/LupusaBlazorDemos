using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class circle :strokeBase
    {

        public double cx { get; set; } = double.NaN;
        public double cy { get; set; } = double.NaN;
        public double r { get; set; } = double.NaN;
        public string fill { get; set; } = null;
        public string transform { get; set; } = null;
        public ICollection<object> Children { get; set; } = new List<object>();


    }
}
