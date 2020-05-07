using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCalculatorComponent.Classes
{

    public class MyCalculatorOperation
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; }
        public string Operation { get; set; }
        public string Answer { get; set; }
    }
}
