using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent.classes
{
    [Serializable]
    public class MyPoint
    {
        public double x { get; set; }
        public double y { get; set; }

        public MyPoint(double _x, double _y)
        {
            x = _x;
            y = _y;

        }

    }


    public class MyPointRect
    {
        public double x { get; set; }
        public double y { get; set; }

        public double width { get; set; }
        public double height { get; set; }

    }
}
