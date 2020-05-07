using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent.classes
{
    [Serializable]
    public class BPaintObject : IBPaintObject
    {
        public int ObjectID { get; set; }
        public bool Selected { get; set; }
        public bool EditMode { get; set; }
        public int SequenceNumber { get; set; }


        public string Color { get; set; }
        public double width { get; set; }

        public MyPoint StartPosition { get; set; }
        public MyPoint PositionChange { get; set; } = new MyPoint(0,0);
        public MyPoint Scale { get; set; } = new MyPoint(0, 0);
        public BPaintOpbjectType ObjectType { get; set; }



    }
}
