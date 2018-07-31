using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class path:strokeBase
    {
        public string id { get; set; } = null;
        public string d { get; set; } = null;

        public string fill { get; set; } = null;

        public double opacity { get; set; } = double.NaN;

    }
}
