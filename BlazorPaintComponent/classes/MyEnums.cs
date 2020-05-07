using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent.classes
{
    public class MyEnums
    {
    }


    public enum BPaintOpbjectType
    {
        HandDraw=0,
        Line=1,


    }


    public enum BPaintMoveDirection
    {
        left = 0,
        right = 1,
        up = 2,
        down = 3,

    }

    public enum BPaintMode
    {
        none = 0,
        draw = 1,
        edit = 2,
        

    }


}
