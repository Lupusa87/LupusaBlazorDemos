using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib2.Classes.SubClasses
{
    public class path:strokeBase
    {

        public string d { get; set; }
       
        public string fill { get; set; }
    }
}
