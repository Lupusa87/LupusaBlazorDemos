using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent.classes
{
    public interface IBPaintObject
    {
        int ObjectID { get; set; }
        bool Selected { get; set; }

        bool EditMode { get; set; }

        int SequenceNumber { get; set; }



        string Color { get; set; }
        double width { get; set; }


        MyPoint StartPosition { get; set; }
        MyPoint PositionChange { get; set; }


        MyPoint Scale { get; set; }

        BPaintOpbjectType ObjectType { get; set; }
    }
}
