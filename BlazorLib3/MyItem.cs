using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib3
{
    public class MyItem
    {
        public int ID { get; set; }
        public string Rawhtml { get; set; }
        public bool HasAttributes { get; set; }
        public string Attributeshtml { get; set; }
        public string TagName { get; set; }
        public bool IsCloseTag { get; set; }
        public int CloseID { get; set; }
        public int ParentID { get; set; }
        public int Level { get; set; }
        public bool IsParent { get; set; }
        public bool IsContent { get; set; }
    }
}
