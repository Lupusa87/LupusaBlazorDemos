using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class circle :strokeBase
    {

        public double cx { get; set; }
        public double cy { get; set; }
        public double r { get; set; }
        public string fill { get; set; }
        public string transform { get; set; }
        public ICollection<object> Children { get; set; } = new List<object>();


    }
}
