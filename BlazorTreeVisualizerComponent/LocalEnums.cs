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
            MinusRight,
            MinusTopRight,
            MinusBottomRight,
            MinusTopBottomRight,

            PlusRight,
            PlusTopRight,
            PlusBottomRight,
            PlusTopBottomRight,

            Item,
            Line,
            LastItem,
        }
    }
}
