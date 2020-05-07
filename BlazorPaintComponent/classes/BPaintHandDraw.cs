using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent.classes
{
    [Serializable]
    public class BPaintHandDraw: BPaintObject
    {
        public MyPoint StartPosition { get; set; }
        public List<MyPoint> data;
        
        public bool IsValid()
        {

            return (data.Any());

        }

    }
}
