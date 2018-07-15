using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib1
{

    public enum CanvasProperty
    {
        font,
        textAlign,
        textBaseline,
        lineWidth,
        lineCap,
    }

    public enum TextAlign
    {
        Start,
        End,
        Left,
        Right,
        Center,
        undefined
    }

    public enum TextBaseline
    {
        Alphabetic,
        Top,
        Hanging,
        Middle,
        Ideographic,
        Bottom,
        undefined
    }

    public enum TextDirection
    {
        Inherit,
        LTR,
        RTL
    }

    public enum LineCap
    {
        Butt,
        Round,
        Square
    }

    public enum LineJoin
    {
        Miter,
        Round,
        Bevel
    }
}
