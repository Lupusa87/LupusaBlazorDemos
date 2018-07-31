using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class strokeBase
    {
        public string stroke { get; set; } = null;
        //[Display(Name = "stroke_width")]
        public double stroke_width { get; set; } = double.NaN;
        public strokeLinecap stroke_linecap { get; set; }
        public string stroke_dasharray { get; set; } = null;


    }
}
