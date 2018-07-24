using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib3
{
    public class HtmlElement
    {
        public int MyItemID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Dictionary<string, string> attributes { get; set; } = new Dictionary<string, string>();
        public ICollection<HtmlElement> children { get; set; } = new List<HtmlElement>();
        public int Level { get; set; }
    }
}
