using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTreeVisualizerComponent
{
    public static class LocalEnums
    {
        public enum TreeVizualizationItem
        {
            Minus_Right,
            Minus_Top_Right,
            Minus_Bottom_Right,
            Minus_Top_Bottom_Right,

            Plus_Right,
            Plus_Top_Right,
            Plus_Bottom_Right,
            Plus_Top_Bottom_Right,

            Item,
            Line,
            LastItem,
        }
    }
}
