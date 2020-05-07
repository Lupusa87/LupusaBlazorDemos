using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent.Classes
{
    public enum DirectionType
    {
        Up,
        Down,
        Left,
        Right,
        empty
    }

    public enum MyValueType
    {
        free,
        snake,
        target,
        wall
    }
}
