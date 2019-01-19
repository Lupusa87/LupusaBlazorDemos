using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.classes
{
    public class BWorkerMessage
    {
        public string GUID { get; set; }
        public string Caption { get; set; }
        public Int64 TimeStamp { get; set; }
        public int ClientID { get; set; }
        public DateTime Date { get; set; }


    }
}
